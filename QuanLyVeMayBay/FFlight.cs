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
    public partial class FFlight : Form
    {
        private DBConnection db;
        public FFlight(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void FFlight_Load(object sender, EventArgs e)
        {
            dtBody.DataSource = this.db.GetAllChuyenBay();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            FFlight_Load(sender, e);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            AddFlight fInput = new AddFlight(db);
            fInput.Show();
        }
    }
}
