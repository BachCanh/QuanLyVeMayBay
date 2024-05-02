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
    public partial class FFindFlight : Form
    {
        DBConnection db;
        public FFindFlight(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
        }

        private void guna2HtmlLabel2_Click(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FMainPage fMainPage = new FMainPage();
            fMainPage.Show();
            this.Hide();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            WebBrowser webBrowser = new WebBrowser();
            this.Controls.Add(webBrowser);
            webBrowser.Visible = false; 
            string maVe = txtMaVe.Text;
            string hoten = txtHoTen.Text;
            db.DisplayPDFInWebBrowser(db.GetBienLai(maVe, hoten), ref webBrowser);
        }
    }
}
