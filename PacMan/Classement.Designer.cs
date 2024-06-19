namespace PacMan
{
    partial class Classement
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnretour = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = global::PacMan.Properties.Resources.Screenshot_2024_04_02_151300_removebg_preview;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(162, 77);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 353);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // btnretour
            // 
            this.btnretour.BackColor = System.Drawing.Color.Transparent;
            this.btnretour.BackgroundImage = global::PacMan.Properties.Resources.Capture_d_ecran_2024_04_02_103459_removebg_preview_cleanup1;
            this.btnretour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnretour.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatAppearance.BorderSize = 0;
            this.btnretour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnretour.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnretour.Location = new System.Drawing.Point(2, -1);
            this.btnretour.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnretour.Name = "btnretour";
            this.btnretour.Size = new System.Drawing.Size(116, 63);
            this.btnretour.TabIndex = 1;
            this.btnretour.Text = "Retour";
            this.btnretour.UseVisualStyleBackColor = false;
            this.btnretour.Click += new System.EventHandler(this.button1_Click);
            this.btnretour.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnretour.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Chocolate;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Classement";
            // 
            // Classement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PacMan.Properties.Resources.Screenshot_2024_04_14_151646;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 517);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnretour);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Classement";
            this.Text = "Classement";
            this.Load += new System.EventHandler(this.Classement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnretour;
        private System.Windows.Forms.Label label1;
    }
}