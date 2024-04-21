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
        ChuyenBay cb = new ChuyenBay();
        public UCFlight(ChuyenBay chuyenBay)
        {
            InitializeComponent();
            this.cb = chuyenBay;
            this.MaximumSize = new System.Drawing.Size(757, 115);
        }

        private void UCFlight_Load(object sender, EventArgs e)
        {
            FillInfor();
        }

        public Color ColorType()
        {
            Color color = Color.White;
            if(cbbLoaiVe.SelectedIndex == 0)
            {
                color = Color.FromArgb(193, 237, 197);
            }
            else if(cbbLoaiVe.SelectedIndex == 1)
            {
                color = Color.FromArgb(255, 244, 189);
            }
            else if(cbbLoaiVe.SelectedIndex == 2)
            {
                color = Color.FromArgb(255, 211, 213);
            }
            else if(cbbLoaiVe.SelectedIndex == 3)
            {
                color = Color.FromArgb(239, 228, 187);
            }
            return color;
        }

        private void FillInfor()
        {
            lblCatCanh.Text = cb.CatCanh.ToString();
            lblGioHaCanh.Text = cb.HaCanh.ToString();
            lblTGbay.Text = cb.PhutBay.ToString()+"m";
            lblXuatPhat.Text = cb.XuatPhat;
            lblDen.Text = cb.Den;
        }
    }
}
