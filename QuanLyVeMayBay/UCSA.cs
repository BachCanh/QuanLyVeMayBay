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
    public partial class UCSA : UserControl
    {
        public UCSA(GoiMon suat)
        {
            InitializeComponent();
            lblGia.Text = suat.TongTien().ToString("N0") + " VND";
            if (suat.SoLuong > 1)
            {
                lblTen.Text = suat.SA.TenSA + " x" + suat.SoLuong.ToString();

            }
            else lblTen.Text = suat.SA.TenSA;
        }
    }
}
