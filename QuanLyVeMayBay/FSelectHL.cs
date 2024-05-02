using Guna.UI2.WinForms;
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
    public partial class FSelectHL : Form
    {
        private UCHanhLy currentlySelectedUC = null;
        HanhLy hl = new HanhLy();
        DBConnection db;
        public FSelectHL(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
            foreach (HanhLy hl in db.GetAllHanhLy())
            {
                UCHanhLy uc = new UCHanhLy(hl);
                flpBody.Controls.Add(uc);
                flpBody.Height += 195;
            }

            foreach (Control uc in flpBody.Controls)
            {
                if(uc is UCHanhLy)
                {
                    UCHanhLy uCHanhLy = (UCHanhLy)uc;   
                    uCHanhLy.btnAdd.Click += button_Click;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Guna2CirclePictureBox clickedButton = (Guna2CirclePictureBox)sender;
            UCHanhLy clickedUC = clickedButton.Parent.Parent.Parent as UCHanhLy;

            if (currentlySelectedUC != null && currentlySelectedUC != clickedUC)
            {
                ResetUserControl(currentlySelectedUC);
            }

            currentlySelectedUC = clickedUC;

            HandleUserControlClick(clickedUC, clickedButton);
        }
        private void HandleUserControlClick(UCHanhLy clickedUC, Guna2CirclePictureBox clickedButton)
        {
            if (clickedButton.Tag == null)
            {
                clickedButton.Tag = 0;
            }

            int buttonClickCount = (int)clickedButton.Tag;
            buttonClickCount++;

            if (buttonClickCount == 2)
            {
                clickedUC.btnAdd.Image = Properties.Resources.plus;
                buttonClickCount = 0;
            }
            else if (buttonClickCount == 1)
            {
                clickedUC.btnAdd.Image = Properties.Resources.approved;
            }

            clickedButton.Tag = buttonClickCount;
        }

        private void ResetUserControl(UCHanhLy uc)
        {
            Guna2CirclePictureBox button = uc.pnBody.Controls.OfType<Guna2CirclePictureBox>().FirstOrDefault();
            if (button != null)
            {
                button.Image = Properties.Resources.plus;
            }
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            if(currentlySelectedUC != null)
            { 
                hl = currentlySelectedUC.HL; 
            }
            else hl = new HanhLy();
            this.Hide();
        }
        public HanhLy HL
        { get { return hl; } }
    }
}
