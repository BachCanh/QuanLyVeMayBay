using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeMayBay.Properties
{
    public partial class FInputInformation : Form
    {
        DBConnection db;
        private ConNguoi cn = new ConNguoi();
        private ChuyenBay cb;
        private LoaiVe lv;
        public FInputInformation(DBConnection db, ChuyenBay cb, LoaiVe lv)
        {
            InitializeComponent();
            this.db = db;
            this.cb = cb;
            this.lv = lv;
            FillInfor();
        }
        public FInputInformation(DBConnection db, ChuyenBay cb, LoaiVe lv, ConNguoi cn)
        {
            InitializeComponent();
            this.db = db;
            this.cb = cb;
            this.lv = lv;
            this.cn = cn;
            FillInfor();
        }

        private void FillInfor()
        {
            lblXuatPhat.Text = cb.XuatPhat;
            lblDen.Text = cb.Den;
            lblNgayXuatPhat.Text = cb.NgayBay.ToString("dd/MM/yyyy");
            if(cn.HoTen != string.Empty)
            {
                txtFullname.Text = cn.HoTen;
                txtDienThoai.Text = cn.SDT;
                txtEmail.Text = cn.Email;
                txtNgaySinh.Text = cn.NgaySinh.ToString("dd/MM/yyyy");
                if(cn.GioiTinh == "Nam") rbtnNam.Checked = true;
                if(cn.GioiTinh == "Nu") rbtnNam.Checked = true;
                if(cn.GioiTinh == "Khac") rbtnNam.Checked = true;
            }
            ucSubBodyControl1.FillGia(cb, lv);
        }
        private void getConNguoi()
        {
            string hoten = txtFullname.Text;
            DateTime ngaysinh; 
            DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out ngaysinh);
            string gioitinh = (rbtnKhac.Checked) ? rbtnKhac.Text : rbtnNam.Text;
            gioitinh = (rbtnNam.Checked) ? rbtnNam.Text : rbtnNu.Text;
            string sdt = txtDienThoai.Text;
            string email = txtEmail.Text;
            cn = new ConNguoi(hoten, ngaysinh, gioitinh, sdt, email);
        }
        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FSelectFight fInput = new FSelectFight(db, cb);
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            getConNguoi();
            FSelectAdd_On fInput = new FSelectAdd_On(db, cb, cn, lv);
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();

        }

        private void txtNgaySinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtNgaySinh.Text.Length >= 10)
            {
                // Stop receiving further character input by handling the key press event
                e.Handled = true;
                return; // Exit the event handler
            }
            // Check if the character is a digit and the length of the text is less than 8 (DDMMYYYY)
            if (char.IsDigit(e.KeyChar) && txtNgaySinh.Text.Length < 8)
            {
                // Append the typed character to the textbox
                txtNgaySinh.Text += e.KeyChar;

                // Check if the length of the text allows for insertion of slashes
                if (txtNgaySinh.Text.Length == 2 || txtNgaySinh.Text.Length == 5)
                {
                    // If the length is 2 or 5, insert a slash after the second or fifth character
                    txtNgaySinh.Text += "/";
                }

                // Set the cursor position to the end of the textbox
                txtNgaySinh.SelectionStart = txtNgaySinh.Text.Length;
                // Cancel the key press event to prevent the character from being entered twice
                e.Handled = true;
            }

        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtDienThoai.Text.Length >= 12)
            {
                e.Handled = true;
                return; // Exit the event handler
            }
            if (char.IsDigit(e.KeyChar) && txtDienThoai.Text.Length < 9)
            {
                // Append the typed character to the textbox
                txtDienThoai.Text += e.KeyChar;

                // Check if the length of the text allows for insertion of slashes
                if (txtDienThoai.Text.Length == 3 || txtDienThoai.Text.Length == 7)
                {
                    // If the length is 2 or 5, insert a slash after the second or fifth character
                    txtDienThoai.Text += "-";
                }

                // Set the cursor position to the end of the textbox
                txtDienThoai.SelectionStart = txtDienThoai.Text.Length;
                // Cancel the key press event to prevent the character from being entered twice
                e.Handled = true;
            }
        }

    }
}
