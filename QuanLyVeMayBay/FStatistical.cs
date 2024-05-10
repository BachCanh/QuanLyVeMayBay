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
    public partial class FStatistical : Form
    {
        private List<Tuple<string, float, Color>> data = new List<Tuple<string, float, Color>>
        {
            Tuple.Create("Category 1", 30f, Color.Red),
            Tuple.Create("Category 2", 20f, Color.Blue),
            Tuple.Create("Category 3", 25f, Color.Green),
            Tuple.Create("Category 4", 15f, Color.Yellow),
            Tuple.Create("Category 5", 5f, Color.Orange),
            Tuple.Create("Category 6", 5f, Color.Orange)
        };
        DBConnection db;
        public FStatistical(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.GetAllFlightPassengerCount();
            lblDT.Text = "Doanh Thu Ve";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerSuatAn();
            lblDT.Text = "Doanh Thu Suat An";

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerHanhLy();
            lblDT.Text = "Doanh Thu Hanh Ly";
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerTotal();
            lblDT.Text = "Doanh Thu Tong";
        }
    }
}
