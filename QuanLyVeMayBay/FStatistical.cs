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
    public partial class FStatistical : Form
    {
        private List<Tuple<string, float, Color>> data = new List<Tuple<string, float, Color>>
        {
            Tuple.Create("Category 1", 30f, Color.Red),
            Tuple.Create("Category 2", 20f, Color.Blue),
            Tuple.Create("Category 3", 25f, Color.Green),
            Tuple.Create("Category 4", 15f, Color.Yellow),
            Tuple.Create("Category 5", 5f, Color.Orange),
            Tuple.Create("Category 6", 5f, Color.Orange)
        };
        DBConnection db;
        public FStatistical(DBConnection db)
        {
            InitializeComponent();
            this.db = db;
        }
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            //DrawPieChart(e.Graphics)/*;*/
        }

        //private void DrawPieChart(Graphics g)
        //{
        //    // Define the center and radius of the pie chart
        //    Point center = new Point(panel1.Width / 2, panel1.Height / 2);
        //    int radius = Math.Min(panel1.Width, panel1.Height) / 3;

        //    // Calculate total value
        //    float total = 0;
        //    foreach (var item in data)
        //    {
        //        total += item.Item2;
        //    }

        //    // Draw pie chart
        //    float startAngle = 0;
        //    foreach (var item in data)
        //    {
        //        float sweepAngle = item.Item2 / total * 360;
        //        using (Brush brush = new SolidBrush(item.Item3))
        //        {
        //            g.FillPie(brush, center.X - radius, center.Y - radius, 2 * radius, 2 * radius, startAngle, sweepAngle);
        //        }

        //        // Calculate the midpoint angle of the current slice
        //        float midAngle = startAngle + sweepAngle / 2;

        //        // Calculate the position for the label
        //        float labelX = (float)(center.X + radius * Math.Cos(midAngle * Math.PI / 180));
        //        float labelY = (float)(center.Y + radius * Math.Sin(midAngle * Math.PI / 180));

        //        // Format the label text
        //        string labelText = $"{item.Item1}: {item.Item2 / total * 100:F2}%";

        //        // Draw the label
        //        g.DrawString(labelText, this.Font, Brushes.Black, labelX, labelY, new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });

        //        startAngle += sweepAngle;
        //    }
        //}

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.GetAllFlightPassengerCount();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerSuatAn();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerHanhLy();
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            dtBody.DataSource = db.FlightPassengerTotal();
        }
    }
}
