using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeMayBay
{
    public partial class AddFlight : Form
    {
        private object previousSelectedItemCbbXuatPhat;
        private object previousSelectedItemCbbDen;
        private Dictionary<string, Dictionary<string, int>> travelTimes;
        private DBConnection db;
        private int time;
        ChuyenBay cb = new ChuyenBay();

        public AddFlight(DBConnection db, ChuyenBay cbay)
        {
            InitializeComponent();
            this.db = db;
            foreach (var item in db.GetAllMayBay())
            {
                string mb = item.MaMB + " - " + item.TenMB;
                cbbMayBay.Items.Add(mb);
            }

            if (cbay.MaCB != null && !cbay.MaCB.Equals("") && cbay.NgayBay != null && cbay.NgayBay != DateTime.MinValue)
            {
                this.cb = cbay;
                FillInfor();
                btnCRUD.Text = "Sua";
                btnCRUD.Click -= guna2Button2_Click;
                btnCRUD.Click += btnCrud_Click;
                lblTitle.Text = "Sua Chuyen Bay";
            }
        }
        private void FillInfor()
        {
            cbbXuatPhat.Text = cb.XuatPhat;
            cbbDen.Text = cb.Den;
            var item = cbbMayBay.Items.Cast<object>().FirstOrDefault(item => item.ToString().Contains(cb.MB.MaMB));
            cbbMayBay.SelectedItem = item;
            dtpNgayBay.Value = cb.NgayBay;
            dtpGioBay.Value = new DateTime(cb.NgayBay.Year, cb.NgayBay.Month, cb.NgayBay.Day, cb.CatCanh.Hours, cb.CatCanh.Minutes, cb.CatCanh.Seconds);
            lblTgBay.Text = cb.PhutBay.ToString();
            lblGioKH.Text = cb.CatCanh.ToString();
            lblGioDen.Text = cb.HaCanh.ToString();
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddFlight_Load(object sender, EventArgs e)
        {
            travelTimes = new Dictionary<string, Dictionary<string, int>>
            {
                { "Ha Noi (HAN)", new Dictionary<string, int> { { "Ho Chi Minh (SGN)", 130 }, { "Da Nang (DAD)", 80 }, { "Da Lat (DLI)", 110 } } },
                { "Ho Chi Minh (SGN)", new Dictionary<string, int> { { "Ha Noi (HAN)",  130},  { "Da Nang (DAD)", 80 }, { "Da Lat (DLI)", 55 } } },
                { "Da Nang (DAD)", new Dictionary<string, int> { { "Da Lat (DLI)", 70 }, { "Ho Chi Minh (SGN)", 80 }, { "Ha Noi (HAN)", 80 } } },
                { "Da Lat (DLI)", new Dictionary<string, int> { { "Da Lat (DLI)", 70 }, { "Ho Chi Minh (SGN)", 55 }, { "Ha Noi (HAN)", 110 } } }
            };
            cbbDen.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            cbbXuatPhat.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }

        private void cbbXuatPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentSelectedItem = ((ComboBox)sender).SelectedItem;
            ComboBox cbbOther = cbbDen;
            if (previousSelectedItemCbbXuatPhat != null && !cbbOther.Items.Contains(previousSelectedItemCbbXuatPhat))
            {
                cbbOther.Items.Add(previousSelectedItemCbbXuatPhat);
            }
            if (currentSelectedItem != null && cbbOther.Items.Contains(currentSelectedItem))
            {
                cbbOther.Items.Remove(currentSelectedItem);
            }
            previousSelectedItemCbbXuatPhat = currentSelectedItem;
        }
        private void cbbDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentSelectedItem = ((ComboBox)sender).SelectedItem;
            ComboBox cbbXP = cbbXuatPhat;
            if (previousSelectedItemCbbDen != null && !cbbXP.Items.Contains(previousSelectedItemCbbDen))
            {
                cbbXP.Items.Add(previousSelectedItemCbbDen);
            }
            if (currentSelectedItem != null && cbbXP.Items.Contains(currentSelectedItem))
            {
                cbbXP.Items.Remove(currentSelectedItem);
            }
            previousSelectedItemCbbDen = currentSelectedItem;
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbXuatPhat.SelectedIndex != -1 && cbbDen.SelectedIndex != -1)
            {
                string fromCity = cbbXuatPhat.SelectedItem.ToString();
                string toCity = cbbDen.SelectedItem.ToString();

                if (travelTimes.ContainsKey(fromCity) && travelTimes[fromCity].ContainsKey(toCity))
                {
                    time = travelTimes[fromCity][toCity];
                    lblTgBay.Text = $"{time} minutes";
                }
                else
                {
                    lblTgBay.Text = "No travel time information available";
                }
            }
        }

        private void dtpGioBay_ValueChanged(object sender, EventArgs e)
        {
            lblGioKH.Text = dtpGioBay.Value.ToString("HH:mm");
            lblGioDen.Text = dtpGioBay.Value.AddMinutes(time).ToString("HH:mm");
        }

        private void SetInforChuyenBay()
        {
            string xuatphat = cbbXuatPhat.Text;
            string den = cbbDen.Text;
            string maMB = cbbMayBay.Text.Substring(0, 4);
            string tenMB = cbbMayBay.Text.Substring(7);
            MayBay mb = new MayBay(maMB, tenMB);
            DateTime ngaybay = dtpNgayBay.Value;
            int phutbay = time;
            DateTime gioBay = dtpGioBay.Value;
            TimeSpan catcanh = gioBay.TimeOfDay;
            TimeSpan hacanh = gioBay.TimeOfDay.Add(TimeSpan.FromMinutes(phutbay));
            cb = new ChuyenBay(cb.MaCB, xuatphat, den, ngaybay, hacanh, catcanh, phutbay, mb);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            SetInforChuyenBay();
            db.ThemChuyenBay(cb);
            this.Close();
        }

        private void btnCrud_Click(object sender, EventArgs e)
        {
            SetInforChuyenBay();
            db.SuaChuyenBay(cb);
            this.Close();
        }
    }
}
