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
    public partial class AddAirplane : Form
    {
        MayBay mb = new MayBay();
        DBConnection db;
        public AddAirplane(MayBay mb, DBConnection db)
        {
            InitializeComponent();
            this.db = db;

            if (mb.LoaiVe.Count > 0)
            {
                this.mb = mb;
                FillInfor();
                btnCRUD.Text = "Sua";
                btnCRUD.Click -= btnThem_Click;
                btnCRUD.Click += btnSua_Click;
                lblTitle.Text = "Sua May Bay";
            }
        }

        private void FillInfor()
        {
            txtTenMB.Text = mb.TenMB;
            txtEco.Text = mb.LoaiVe[0].SoLuong.ToString();
            txtDeluxe.Text = mb.LoaiVe[1].SoLuong.ToString();
            txtSkyBoss.Text = mb.LoaiVe[2].SoLuong.ToString();
            txtBusiness.Text = mb.LoaiVe[3].SoLuong.ToString();
        }

        private void AddAirplane_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<LoaiVe> loaiVes = new List<LoaiVe>();
            loaiVes.Add(new LoaiVe(int.Parse(txtEco.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtDeluxe.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtSkyBoss.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtBusiness.Text)));
            mb = new MayBay(txtTenMB.Text, loaiVes);
            db.ThemMayBay(mb);
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            List<LoaiVe> loaiVes = new List<LoaiVe>();
            loaiVes.Add(new LoaiVe(int.Parse(txtEco.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtDeluxe.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtSkyBoss.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtBusiness.Text)));

            mb = new MayBay(mb.MaMB, txtTenMB.Text, loaiVes);
            db.SuaMayBay(mb);
        }
    }
}
