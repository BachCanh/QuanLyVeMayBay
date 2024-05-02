using Guna.UI2.WinForms;
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
    public partial class FMainPage : Form
    {
        private object previousSelectedItemCbbXuatPhat;
        private object previousSelectedItemCbbDen;
        DBConnection db = new DBConnection($"Data Source=LAPTOP-Q3MNC1CJ;Initial Catalog=QuanLyVeMayBay;Integrated Security=True;Encrypt=False");
        public FMainPage()
        {
            InitializeComponent();
            dtpXuatPhat.MinDate = DateTime.Now;

            dtpXuatPhat.MaxDate = new DateTime(9998, 12, 31);


        }

        private void btnTraCuu_Click(object sender, EventArgs e)
        {
            FFindFlight fFindFlight = new FFindFlight(db);
            this.Hide();
            fFindFlight.Closed += (s, args) => this.Close();
            fFindFlight.Show();
        }

        private void btnTimChuyenBay_Click(object sender, EventArgs e)
        {
            ChuyenBay chuyenBay = new ChuyenBay(cbbXuatPhat.Text, cbbDen.Text, dtpXuatPhat.Value);
            FSelectFight fSelectFight = new FSelectFight(db, chuyenBay);
            this.Hide();
            fSelectFight.Closed += (s, args) => this.Close();
            fSelectFight.Show();
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

        //private void dtpXuatPhat_ValueChanged(object sender, EventArgs e)
        //{
        //    dtpDen.MinDate = dtpXuatPhat.Value.AddDays(1);

        //    if (dtpDen.Value < dtpDen.MinDate)
        //    {
        //        dtpDen.Value = dtpDen.MinDate;
        //    }
        //}
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            FLogin flogin = new FLogin();
            this.Hide();
            flogin.Closed += (s, args) => this.Close();
            flogin.Show();
        }
    }
}
