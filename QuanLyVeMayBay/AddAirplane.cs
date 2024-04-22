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
        List<LoaiVe> loaiVes = new List<LoaiVe>();
        DBConnection db;
        public AddAirplane(MayBay mb, DBConnection db)
        {
            InitializeComponent();
            this.mb = mb;
            this.db = db;
        }

        private void AddAirplane_Load(object sender, EventArgs e)
        {

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCRUD_Click(object sender, EventArgs e)
        {
            loaiVes.Add(new LoaiVe(int.Parse(txtEco.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtDeluxe.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtSkyBoss.Text)));
            loaiVes.Add(new LoaiVe(int.Parse(txtBusiness.Text)));
            mb = new MayBay(txtTenMB.Text, loaiVes);
            db.ThemMayBay(mb);
        }
    }
}
