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
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QuanLyVeMayBay
{
    public partial class FFlight : Form
    {
        private Guna2Button selectedBtn;
        private DBConnection db;
        ChuyenBay cb = new ChuyenBay();
        MayBay mb = new MayBay();
        public FFlight(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
            cb = new ChuyenBay();
            btnChuyenBay.Click += btnClick;
            btnMayBay.Click += btnClick;
        }

        private void FFlight_Load(object sender, EventArgs e)
        {
            if (selectedBtn == btnChuyenBay)
            {
                dtBody.DataSource = this.db.GetAllChuyenBaydt();
            }
            else if(selectedBtn == btnMayBay)
            {
                dtBody.DataSource = db.GetAllMayBaydt();
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (selectedBtn == btnChuyenBay)
            {
                AddFlight fInput = new AddFlight(db, cb);
                fInput.Show();
            }
            else
            {
                AddAirplane addAirplane = new AddAirplane(new MayBay(), db);
                addAirplane.Show();
            }
        }

        private void dtBody_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtBody.Rows[e.RowIndex];

                if (selectedRow != null)
                {
                    if (selectedBtn == btnChuyenBay)
                    {
                        dtBody.CurrentRow.Selected = true;
                        string maCB = selectedRow.Cells[0].Value.ToString().Trim();
                        string xuatphat = selectedRow.Cells[1].Value.ToString().Trim();
                        string den = selectedRow.Cells[2].Value.ToString().Trim();
                        string maMB = selectedRow.Cells[3].Value.ToString().Trim();

                        MayBay maybay = new MayBay(maMB, "0");

                        DateTime ngaybay = (DateTime)selectedRow.Cells[4].Value;

                        TimeSpan catcanh = (TimeSpan)selectedRow.Cells[5].Value;
                        TimeSpan hacanh = (TimeSpan)selectedRow.Cells[6].Value;
                        int phutbay = (int)selectedRow.Cells[7].Value;
                        cb = new ChuyenBay(maCB, xuatphat, den, ngaybay, hacanh, catcanh, phutbay, mb);
                    }
                    else if(selectedBtn == btnMayBay)
                    {
                        dtBody.CurrentRow.Selected = true;
                        string maMB = selectedRow.Cells[0].Value.ToString().Trim();
                        string tenMB = selectedRow.Cells[1].Value.ToString().Trim();
                        List<LoaiVe> loaiVes = new List<LoaiVe>();
                        loaiVes.Add(new LoaiVe((int)selectedRow.Cells[2].Value));
                        loaiVes.Add(new LoaiVe((int)selectedRow.Cells[3].Value));
                        loaiVes.Add(new LoaiVe((int)selectedRow.Cells[4].Value));
                        loaiVes.Add(new LoaiVe((int)selectedRow.Cells[5].Value));
                        mb = new MayBay(maMB, tenMB, loaiVes);
                    }
                    else
                    {
                        MessageBox.Show("Please what you want to do!");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cb.MaCB != null && !cb.MaCB.Equals("") && cb.NgayBay != null && cb.NgayBay != DateTime.MinValue && selectedBtn == btnChuyenBay)
            {
                AddFlight fInput = new AddFlight(db, cb);
                fInput.Show();
            }
            else if (selectedBtn == btnMayBay && mb.LoaiVe.Count > 0)
            {
                AddAirplane addAirplane = new AddAirplane(mb, db);
                addAirplane.Show();
            }
            else
            {
                MessageBox.Show("Please choose a row to Update");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cb.MaCB != null && !cb.MaCB.Equals("") && cb.NgayBay != null && cb.NgayBay != DateTime.MinValue && selectedBtn == btnChuyenBay)
            {
                db.XoaChuyenBay(cb.MaCB);
            }
            else if (selectedBtn == btnMayBay && mb.LoaiVe.Count > 0)
            {
                db.XoaMayBay(mb.MaMB);
            }
            else
            {
                MessageBox.Show("Please choose a row to Delete");
            }
        }

        private void btnClick(object sender, EventArgs e)
        {
            Guna2Button clickedBtn = (Guna2Button)sender;

            if (clickedBtn == selectedBtn)
            {
                return;
            }

            if (selectedBtn != null)
            {
                selectedBtn.FillColor = Color.LightGreen;
                selectedBtn.Enabled = true;
            }

            clickedBtn.FillColor = Color.FromArgb(65, 176, 110);

            selectedBtn = clickedBtn;
            FFlight_Load(sender, e);
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FFlight_Load(sender, e);
        }
    }
}
