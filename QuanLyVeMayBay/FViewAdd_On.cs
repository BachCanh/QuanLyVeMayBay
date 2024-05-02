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
    public partial class FViewAdd_On : Form
    {
        HanhLy hl;
        List<GoiMon> gms;
        public FViewAdd_On(HanhLy hl, List<GoiMon> gms)
        {
            InitializeComponent();
            this.hl = hl;
            this.gms = gms;
            addInfor();
        }

        private void addInfor()
        {
            if (hl.Cannang != null)
            {
                Panel pn = new Panel();
                pnHanhLy.Controls.Add(pn);
                lblTenHL.Text = "Hanh ly ky gui " + hl.Cannang.ToString() + "kg";
            }
            else
            {
                pnHanhLy.Visible = false;
                pnHanhLy.Enabled = false;
                this.Height = pnSAview.Height;
            }
            if (gms.Count > 0)
            {
                foreach (GoiMon gm in gms)
                {
                    UCSA uc = new UCSA(gm);
                    pnSAview.Controls.Add(uc);
                    uc.Show();
                    this.Height += uc.Height + 1;
                }
            }
            else
            {
                this.Height = 10;
                pnSuatAn.Visible = false;
                pnSuatAn.Enabled = false;
            }
        }

    }
}
