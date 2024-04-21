using QuanLyVeMayBay.Properties;
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
    public partial class FSelectAdd_On : Form
    {
        public FSelectAdd_On()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FInputInformation fInput = new FInputInformation();
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            FPayment fInput = new FPayment();
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }
    }
}
