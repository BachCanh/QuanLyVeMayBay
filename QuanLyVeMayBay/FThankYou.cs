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
    public partial class FThankYou : Form
    {
        public FThankYou()
        {
            InitializeComponent();
            CountDown();
        }

        private async void CountDown()
        {
            for (int i = 10; i >= 0; i--)
            {
                lblCount.Text = "Tro lai trang chu sau:   " + i;
                await Task.Delay(1000); // Delay for 1 second (1000 milliseconds)
            }
            this.Hide();
            FMainPage fMainPage = new FMainPage();
            fMainPage.Show();
        }

        private void btnXong_Click(object sender, EventArgs e)
        {
            this.Close();
            FMainPage fMainPage = new FMainPage();
            fMainPage.Show();
        }
    }
}
