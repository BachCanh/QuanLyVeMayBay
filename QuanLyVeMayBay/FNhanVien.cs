using Guna.UI2.WinForms.Enums;
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
    public partial class FNhanVien : Form
    {
        private Guna.UI2.WinForms.Guna2Button selectedButton;
        private Form currentFormChild = new Form();
        private string conn;
        DBConnection db;
        public FNhanVien(string conn)
        {
            InitializeComponent();
            this.conn = conn;
            db = new DBConnection(conn);
            GetAllButtons(flpNavBar);
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();
            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnBody.Controls.Add(childForm);
            pnBody.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        void GetAllButtons(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Guna.UI2.WinForms.Guna2Button)
                {
                    Guna.UI2.WinForms.Guna2Button button = (Guna.UI2.WinForms.Guna2Button)c;
                    button.Click += button_Click;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            Guna.UI2.WinForms.Guna2Button clickedButton = (Guna.UI2.WinForms.Guna2Button)sender;
            if (clickedButton == selectedButton)
                return;

            if (selectedButton != null)
            {
                selectedButton.FillColor = Color.Transparent;
                selectedButton.Font = new Font("Cooper Black", 12f);
                selectedButton.ForeColor = Color.FromArgb(224, 224, 224);
                selectedButton.Enabled = true;
            }

            clickedButton.FillColor = Color.FromArgb(220, 251, 251);
            clickedButton.Font = new Font("Cooper Black", 16.2f);
            clickedButton.ForeColor = Color.Black;
            clickedButton.Enabled = true;
            selectedButton = clickedButton;
            //clickedButton.Enabled = false;
        }

        private void btnChuyenBay_Click(object sender, EventArgs e)
        {
            FFlight fFlight = new FFlight(db);
            OpenChildForm(fFlight);
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            FAdd_On fAdd_On = new FAdd_On(db);
            OpenChildForm(fAdd_On);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            FStatistical statistical = new FStatistical();
            OpenChildForm(statistical);
        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            FLogin fLogin = new FLogin();
            fLogin.Show();
            this.Hide();
        }
    }
}
