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
    public partial class FAddHL : Form
    {
        DBConnection db;
        HanhLy hl = new HanhLy();
        public FAddHL(DBConnection db, HanhLy hl)
        {
            InitializeComponent();
            this.db = db;
            if(hl.Gia != null && hl.Cannang != null)
            {
                this.hl = hl;
                lblTitle.Text = "Sua Hanh Ly";
                btnCRUD.Text = "Sua";
                FillInfor();
                btnCRUD.Click -= btnCRUD_Click;
                btnCRUD.Click += btnSua_Click;
            }
        }

        private void FillInfor()
        {
            txtGia.Text = hl.Gia.ToString();
            txtKG.Text = hl.Cannang.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            object cannang = txtKG.Text;
            object gia = txtGia.Text;
            hl = new HanhLy(cannang, gia);
            db.ThemHanhLy(hl);
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            object cannang = txtKG.Text;
            object gia = txtGia.Text;
            hl = new HanhLy(hl.MaHL, cannang, gia);
            db.SuaHanhLy(hl);
            this.Close();
        }
    }
}
