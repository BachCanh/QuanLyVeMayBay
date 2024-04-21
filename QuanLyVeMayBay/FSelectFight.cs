using Guna.UI2.WinForms;
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
    public partial class FSelectFight : Form
    {
        private object previousSelectedItemCbbXuatPhat;
        private object previousSelectedItemCbbDen;
        ChuyenBay chuyenbay = new ChuyenBay();
        private List<UCFlight> userControls;
        VeMayBay ve = new VeMayBay();
        private UCFlight currentlySelectedUC;
        public FSelectFight(ChuyenBay chuyenBay)
        {
            InitializeComponent();
            this.chuyenbay = chuyenBay;
            FillInfor();
            userControls = new List<UCFlight>();
            foreach (Control control in flpBodyContent.Controls)
            {
                if (control is UCFlight)
                {
                    UCFlight uC = (UCFlight)control;
                    userControls.Add(uC);
                    uC.btnChonVeNay.Click += button_Click;
                }
            }
        }

        private void FillInfor()
        {
            lblXuatPhat.Text = chuyenbay.XuatPhat;
            lblDen.Text = chuyenbay.Den;
            lblNgayXuatPhat.Text = chuyenbay.NgayBay.ToString("dd/MM/yyyy");
            cbbXuatPhat.Text = chuyenbay.XuatPhat;
            cbbDen.Text = chuyenbay.Den;
            dtpNgayBay.Value = chuyenbay.NgayBay;
            // Declare and initialize parameters
            string maVe = "MV123";
            string maCB = "CB456";
            int phutBay = 120;
            DateTime ngaydat = DateTime.Now;
            DateTime ngaybay = DateTime.Now.AddDays(3);
            TimeSpan giocatcanh = new TimeSpan(10, 30, 0);
            TimeSpan giohacanh = new TimeSpan(12, 15, 0);

        }

        private void guna2HtmlLabel1_Click(object sender, EventArgs e)
        {

        }
        private void cbbXuatPhat_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentSelectedItem = ((ComboBox)sender).SelectedItem;
            ComboBox cbbOther = cbbDen;
            if (previousSelectedItemCbbXuatPhat != null && !cbbOther.Items.Contains(previousSelectedItemCbbXuatPhat))
            {
                cbbOther.Items.Add(previousSelectedItemCbbXuatPhat);
            }
            if (currentSelectedItem != null && cbbOther.Items.Contains(currentSelectedItem))
            {
                cbbOther.Items.Remove(currentSelectedItem);
            }
            previousSelectedItemCbbXuatPhat = currentSelectedItem;
        }
        private void cbbDen_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentSelectedItem = ((ComboBox)sender).SelectedItem;
            ComboBox cbbXP = cbbXuatPhat;
            if (previousSelectedItemCbbDen != null && !cbbXP.Items.Contains(previousSelectedItemCbbDen))
            {
                cbbXP.Items.Add(previousSelectedItemCbbDen);
            }
            if (currentSelectedItem != null && cbbXP.Items.Contains(currentSelectedItem))
            {
                cbbXP.Items.Remove(currentSelectedItem);
            }
            previousSelectedItemCbbDen = currentSelectedItem;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            chuyenbay = new ChuyenBay(cbbXuatPhat.Text, cbbDen.Text, dtpNgayBay.Value);
            lblXuatPhat.Text = chuyenbay.XuatPhat;
            lblDen.Text = chuyenbay.Den;
            lblNgayXuatPhat.Text = chuyenbay.NgayBay.ToString("dd/MM/yyyy");
        }

        private void button_Click(object sender, EventArgs e)
        {
            Guna2Button clickedButton = (Guna2Button)sender;
            UCFlight clickedUC = clickedButton.Parent.Parent as UCFlight;

            if (currentlySelectedUC != null && currentlySelectedUC != clickedUC)
            {
                ResetUserControl(currentlySelectedUC);
            }

            currentlySelectedUC = clickedUC;

            HandleUserControlClick(clickedUC, clickedButton);
        }

        private void HandleUserControlClick(UCFlight clickedUC, Guna2Button clickedButton)
        {
            if (clickedButton.Tag == null)
            {
                clickedButton.Tag = 0;
            }

            int buttonClickCount = (int)clickedButton.Tag;
            buttonClickCount++;

            if (buttonClickCount == 2)
            {
                clickedUC.pnBody.FillColor = Color.White;
                buttonClickCount = 0;
                clickedButton.Text = "Chọn vé này";
            }
            else if (buttonClickCount == 1)
            {
                clickedUC.pnBody.FillColor = clickedUC.ColorType();
                clickedButton.Text = "Hủy chọn vé";
            }

            clickedButton.Tag = buttonClickCount;
        }

        private void ResetUserControl(UCFlight uc)
        {
            Guna2Button button = uc.pnBody.Controls.OfType<Guna2Button>().FirstOrDefault();
            if (button != null)
            {
                button.Tag = 0;
                button.Text = "Chọn vé này";
                uc.pnBody.FillColor = Color.White;
            }
        }

        private void btnDiTiep_Click(object sender, EventArgs e)
        {
            FInputInformation fInput = new FInputInformation();
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            FMainPage fInput = new FMainPage();
            this.Hide();
            fInput.Closed += (s, args) => this.Close();
            fInput.Show();
        }
    }
}
