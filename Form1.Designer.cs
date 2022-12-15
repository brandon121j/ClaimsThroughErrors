
namespace ClaimsThroughErrors
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.claimsTB = new System.Windows.Forms.TextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.eligibilityPanel = new System.Windows.Forms.Panel();
            this.claimsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.eligibilityTB = new System.Windows.Forms.TextBox();
            this.exitBtn = new System.Windows.Forms.Button();
            this.minimizeBtn = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.claimsIMG = new System.Windows.Forms.PictureBox();
            this.eligibilityIMG = new System.Windows.Forms.PictureBox();
            this.spinnerBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimsIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eligibilityIMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).BeginInit();
            this.SuspendLayout();
            // 
            // claimsTB
            // 
            this.claimsTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.claimsTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.claimsTB.Cursor = System.Windows.Forms.Cursors.Default;
            this.claimsTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.claimsTB.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.claimsTB.Location = new System.Drawing.Point(72, 264);
            this.claimsTB.Name = "claimsTB";
            this.claimsTB.Size = new System.Drawing.Size(209, 19);
            this.claimsTB.TabIndex = 0;
            this.claimsTB.TabStop = false;
            this.claimsTB.Text = "Claims Through";
            this.claimsTB.Click += new System.EventHandler(this.ClaimsTB_Click);
            this.claimsTB.TextChanged += new System.EventHandler(this.ClaimsTB_TextChanged);
            this.claimsTB.Validating += new System.ComponentModel.CancelEventHandler(this.ClaimsTB_Validating);
            // 
            // submitButton
            // 
            this.submitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.submitButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.submitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.submitButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.submitButton.Location = new System.Drawing.Point(31, 423);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(265, 46);
            this.submitButton.TabIndex = 4;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = false;
            this.submitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            this.submitButton.MouseEnter += new System.EventHandler(this.SubmitButton_MouseEnter);
            this.submitButton.MouseLeave += new System.EventHandler(this.SubmitButton_MouseLeave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // eligibilityPanel
            // 
            this.eligibilityPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.eligibilityPanel.Location = new System.Drawing.Point(72, 365);
            this.eligibilityPanel.Name = "eligibilityPanel";
            this.eligibilityPanel.Size = new System.Drawing.Size(224, 1);
            this.eligibilityPanel.TabIndex = 7;
            // 
            // claimsPanel
            // 
            this.claimsPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.claimsPanel.Location = new System.Drawing.Point(72, 285);
            this.claimsPanel.Name = "claimsPanel";
            this.claimsPanel.Size = new System.Drawing.Size(224, 1);
            this.claimsPanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label1.Location = new System.Drawing.Point(78, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Claims Error Generator";
            // 
            // eligibilityTB
            // 
            this.eligibilityTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.eligibilityTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.eligibilityTB.Cursor = System.Windows.Forms.Cursors.Default;
            this.eligibilityTB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eligibilityTB.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.eligibilityTB.Location = new System.Drawing.Point(72, 344);
            this.eligibilityTB.Name = "eligibilityTB";
            this.eligibilityTB.Size = new System.Drawing.Size(209, 19);
            this.eligibilityTB.TabIndex = 13;
            this.eligibilityTB.TabStop = false;
            this.eligibilityTB.Text = "Eligibility Highmark";
            this.eligibilityTB.Click += new System.EventHandler(this.EligibilityTB_Click_1);
            this.eligibilityTB.TextChanged += new System.EventHandler(this.EligibilityTB_TextChanged);
            // 
            // exitBtn
            // 
            this.exitBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exitBtn.FlatAppearance.BorderSize = 0;
            this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.exitBtn.Location = new System.Drawing.Point(299, 2);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(25, 25);
            this.exitBtn.TabIndex = 14;
            this.exitBtn.Text = "X";
            this.exitBtn.UseVisualStyleBackColor = true;
            this.exitBtn.Click += new System.EventHandler(this.ExitBtn_Click);
            this.exitBtn.MouseEnter += new System.EventHandler(this.ExitBtn_MouseEnter);
            this.exitBtn.MouseLeave += new System.EventHandler(this.ExitBtn_MouseLeave);
            // 
            // minimizeBtn
            // 
            this.minimizeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.minimizeBtn.FlatAppearance.BorderSize = 0;
            this.minimizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.minimizeBtn.Location = new System.Drawing.Point(271, 2);
            this.minimizeBtn.Name = "minimizeBtn";
            this.minimizeBtn.Size = new System.Drawing.Size(25, 25);
            this.minimizeBtn.TabIndex = 15;
            this.minimizeBtn.TabStop = false;
            this.minimizeBtn.Text = "_";
            this.minimizeBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.minimizeBtn.UseVisualStyleBackColor = true;
            this.minimizeBtn.Click += new System.EventHandler(this.MinimizeBtn_Click);
            this.minimizeBtn.MouseEnter += new System.EventHandler(this.MinimizeBtn_MouseEnter);
            this.minimizeBtn.MouseLeave += new System.EventHandler(this.MinimizeBtn_MouseLeave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::ClaimsThroughErrors.Properties.Resources.excel_100Blue;
            this.pictureBox3.Location = new System.Drawing.Point(113, 92);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(100, 100);
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // claimsIMG
            // 
            this.claimsIMG.BackgroundImage = global::ClaimsThroughErrors.Properties.Resources.import_csv35;
            this.claimsIMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.claimsIMG.Location = new System.Drawing.Point(31, 251);
            this.claimsIMG.Name = "claimsIMG";
            this.claimsIMG.Size = new System.Drawing.Size(35, 35);
            this.claimsIMG.TabIndex = 10;
            this.claimsIMG.TabStop = false;
            this.claimsIMG.Click += new System.EventHandler(this.ClaimsIMG_Click);
            // 
            // eligibilityIMG
            // 
            this.eligibilityIMG.BackgroundImage = global::ClaimsThroughErrors.Properties.Resources.import_csv35;
            this.eligibilityIMG.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eligibilityIMG.Location = new System.Drawing.Point(31, 331);
            this.eligibilityIMG.Name = "eligibilityIMG";
            this.eligibilityIMG.Size = new System.Drawing.Size(35, 35);
            this.eligibilityIMG.TabIndex = 9;
            this.eligibilityIMG.TabStop = false;
            this.eligibilityIMG.Click += new System.EventHandler(this.EligibilityIMG_Click);
            // 
            // spinnerBox
            // 
            this.spinnerBox.Image = global::ClaimsThroughErrors.Properties.Resources.spinner100;
            this.spinnerBox.InitialImage = null;
            this.spinnerBox.Location = new System.Drawing.Point(113, 92);
            this.spinnerBox.Name = "spinnerBox";
            this.spinnerBox.Size = new System.Drawing.Size(100, 100);
            this.spinnerBox.TabIndex = 16;
            this.spinnerBox.TabStop = false;
            this.spinnerBox.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(326, 490);
            this.Controls.Add(this.minimizeBtn);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.eligibilityTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.claimsIMG);
            this.Controls.Add(this.eligibilityIMG);
            this.Controls.Add(this.claimsPanel);
            this.Controls.Add(this.eligibilityPanel);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.claimsTB);
            this.Controls.Add(this.spinnerBox);
            this.Controls.Add(this.pictureBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Claims Through Errors ";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.claimsIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eligibilityIMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinnerBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox claimsTB;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.PictureBox eligibilityIMG;
        private System.Windows.Forms.Panel claimsPanel;
        private System.Windows.Forms.Panel eligibilityPanel;
        private System.Windows.Forms.PictureBox claimsIMG;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox eligibilityTB;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.Button minimizeBtn;
        private System.Windows.Forms.PictureBox spinnerBox;
    }
}

