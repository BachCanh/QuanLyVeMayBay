namespace QuanLyVeMayBay
{
    partial class FLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lblConnect = new ReaLTaiizor.Controls.ParrotButton();
            lblCancel = new ReaLTaiizor.Controls.ParrotButton();
            txtUsername = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            txtPassword = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            cbbDatabase = new ReaLTaiizor.Controls.DungeonComboBox();
            lblUsername = new Label();
            lblPassword = new Label();
            lblDatabase = new Label();
            guna2Elipse3 = new Guna.UI2.WinForms.Guna2Elipse(components);
            guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
            nightControlBox1 = new ReaLTaiizor.Controls.NightControlBox();
            guna2Panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblConnect
            // 
            lblConnect.BackgroundColor = Color.FromArgb(192, 192, 255);
            lblConnect.ButtonImage = null;
            lblConnect.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            lblConnect.ButtonText = "Connect";
            lblConnect.ClickBackColor = Color.FromArgb(128, 128, 255);
            lblConnect.ClickTextColor = Color.SlateGray;
            lblConnect.CornerRadius = 8;
            lblConnect.Cursor = Cursors.Hand;
            lblConnect.Font = new Font("Roboto", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblConnect.Horizontal_Alignment = StringAlignment.Center;
            lblConnect.HoverBackgroundColor = Color.FromArgb(255, 192, 255);
            lblConnect.HoverTextColor = Color.SlateGray;
            lblConnect.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            lblConnect.Location = new Point(123, 310);
            lblConnect.Name = "lblConnect";
            lblConnect.Size = new Size(113, 42);
            lblConnect.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            lblConnect.TabIndex = 2;
            lblConnect.TextColor = Color.Black;
            lblConnect.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            lblConnect.Vertical_Alignment = StringAlignment.Center;
            lblConnect.Click += lblConnect_Click;
            // 
            // lblCancel
            // 
            lblCancel.BackgroundColor = Color.FromArgb(192, 192, 255);
            lblCancel.ButtonImage = null;
            lblCancel.ButtonStyle = ReaLTaiizor.Controls.ParrotButton.Style.MaterialRounded;
            lblCancel.ButtonText = "Cancel";
            lblCancel.ClickBackColor = Color.FromArgb(128, 128, 255);
            lblCancel.ClickTextColor = Color.SlateGray;
            lblCancel.CornerRadius = 8;
            lblCancel.Cursor = Cursors.Hand;
            lblCancel.Font = new Font("Roboto", 16F, FontStyle.Bold, GraphicsUnit.Pixel);
            lblCancel.Horizontal_Alignment = StringAlignment.Center;
            lblCancel.HoverBackgroundColor = Color.FromArgb(255, 192, 255);
            lblCancel.HoverTextColor = Color.SlateGray;
            lblCancel.ImagePosition = ReaLTaiizor.Controls.ParrotButton.ImgPosition.Left;
            lblCancel.Location = new Point(383, 310);
            lblCancel.Name = "lblCancel";
            lblCancel.Size = new Size(113, 42);
            lblCancel.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            lblCancel.TabIndex = 2;
            lblCancel.TextColor = Color.Black;
            lblCancel.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            lblCancel.Vertical_Alignment = StringAlignment.Center;
            lblCancel.Click += parrotButton1_Click;
            // 
            // txtUsername
            // 
            txtUsername.AllowPromptAsInput = true;
            txtUsername.AnimateReadOnly = false;
            txtUsername.AsciiOnly = false;
            txtUsername.BackgroundImageLayout = ImageLayout.None;
            txtUsername.BeepOnError = false;
            txtUsername.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtUsername.Depth = 0;
            txtUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtUsername.HidePromptOnLeave = false;
            txtUsername.HideSelection = true;
            txtUsername.Hint = "Enter Username";
            txtUsername.InsertKeyMode = InsertKeyMode.Default;
            txtUsername.LeadingIcon = null;
            txtUsername.Location = new Point(246, 128);
            txtUsername.Mask = "";
            txtUsername.MaxLength = 32767;
            txtUsername.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtUsername.Name = "txtUsername";
            txtUsername.PasswordChar = '\0';
            txtUsername.PrefixSuffixText = null;
            txtUsername.PromptChar = '_';
            txtUsername.ReadOnly = false;
            txtUsername.RejectInputOnFirstFailure = false;
            txtUsername.ResetOnPrompt = true;
            txtUsername.ResetOnSpace = true;
            txtUsername.RightToLeft = RightToLeft.No;
            txtUsername.SelectedText = "";
            txtUsername.SelectionLength = 0;
            txtUsername.SelectionStart = 0;
            txtUsername.ShortcutsEnabled = true;
            txtUsername.Size = new Size(250, 48);
            txtUsername.SkipLiterals = true;
            txtUsername.TabIndex = 3;
            txtUsername.TabStop = false;
            txtUsername.TextAlign = HorizontalAlignment.Left;
            txtUsername.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtUsername.TrailingIcon = null;
            txtUsername.UseSystemPasswordChar = false;
            txtUsername.ValidatingType = null;
            // 
            // txtPassword
            // 
            txtPassword.AllowPromptAsInput = true;
            txtPassword.AnimateReadOnly = false;
            txtPassword.AsciiOnly = false;
            txtPassword.BackgroundImageLayout = ImageLayout.None;
            txtPassword.BeepOnError = false;
            txtPassword.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            txtPassword.Depth = 0;
            txtPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            txtPassword.HidePromptOnLeave = false;
            txtPassword.HideSelection = true;
            txtPassword.Hint = "Enter Password";
            txtPassword.InsertKeyMode = InsertKeyMode.Default;
            txtPassword.LeadingIcon = null;
            txtPassword.Location = new Point(246, 215);
            txtPassword.Mask = "";
            txtPassword.MaxLength = 32767;
            txtPassword.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.PrefixSuffixText = null;
            txtPassword.PromptChar = '_';
            txtPassword.ReadOnly = false;
            txtPassword.RejectInputOnFirstFailure = false;
            txtPassword.ResetOnPrompt = true;
            txtPassword.ResetOnSpace = true;
            txtPassword.RightToLeft = RightToLeft.No;
            txtPassword.SelectedText = "";
            txtPassword.SelectionLength = 0;
            txtPassword.SelectionStart = 0;
            txtPassword.ShortcutsEnabled = true;
            txtPassword.Size = new Size(250, 48);
            txtPassword.SkipLiterals = true;
            txtPassword.TabIndex = 4;
            txtPassword.TabStop = false;
            txtPassword.TextAlign = HorizontalAlignment.Left;
            txtPassword.TextMaskFormat = MaskFormat.IncludeLiterals;
            txtPassword.TrailingIcon = null;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.ValidatingType = null;
            // 
            // cbbDatabase
            // 
            cbbDatabase.BackColor = Color.Silver;
            cbbDatabase.ColorA = Color.FromArgb(246, 132, 85);
            cbbDatabase.ColorB = Color.FromArgb(231, 108, 57);
            cbbDatabase.ColorC = Color.FromArgb(242, 241, 240);
            cbbDatabase.ColorD = Color.FromArgb(253, 252, 252);
            cbbDatabase.ColorE = Color.FromArgb(239, 237, 236);
            cbbDatabase.ColorF = Color.FromArgb(180, 180, 180);
            cbbDatabase.ColorG = Color.FromArgb(119, 119, 118);
            cbbDatabase.ColorH = Color.FromArgb(224, 222, 220);
            cbbDatabase.ColorI = Color.FromArgb(250, 249, 249);
            cbbDatabase.DrawMode = DrawMode.OwnerDrawFixed;
            cbbDatabase.DropDownHeight = 100;
            cbbDatabase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDatabase.Font = new Font("Segoe UI", 10F);
            cbbDatabase.ForeColor = Color.FromArgb(76, 76, 97);
            cbbDatabase.FormattingEnabled = true;
            cbbDatabase.HoverSelectionColor = Color.FromArgb(255, 192, 255);
            cbbDatabase.IntegralHeight = false;
            cbbDatabase.ItemHeight = 16;
            cbbDatabase.Location = new Point(246, 59);
            cbbDatabase.Name = "cbbDatabase";
            cbbDatabase.Size = new Size(250, 22);
            cbbDatabase.StartIndex = 0;
            cbbDatabase.TabIndex = 5;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblUsername.Location = new Point(123, 144);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(84, 19);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblPassword.Location = new Point(123, 228);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(83, 19);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Password:";
            // 
            // lblDatabase
            // 
            lblDatabase.AutoSize = true;
            lblDatabase.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            lblDatabase.Location = new Point(123, 66);
            lblDatabase.Name = "lblDatabase";
            lblDatabase.Size = new Size(81, 19);
            lblDatabase.TabIndex = 1;
            lblDatabase.Text = "Database:";
            // 
            // guna2Elipse3
            // 
            guna2Elipse3.BorderRadius = 30;
            guna2Elipse3.TargetControl = this;
            // 
            // guna2Panel1
            // 
            guna2Panel1.Controls.Add(nightControlBox1);
            guna2Panel1.CustomizableEdges = customizableEdges3;
            guna2Panel1.Dock = DockStyle.Top;
            guna2Panel1.FillColor = Color.White;
            guna2Panel1.Location = new Point(0, 0);
            guna2Panel1.Name = "guna2Panel1";
            guna2Panel1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel1.Size = new Size(636, 31);
            guna2Panel1.TabIndex = 9;
            // 
            // nightControlBox1
            // 
            nightControlBox1.BackColor = Color.Transparent;
            nightControlBox1.CloseHoverColor = Color.FromArgb(199, 80, 80);
            nightControlBox1.CloseHoverForeColor = Color.White;
            nightControlBox1.DefaultLocation = true;
            nightControlBox1.DisableMaximizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.DisableMinimizeColor = Color.FromArgb(105, 105, 105);
            nightControlBox1.Dock = DockStyle.Right;
            nightControlBox1.EnableCloseColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMaximizeButton = true;
            nightControlBox1.EnableMaximizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.EnableMinimizeButton = true;
            nightControlBox1.EnableMinimizeColor = Color.FromArgb(160, 160, 160);
            nightControlBox1.Location = new Point(497, 0);
            nightControlBox1.MaximizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MaximizeHoverForeColor = Color.White;
            nightControlBox1.MinimizeHoverColor = Color.FromArgb(15, 255, 255, 255);
            nightControlBox1.MinimizeHoverForeColor = Color.White;
            nightControlBox1.Name = "nightControlBox1";
            nightControlBox1.Size = new Size(139, 31);
            nightControlBox1.TabIndex = 6;
            // 
            // FLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.MistyRose;
            ClientSize = new Size(636, 376);
            Controls.Add(guna2Panel1);
            Controls.Add(cbbDatabase);
            Controls.Add(txtPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblCancel);
            Controls.Add(lblConnect);
            Controls.Add(lblDatabase);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += FLogin_Load;
            guna2Panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ReaLTaiizor.Controls.ParrotButton lblConnect;
        private ReaLTaiizor.Controls.ParrotButton lblCancel;
        private ReaLTaiizor.Controls.MaterialMaskedTextBox txtUsername;
        private ReaLTaiizor.Controls.MaterialMaskedTextBox txtPassword;
        private ReaLTaiizor.Controls.DungeonComboBox cbbDatabase;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblDatabase;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse3;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
        private ReaLTaiizor.Controls.NightControlBox nightControlBox1;
    }
}
