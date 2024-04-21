using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyVeMayBay.Properties
{
    public partial class FInputInformation : Form
    {
        public FInputInformation()
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

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FSelectFight fInput = new FSelectFight(new ChuyenBay());
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            FSelectAdd_On fInput = new FSelectAdd_On();
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }
    }
}
