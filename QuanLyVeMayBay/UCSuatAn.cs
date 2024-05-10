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
    public partial class UCSuatAn : UserControl
    {
        bool isFirstClick = true;
        private SuatAn sa;
        private int soluong = 0;
        public UCSuatAn(SuatAn sa)
        {
            InitializeComponent();
            this.sa = sa;
            FillInfor();
        }

        private void FillInfor()
        {
            lblTen.Text = sa.TenSA;
            lblGia.Text = sa.Gia.ToString("N0") + " VND";
            ptbHinhMH.Image = sa.HinhMH;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (isFirstClick)
            {
                btnAdd.Image = Properties.Resources.approved;
                nmrCount.Visible = true;
                isFirstClick = false;
            }
            else
            {
                btnAdd.Image = Properties.Resources.plus;
                nmrCount.Visible = false;
                isFirstClick = true;
                nmrCount.Value = 1;
            }
        }
        private void nmrCount_ValueChanged(object sender, EventArgs e)
        {
            if(nmrCount.Value < 1)
            {
                btnAdd.Image = Properties.Resources.plus;
                isFirstClick = true;
                nmrCount.Visible = false;
                nmrCount.Value = 1;
            }
            soluong = ((int)nmrCount.Value);
        }

        public SuatAn SA
        { get { return sa; } }
        public int SoLuong
        { get { return soluong; } }
        public bool FirstClick
        { get { return isFirstClick; } }
    }
}
