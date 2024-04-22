using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace QuanLyVeMayBay
{
    public partial class FFlight : Form
    {
        private DBConnection db;
        ChuyenBay cb = new ChuyenBay();
        public FFlight(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void FFlight_Load(object sender, EventArgs e)
        {
            dtBody.DataSource = this.db.GetAllChuyenBay();
            cb = new ChuyenBay();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FFlight_Load(sender, e);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddFlight fInput = new AddFlight(db, cb);
            fInput.Show();
        }

        private void dtBody_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtBody.Rows[e.RowIndex];

                if (selectedRow != null)
                {
                    dtBody.CurrentRow.Selected = true;
                    string maCB = selectedRow.Cells[0].Value.ToString().Trim();
                    string xuatphat = selectedRow.Cells[1].Value.ToString().Trim();
                    string den = selectedRow.Cells[2].Value.ToString().Trim();
                    string maMB = selectedRow.Cells[3].Value.ToString().Trim();

                    string tenMB = ".";
                    MayBay mb = new MayBay(maMB, tenMB);


                    DateTime ngaybay = (DateTime)selectedRow.Cells[4].Value;

                    TimeSpan catcanh = (TimeSpan)selectedRow.Cells[5].Value;
                    TimeSpan hacanh = (TimeSpan)selectedRow.Cells[6].Value;
                    int phutbay = (int)selectedRow.Cells[7].Value;
                    cb = new ChuyenBay(maCB, xuatphat, den, ngaybay, hacanh, catcanh, phutbay, mb);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (cb.MaCB != null && !cb.MaCB.Equals("") && cb.NgayBay != null && cb.NgayBay != DateTime.MinValue)
            {
                AddFlight fInput = new AddFlight(db, cb);
                fInput.Show();
            }
            else
            {
                MessageBox.Show("Please choose a row to Update");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (cb.MaCB != null && !cb.MaCB.Equals("") && cb.NgayBay != null && cb.NgayBay != DateTime.MinValue)
            {
                db.XoaChuyenBay(cb.MaCB);
            }
            else
            {
                MessageBox.Show("Please choose a row to Update");
            }
        }
    }
}
