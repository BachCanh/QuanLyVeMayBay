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
    public partial class FSelectSA : Form
    {
        DBConnection db;
        List<GoiMon> goiMons = new List<GoiMon>();
        FSelectAdd_On FSelectAdd_On;
        public FSelectSA(DBConnection db, FSelectAdd_On fSelect)
        {
            InitializeComponent();
            this.db = db;
            this.FSelectAdd_On = fSelect;
            foreach (SuatAn sa in db.GetAllSuatAn())
            {
                UCSuatAn uc = new UCSuatAn(sa);
                flpBody.Controls.Add(uc);
                flpBody.Height += uc.Height + 30;
            }
        }

        private void getGoiMon()
        {
            foreach(Control control in flpBody.Controls)
            {
                if(control is UCSuatAn)
                {
                    UCSuatAn uc = (UCSuatAn)control;
                    if (!uc.FirstClick)
                    {
                        SuatAn SA = uc.SA;
                        int soluong = uc.SoLuong;
                        goiMons.Add(new GoiMon(SA, soluong));
                    }
                }
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            getGoiMon();
            
            this.Hide();
        }
        public List<GoiMon> GoiMonS
        {  get { return goiMons; } }
    }
}
