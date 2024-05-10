using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace QuanLyVeMayBay
{
    public partial class UCSubBodyControl : UserControl
    {
        decimal tongcong = 0;
        bool clicked1 = true;
        bool clicked2 = true;
        ConNguoi cn = new ConNguoi();
        HanhLy hl = new HanhLy();
        private Form currentFormChild = new Form();
        private Form currentFormChild1 = new Form();
        List<GoiMon> gms = new List<GoiMon>();

        public UCSubBodyControl()
        {
            InitializeComponent();
        }

        public void FillGia(ChuyenBay cb, LoaiVe lv)
        {
            if (cb.XuatPhat != string.Empty)
            {
                lblDen.Text = cb.Den;
                lblXuatPhat.Text = cb.XuatPhat;
                lblNgayBay.Text = cb.NgayBay.ToString("ddd, dd/MM/yyyy") + " |";
                lblMaCB.Text = cb.MaCB + " |";
                lblGioDiDen.Text = cb.CatCanh.ToString(@"hh\:mm") + " - " + cb.HaCanh.ToString(@"hh\:mm") + " |";
                lblLoaiVe.Text = lv.TenLoai;
                lblGiaVe.Text = lv.Gia.ToString("N0") + " VND";
                lblTongCong.Text = (tongcong + lv.Gia).ToString("N0") + " VND";
            }
            else
            {
                lblDen.Text = "";
                lblXuatPhat.Text = "";
                lblNgayBay.Text = " |";
                lblMaCB.Text = " |";
                lblGioDiDen.Text = " - " + " |";
                lblLoaiVe.Text = "";
                lblGiaVe.Text = lv.Gia.ToString("N0") + " VND";
                lblTongCong.Text = (tongcong + lv.Gia).ToString("N0") + " VND";
            }
        }



        public void FillGia(ChuyenBay cb, LoaiVe lv, ConNguoi cn, HanhLy hl, List<GoiMon> gms)
        {
            FillGia(cb, lv);
            this.cn = cn;
            tongcong = 0;
            if (hl.Cannang != null)
            {
                tongcong += (decimal)hl.Gia;
                this.hl = hl;
            }
            if (gms.Count > 0)
            {
                foreach (GoiMon m in gms)
                {
                    tongcong += m.TongTien();
                }
                this.gms = gms;
            }

            lblGiaDichVu.Text = tongcong.ToString("N0") + " VND";

            lblTongCong.Text = (tongcong + lv.Gia).ToString("N0") + " VND";

        }
        private void OpenChildForm1(Form childForm, Panel pnBody)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private void OpenChildForm2(Form childForm, Panel pnBody)
        {
            if (currentFormChild1 != null)
            {
                currentFormChild1.Close();
            }
            currentFormChild1 = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            FViewAdd_On form = new FViewAdd_On(hl, gms);
            if(clicked1)
            {
                pnAdd_On.Height += form.Height+5;
                pnAddOn.Height = form.Height+5;
                pnAddOn.Visible = true;
                OpenChildForm1(form, pnAddOn);
                clicked1 = false;
            }
            else
            {
                pnAddOn.Visible = false;
                pnAdd_On.Height -= form.Height-5;
                clicked1 = true;
            }
            
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            FViewConNguoi form = new FViewConNguoi(cn);
            if(clicked2)
            {
                pnThong_Tin.Height += form.Height+10;
                pnThongTin.Height = form.Height+10;
                pnThongTin.Visible = true;
                OpenChildForm2(form, pnAddOn);
                clicked2 = false;
            }
            else
            {
                pnThongTin.Visible = false;
                pnThong_Tin.Height -= form.Height - 10;
                clicked2 = true;
            }
        }

        public string TongCong
        {
            get { return lblTongCong.Text; }
        }

    }
}
