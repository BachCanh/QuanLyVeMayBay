namespace QuanLyVeMayBay
{
    partial class UCSA
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnHLview = new Guna.UI2.WinForms.Guna2Panel();
            lblTen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            lblGia = new Guna.UI2.WinForms.Guna2HtmlLabel();
            pnHLview.SuspendLayout();
            SuspendLayout();
            // 
            // pnHLview
            // 
            pnHLview.Controls.Add(lblTen);
            pnHLview.Controls.Add(lblGia);
            pnHLview.CustomizableEdges = customizableEdges3;
            pnHLview.Dock = DockStyle.Fill;
            pnHLview.Location = new Point(0, 0);
            pnHLview.Name = "pnHLview";
            pnHLview.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnHLview.Size = new Size(361, 40);
            pnHLview.TabIndex = 2;
            // 
            // lblTen
            // 
            lblTen.AutoSize = false;
            lblTen.BackColor = Color.Transparent;
            lblTen.Dock = DockStyle.Left;
            lblTen.Location = new Point(0, 0);
            lblTen.Name = "lblTen";
            lblTen.Size = new Size(262, 40);
            lblTen.TabIndex = 1;
            lblTen.Text = "100,000 VND";
            lblTen.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // lblGia
            // 
            lblGia.AutoSize = false;
            lblGia.BackColor = Color.Transparent;
            lblGia.Dock = DockStyle.Right;
            lblGia.Location = new Point(268, 0);
            lblGia.Name = "lblGia";
            lblGia.Size = new Size(93, 40);
            lblGia.TabIndex = 0;
            lblGia.Text = "100,000 VND";
            lblGia.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // UCSA
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnHLview);
            Name = "UCSA";
            Size = new Size(361, 40);
            pnHLview.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2Panel pnHLview;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblTen;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblGia;
    }
}
