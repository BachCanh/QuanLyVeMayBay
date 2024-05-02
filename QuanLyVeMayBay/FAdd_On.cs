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
    public partial class FAdd_On : Form
    {
        private Guna2Button selectedBtn;
        private DBConnection db;
        private SuatAn sa = new SuatAn();
        private HanhLy hl = new HanhLy();

        public FAdd_On(DBConnection db)
        {
            InitializeComponent();
            this.db = db;

            btnKyGui.Click += btnClick;
            btnSuatAn.Click += btnClick;
        }
        private void btnClick(object sender, EventArgs e)
        {
            Guna2Button clickedBtn = (Guna2Button)sender;

            if (clickedBtn == selectedBtn)
            {
                return;
            }

            if (selectedBtn != null)
            {
                selectedBtn.FillColor = Color.FromArgb(255, 179, 198);
                selectedBtn.Enabled = true;
            }

            clickedBtn.FillColor = Color.FromArgb(255, 143, 171);

            selectedBtn = clickedBtn;
            FAdd_On_Load(sender, e);
        }

        private void FAdd_On_Load(object sender, EventArgs e)
        {
            if (selectedBtn == btnSuatAn)
            {
                dtBody.DataSource = db.GetAllSuatAnDt();
            }
            else if (selectedBtn == btnKyGui)
            {
                dtBody.DataSource = db.GetAllHanhLyDt();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (selectedBtn == btnSuatAn)
            {
                FAddSA fAddSA = new FAddSA(db, sa);
                fAddSA.Show();
            }
            else if (selectedBtn == btnKyGui)
            {
                FAddHL fAddHL = new FAddHL(db, hl);
                fAddHL.Show();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            FAdd_On_Load(sender, e);
        }

        private void dtBody_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dtBody.Rows[e.RowIndex];

                if (selectedRow != null)
                {
                    if (selectedBtn == btnSuatAn)
                    {
                        dtBody.CurrentRow.Selected = true;
                        string maSA = selectedRow.Cells[0].Value.ToString().Trim();
                        string ten = selectedRow.Cells[1].Value.ToString().Trim();
                        decimal gia = (decimal)selectedRow.Cells[2].Value;
                        object img = selectedRow.Cells[3].Value;
                        Image hinhMH;
                        if (img != DBNull.Value && img != null)
                        {
                            hinhMH = db.ByteArrayToImage((byte[])img);
                            sa = new SuatAn(maSA, ten, gia, hinhMH);
                        }
                        else sa = new SuatAn(maSA, ten, gia);
                    }
                    else if (selectedBtn == btnKyGui)
                    {
                        dtBody.CurrentRow.Selected = true;
                        object maHL = selectedRow.Cells[0].Value.ToString().Trim();
                        object cannang = selectedRow.Cells[1].Value.ToString().Trim();
                        object gia = selectedRow.Cells[2].Value.ToString().Trim();
                        hl = new HanhLy(maHL, cannang, gia);
                    }
                    else
                    {
                        MessageBox.Show("Please what you want to do!");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (sa.TenSA != null && sa.Gia != 0 && selectedBtn == btnSuatAn)
            {
                FAddSA fAddSA = new FAddSA(db, sa);
                fAddSA.Show();
            }
            else if (hl.Gia != null && hl.Cannang != null && selectedBtn == btnKyGui)
            {
                FAddHL fAddHL = new FAddHL(db, hl);
                fAddHL.Show();
            }
            else
            {
                MessageBox.Show("Please choose a row to Update");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (sa.TenSA != null && sa.Gia != 0 && selectedBtn == btnSuatAn)
            {
                db.XoaSuatAn(sa.MaSA);
            }
            else if (hl.Gia != null && hl.Cannang != null && selectedBtn == btnKyGui)
            {
                db.XoaHanhLy(hl.MaHL);
            }
            else
            {
                MessageBox.Show("Please choose a row to Delete");
            }
        }

    }
}
