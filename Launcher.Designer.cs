namespace EscapeReality.Launcher
{
    partial class Launcher
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
            this.PlayButton = new System.Windows.Forms.Button();
            this.Title = new System.Windows.Forms.Label();
            this.VersionText = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PlayButton
            // 
            this.PlayButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.PlayButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(252)))), ((int)(((byte)(184)))));
            this.PlayButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(176)))));
            this.PlayButton.FlatAppearance.BorderSize = 2;
            this.PlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.PlayButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PlayButton.Location = new System.Drawing.Point(436, 319);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(244, 50);
            this.PlayButton.TabIndex = 0;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Impact", 75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(16)))), ((int)(((byte)(19)))));
            this.Title.Location = new System.Drawing.Point(256, 63);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(629, 122);
            this.Title.TabIndex = 1;
            this.Title.Text = "EscapeReality";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VersionText
            // 
            this.VersionText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.VersionText.AutoSize = true;
            this.VersionText.Font = new System.Drawing.Font("Impact", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.VersionText.Location = new System.Drawing.Point(968, 486);
            this.VersionText.Name = "VersionText";
            this.VersionText.Size = new System.Drawing.Size(84, 42);
            this.VersionText.TabIndex = 2;
            this.VersionText.Text = "0.0.0";
            this.VersionText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UpdateButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(252)))), ((int)(((byte)(184)))));
            this.UpdateButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(176)))));
            this.UpdateButton.FlatAppearance.BorderSize = 2;
            this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UpdateButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.UpdateButton.Location = new System.Drawing.Point(436, 390);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(244, 50);
            this.UpdateButton.TabIndex = 3;
            this.UpdateButton.Text = "Check For Updates";
            this.UpdateButton.UseVisualStyleBackColor = false;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // Launcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(195)))), ((int)(((byte)(235)))));
            this.ClientSize = new System.Drawing.Size(1064, 537);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.VersionText);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.PlayButton);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(16)))), ((int)(((byte)(19)))));
            this.MinimumSize = new System.Drawing.Size(650, 450);
            this.Name = "Launcher";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EscapeReality Launcher";
            this.Load += new System.EventHandler(this.Launcher_Load);
            this.Resize += new System.EventHandler(this.Launcher_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button PlayButton;
        private Label Title;
        private Label VersionText;
        private Button UpdateButton;
    }
}