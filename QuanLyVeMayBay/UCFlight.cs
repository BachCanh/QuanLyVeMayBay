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
    public partial class UCFlight : UserControl
    {
        private ChuyenBay cb = new ChuyenBay();
        public LoaiVe lv = new LoaiVe();
        DBConnection db;
        public UCFlight(ChuyenBay chuyenBay, DBConnection db)
        {
            InitializeComponent();
            this.cb = chuyenBay;
            this.db = db;
            this.MaximumSize = new System.Drawing.Size(757, 115);
        }

        private void UCFlight_Load(object sender, EventArgs e)
        {
            FillInfor();
        }

        public Color ColorType()
        {
            Color color = Color.White;
            if (cbbLoaiVe.SelectedIndex == 0)
            {
                color = Color.FromArgb(106, 183, 46);
            }
            else if (cbbLoaiVe.SelectedIndex == 1)
            {
                color = Color.FromArgb(249, 165, 26);
            }
            else if (cbbLoaiVe.SelectedIndex == 2)
            {
                color = Color.FromArgb(218, 33, 40);
            }
            else if (cbbLoaiVe.SelectedIndex == 3)
            {
                color = Color.FromArgb(175, 137, 3);
            }
            return color;
        }

        private void FillInfor()
        {
            lblCatCanh.Text = cb.CatCanh.ToString();
            lblGioHaCanh.Text = cb.HaCanh.ToString();
            lblTGbay.Text = cb.PhutBay.ToString() + "m";
            lblXuatPhat.Text = cb.XuatPhat;
            lblDen.Text = cb.Den;
            lblTienVe.Text = lv.Gia.ToString("N0");
        }

        private void cbbLoaiVe_SelectedIndexChanged(object sender, EventArgs e)
        {
            lv = db.GetLoaiVe(cb.MB.MaMB, cbbLoaiVe.Text);
            if(!db.checkVe(lv, cb))
            {
                return;
            }
            if (cbbLoaiVe.SelectedIndex == 0)
            {
                ptbIconVe.Image = Properties.Resources.eco;
                ptbIconVe.FillColor = ColorType();
            }
            else if (cbbLoaiVe.SelectedIndex == 1)
            {
                ptbIconVe.Image = Properties.Resources.deluxe;
            }
            else if (cbbLoaiVe.SelectedIndex == 2)
            {
                ptbIconVe.Image = Properties.Resources.skyboss;
            }
            else if (cbbLoaiVe.SelectedIndex == 3)
            {
                ptbIconVe.Image = Properties.Resources.business;
            }
            ptbIconVe.BackColor = ColorType();

            FillInfor();
        }

        public LoaiVe LV
        {
            get { return lv; }
        }

        public ChuyenBay CBay
        {
            get { return cb; }
        }
    }
}
