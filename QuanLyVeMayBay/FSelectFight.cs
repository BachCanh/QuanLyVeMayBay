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
        DBConnection db;
        private List<UCFlight> userControls = new List<UCFlight>();
        VeMayBay ve = new VeMayBay();
        private UCFlight currentlySelectedUC;
        private LoaiVe lv = new LoaiVe();
        public FSelectFight(DBConnection db, ChuyenBay chuyenBay)
        {
            InitializeComponent();
            this.chuyenbay = chuyenBay;
            this.db = db;
            GetChuyenBay();
            FillInfor();
            SetEventClick();
            
        }

        private void SetEventClick()
        {
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
            lblTotalResults.Text = flpBodyContent.Controls.Count.ToString();
        }

        private void GetChuyenBay()
        {
            flpBodyContent.Controls.Clear();
            foreach(ChuyenBay cb in db.GetAllChuyenBay(chuyenbay))
            {
                UCFlight uc = new UCFlight(cb, db);
                flpBodyContent.Controls.Add(uc);
                flpBodyContent.Height += 115;
            }
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
            GetChuyenBay();
            FillInfor();
            SetEventClick();
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
            ucSubBody.FillGia(chuyenbay, lv);
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
                lv = new LoaiVe();
                chuyenbay = new ChuyenBay();
                lblTongTien.Text = lv.Gia.ToString("N0") + " VND";
            }
            else if (buttonClickCount == 1)
            {
                clickedUC.pnBody.FillColor = Color.MistyRose;
                clickedButton.Text = "Hủy chọn vé";
                chuyenbay = currentlySelectedUC.CBay;
                lv = currentlySelectedUC.lv;
                lblTongTien.Text = lv.Gia.ToString("N0") + " VND";
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
            FInputInformation fInput = new FInputInformation(db, chuyenbay, lv);
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
