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
    public partial class FViewConNguoi : Form
    {
        public FViewConNguoi(ConNguoi cn)
        {
            InitializeComponent();
            txtFullname.Text = cn.HoTen;
            txtDienThoai.Text = cn.SDT;
            txtEmail.Text = cn.Email;
            txtNgaySinh.Text = cn.NgaySinh.ToString("dd/MM/yyyy");
            if (cn.GioiTinh == "Nam") rbtnNam.Checked = true;
            if (cn.GioiTinh == "Nu") rbtnNam.Checked = true;
            if (cn.GioiTinh == "Khac") rbtnNam.Checked = true;
        }
    }
}
