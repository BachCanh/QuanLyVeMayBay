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
            fSelectSA.btnXong.Click += FSelectSA_FormClosed;
            fSelectHL.btnXong.Click += FSelectSA_FormClosed;
        }
        private void FillInfor()
        {
            lblXuatPhat.Text = cb.XuatPhat;
            lblDen.Text = cb.Den;
            lblNgayBay.Text = cb.NgayBay.ToString("dd/MM/yyyy");
            decimal giaHL = 0;
            if (fSelectHL.HL.Gia != null)
            {
                hl = fSelectHL.HL;
                lblHanhLy.Text = "Goi ky gui " + hl.Cannang + "kg";
                lblGiaHL.Text = ((decimal)hl.Gia).ToString("N0") + " VND";
                giaHL = (decimal)hl.Gia;
            }
            else hl = new HanhLy();
            int count = 0;
            decimal gia = 0;
            if (fSelectSA.GoiMonS.Count > 0)
            {
                goiMons = fSelectSA.GoiMonS;
                foreach(GoiMon gm in  goiMons)
                {
                    count+=gm.SoLuong;
                    gia += gm.TongTien();
                }
            }
            ucSubBodyControl1.FillGia(cb, lv, cn, hl, goiMons);
            lblSAnong.Text = "Suất ăn nóng x" + (count);
            lblGiaSA.Text = gia.ToString("N0") + " VND";
            decimal tong = gia + giaHL + lv.Gia;
            lblTongTien.Text = tong.ToString("N0") + " VND";
        }

        private void FSelectSA_FormClosed(object sender, EventArgs e)
        {
                this.FillInfor();
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
