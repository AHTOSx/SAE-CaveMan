namespace JeuBibliotheque
{
    partial class PauseDifficile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PauseDifficile));
            this.btnQuitter = new System.Windows.Forms.Button();
            this.btnReprendre = new System.Windows.Forms.Button();
            this.lblMenuPause = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Chocolate;
            this.btnQuitter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnQuitter.BackgroundImage")));
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(330, 247);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(2);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(146, 48);
            this.btnQuitter.TabIndex = 13;
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            // 
            // btnReprendre
            // 
            this.btnReprendre.BackColor = System.Drawing.Color.Chocolate;
            this.btnReprendre.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnReprendre.BackgroundImage")));
            this.btnReprendre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnReprendre.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReprendre.FlatAppearance.BorderSize = 0;
            this.btnReprendre.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReprendre.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReprendre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReprendre.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReprendre.Location = new System.Drawing.Point(330, 182);
            this.btnReprendre.Margin = new System.Windows.Forms.Padding(2);
            this.btnReprendre.Name = "btnReprendre";
            this.btnReprendre.Size = new System.Drawing.Size(146, 50);
            this.btnReprendre.TabIndex = 12;
            this.btnReprendre.UseVisualStyleBackColor = false;
            this.btnReprendre.Click += new System.EventHandler(this.btnReprendre_Click);
            // 
            // lblMenuPause
            // 
            this.lblMenuPause.AutoSize = true;
            this.lblMenuPause.BackColor = System.Drawing.Color.Transparent;
            this.lblMenuPause.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblMenuPause.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMenuPause.Image = ((System.Drawing.Image)(resources.GetObject("lblMenuPause.Image")));
            this.lblMenuPause.Location = new System.Drawing.Point(355, 109);
            this.lblMenuPause.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMenuPause.Name = "lblMenuPause";
            this.lblMenuPause.Size = new System.Drawing.Size(94, 19);
            this.lblMenuPause.TabIndex = 11;
            this.lblMenuPause.Text = "Menu Pause";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(235, 87);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 276);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // PauseDifficile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::JeuBibliotheque.Properties.Resources.Screenshot_2024_04_14_151646;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnReprendre);
            this.Controls.Add(this.lblMenuPause);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Name = "PauseDifficile";
            this.Text = "PauseDifficile";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnQuitter;
        private System.Windows.Forms.Button btnReprendre;
        private System.Windows.Forms.Label lblMenuPause;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}