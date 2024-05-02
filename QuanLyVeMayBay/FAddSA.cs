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
    public partial class FAddSA : Form
    {
        DBConnection db;
        SuatAn sa = new SuatAn();
        public FAddSA(DBConnection db, SuatAn sa)
        {
            InitializeComponent();
            this.db = db;
            if(sa.TenSA != null && sa.Gia != 0)
            {
                this.sa = sa;
                btnCRUD.Text = "Sua";
                lblTitle.Text = "Sua Suat An";
                btnAddImage.Text = "Sua Hinh";
                FillInfor();
                btnCRUD.Click-= btnCRUD_Click;
                btnCRUD.Click += btnSua_Click;
            }
        }

        public void FillInfor()
        {
            txtTenSA.Text = sa.TenSA;
            txtGia.Text = sa.Gia.ToString();
            ptbImage.Image = sa.HinhMH;
        }
        public void ChoosePicture(ref Guna.UI2.WinForms.Guna2PictureBox ptb)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ptb.ImageLocation = openFileDialog.FileName;
                }
            }
        }
        private void btnAddImage_Click(object sender, EventArgs e)
        {
            ChoosePicture(ref ptbImage);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            string tenSA = txtTenSA.Text;
            decimal gia;
            decimal.TryParse(txtGia.Text, out gia);
            Image img = ptbImage.Image; 
            sa = new SuatAn(tenSA, gia, img);
            db.ThemSuatAn(sa);
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maSA = sa.MaSA;
            string tenSA = txtTenSA.Text;
            decimal gia;
            decimal.TryParse(txtGia.Text, out gia);
            Image img = ptbImage.Image;
            sa = new SuatAn(maSA, tenSA, gia, img);
            db.SuaSuatAn(sa);
            this.Close();
        }
    }
}
