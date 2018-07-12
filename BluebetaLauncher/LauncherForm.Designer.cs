namespace BluebetaLauncher
{
    partial class LauncherForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.modpackCombobox = new System.Windows.Forms.ComboBox();
            this.versionCombobox = new System.Windows.Forms.ComboBox();
            this.loginButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.emailBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buildnumberlabel = new System.Windows.Forms.Label();
            this.ramCombobox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rememberBox = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modpack:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(394, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Version:";
            // 
            // modpackCombobox
            // 
            this.modpackCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modpackCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.modpackCombobox.FormattingEnabled = true;
            this.modpackCombobox.Location = new System.Drawing.Point(120, 17);
            this.modpackCombobox.Name = "modpackCombobox";
            this.modpackCombobox.Size = new System.Drawing.Size(250, 33);
            this.modpackCombobox.TabIndex = 2;
            this.modpackCombobox.SelectedIndexChanged += new System.EventHandler(this.refreshVersionCombobox);
            // 
            // versionCombobox
            // 
            this.versionCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.versionCombobox.FormattingEnabled = true;
            this.versionCombobox.Location = new System.Drawing.Point(485, 17);
            this.versionCombobox.Name = "versionCombobox";
            this.versionCombobox.Size = new System.Drawing.Size(121, 33);
            this.versionCombobox.TabIndex = 3;
            this.versionCombobox.SelectedIndexChanged += new System.EventHandler(this.versionCombobox_SelectedIndexChanged);
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(764, 7);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(121, 38);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Email:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(411, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // emailBox
            // 
            this.emailBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailBox.Location = new System.Drawing.Point(86, 11);
            this.emailBox.Name = "emailBox";
            this.emailBox.Size = new System.Drawing.Size(319, 30);
            this.emailBox.TabIndex = 7;
            this.emailBox.TextChanged += new System.EventHandler(this.emailBox_TextChanged);
            // 
            // passwordBox
            // 
            this.passwordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordBox.Location = new System.Drawing.Point(521, 12);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(237, 30);
            this.passwordBox.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buildnumberlabel);
            this.panel1.Controls.Add(this.ramCombobox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.modpackCombobox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.versionCombobox);
            this.panel1.Location = new System.Drawing.Point(-3, -8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(975, 58);
            this.panel1.TabIndex = 10;
            // 
            // buildnumberlabel
            // 
            this.buildnumberlabel.AutoSize = true;
            this.buildnumberlabel.Location = new System.Drawing.Point(875, 37);
            this.buildnumberlabel.Name = "buildnumberlabel";
            this.buildnumberlabel.Size = new System.Drawing.Size(95, 13);
            this.buildnumberlabel.TabIndex = 6;
            this.buildnumberlabel.Text = "V. 2.0.5555.55555";
            this.buildnumberlabel.Click += new System.EventHandler(this.buildnumberlabel_Click);
            // 
            // ramCombobox
            // 
            this.ramCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ramCombobox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ramCombobox.FormattingEnabled = true;
            this.ramCombobox.Items.AddRange(new object[] {
            "2",
            "4",
            "6",
            "8"});
            this.ramCombobox.Location = new System.Drawing.Point(769, 17);
            this.ramCombobox.Name = "ramCombobox";
            this.ramCombobox.Size = new System.Drawing.Size(100, 33);
            this.ramCombobox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(633, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "RAM (In GB):";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.rememberBox);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.emailBox);
            this.panel2.Controls.Add(this.loginButton);
            this.panel2.Controls.Add(this.passwordBox);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(-3, 436);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(975, 61);
            this.panel2.TabIndex = 11;
            // 
            // rememberBox
            // 
            this.rememberBox.AutoSize = true;
            this.rememberBox.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this.rememberBox.Location = new System.Drawing.Point(890, 11);
            this.rememberBox.Name = "rememberBox";
            this.rememberBox.Size = new System.Drawing.Size(80, 31);
            this.rememberBox.TabIndex = 9;
            this.rememberBox.Text = "Remember Me";
            this.rememberBox.UseVisualStyleBackColor = true;
            this.rememberBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BluebetaLauncher.Properties.Resources._2018_07_12_13_58_29;
            this.pictureBox1.Location = new System.Drawing.Point(-3, -14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(975, 511);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LauncherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 491);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LauncherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bluebeta Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox modpackCombobox;
        private System.Windows.Forms.ComboBox versionCombobox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox emailBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox ramCombobox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox rememberBox;
        private System.Windows.Forms.Label buildnumberlabel;
    }
}

