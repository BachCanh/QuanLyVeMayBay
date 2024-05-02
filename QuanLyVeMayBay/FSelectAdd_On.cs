using QuanLyVeMayBay.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeMayBay
{
    public partial class FSelectAdd_On : Form
    {
        DBConnection db;
        ChuyenBay cb;
        FSelectHL fSelectHL;
        FSelectSA fSelectSA;
        ConNguoi cn;
        HanhLy hl = new HanhLy();
        VeMayBay ve = new VeMayBay();
        LoaiVe lv;
        List<GoiMon> goiMons = new List<GoiMon>();
        public FSelectAdd_On(DBConnection db, ChuyenBay cb, ConNguoi cn, LoaiVe lv)
        {
            InitializeComponent();
            this.db = db;
            this.cb = cb;
            this.cn = cn;
            this.lv = lv;
            fSelectHL = new FSelectHL(db);
            fSelectSA = new FSelectSA(db, this);
            FillInfor();
            fSelectSA.FormClosing += FSelectSA_FormClosing;
            fSelectHL.FormClosing += FSelectSA_FormClosing;
        }
        private void FillInfor()
        {
            lblXuatPhat.Text = cb.XuatPhat;
            lblDen.Text = cb.Den;
            lblNgayBay.Text = cb.NgayBay.ToString("dd/MM/yyyy");
            if (fSelectHL.HL.Gia != null)
            {
                hl = fSelectHL.HL;
            }
            else hl = new HanhLy();

            if (fSelectSA.GoiMonS.Count > 0)
            {
                goiMons = fSelectSA.GoiMonS;
            }
            ucSubBodyControl1.FillGia(cb, lv, cn, hl, goiMons);
        }

        private void FSelectSA_FormClosing(object sender, FormClosingEventArgs e)
        {
            FillInfor();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FInputInformation fInput = new FInputInformation(db, cb, lv, cn);
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void SetVeMayBay()
        {
            if (fSelectHL.HL.Gia != null)
            {
                hl = fSelectHL.HL;
            }
            else hl = new HanhLy();
            ve = new VeMayBay(cn, cb, lv, hl);

            if (fSelectSA.GoiMonS.Count > 0)
            {
                foreach (GoiMon goiMon in fSelectSA.GoiMonS)
                {
                    ve.ThemMon(goiMon);
                }
            }
        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            SetVeMayBay();
            FPayment fInput = new FPayment(db, ve);
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void guna2Panel22_Click(object sender, EventArgs e)
        {
            fSelectSA.Show();
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            fSelectHL.Show();
        }

    }
}
