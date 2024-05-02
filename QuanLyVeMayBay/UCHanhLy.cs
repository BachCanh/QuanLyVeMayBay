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
    public partial class UCHanhLy : UserControl
    {
        HanhLy hl;
        public UCHanhLy(HanhLy hl)
        {
            InitializeComponent();
            this.hl = hl;
            FillInfor();
        }

        private void FillInfor()
        {
            lblGia.Text = hl.Gia.ToString();
            lblTen.Text = hl.Cannang.ToString() + "kg";
        }

        public HanhLy HL
        { get { return hl; } }

    }
}
