using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeMayBay
{
    public partial class FPayment : Form
    {
        DBConnection db;
        VeMayBay ve = new VeMayBay();
        public FPayment(DBConnection db, VeMayBay ve)
        {
            InitializeComponent();
            this.db = db;
            this.ve = ve;
            FillInfor();
        }

        private void FillInfor()
        {
            lblXuatPhat.Text = ve.ChuyenBay.XuatPhat;
            lblDen.Text = ve.ChuyenBay.Den;
            lblNgayBay.Text = ve.ChuyenBay.NgayBay.ToString("dd/MM/yyyy");
            ucSubBodyControl1.FillGia(ve.ChuyenBay, ve.LoaiVe, ve.KhachHang, ve.HanhLy, ve.GM);
            lblTong.Text = ve.CalTongTien().ToString("N0") + " VND";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                db.ThemVeChuyenBay(ve);
                MessageBox.Show("Thanh Toan Thanh Cong!");
                CreatePDF.CreatePDFDocument(ve);
                byte[] pdfBytes = new byte[0];
                Form form = new Form();
                WebBrowser webBrowser = new WebBrowser();
                form.Controls.Add(webBrowser);
                string pdfFilePath = @$"C:\Users\Canh\Downloads\{ve.MaVe.ToUpper()}.pdf";
                pdfBytes = db.ReadPdfFileToByteArray(pdfFilePath);
                db.ThemBienLai(ve.MaVe, pdfBytes);
                if (ve.GM.Count > 0)
                {
                    foreach (var item in ve.GM)
                    {
                        item.SetMaVe(ve.MaVe);
                        db.DatMonAn(item);
                    }
                }
                webBrowser.Navigate(pdfFilePath);
            }
            catch (SqlException ex)
            {
                foreach (SqlError error in ex.Errors)
                {
                    MessageBox.Show($"SQL Error: {error.Number} - {error.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.Hide();
            FThankYou fThankYou = new FThankYou();
            fThankYou.Show();
        }

        private void ucSubBodyControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
