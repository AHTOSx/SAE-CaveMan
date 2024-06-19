namespace PacMan
{
    partial class Menu
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
            this.pctboxCaveman = new System.Windows.Forms.PictureBox();
            this.btnNouvellepartie = new System.Windows.Forms.Button();
            this.btnClassement = new System.Windows.Forms.Button();
            this.btnQuitter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pctboxCaveman)).BeginInit();
            this.SuspendLayout();
            // 
            // pctboxCaveman
            // 
            this.pctboxCaveman.BackColor = System.Drawing.Color.Transparent;
            this.pctboxCaveman.BackgroundImage = global::PacMan.Properties.Resources.caveman;
            this.pctboxCaveman.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pctboxCaveman.Location = new System.Drawing.Point(176, 36);
            this.pctboxCaveman.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pctboxCaveman.Name = "pctboxCaveman";
            this.pctboxCaveman.Size = new System.Drawing.Size(349, 96);
            this.pctboxCaveman.TabIndex = 0;
            this.pctboxCaveman.TabStop = false;
            // 
            // btnNouvellepartie
            // 
            this.btnNouvellepartie.BackColor = System.Drawing.Color.Transparent;
            this.btnNouvellepartie.BackgroundImage = global::PacMan.Properties.Resources.Capture_d_ecran_2024_04_02_103459_removebg_preview_cleanup;
            this.btnNouvellepartie.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNouvellepartie.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNouvellepartie.FlatAppearance.BorderSize = 0;
            this.btnNouvellepartie.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNouvellepartie.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnNouvellepartie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouvellepartie.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouvellepartie.Location = new System.Drawing.Point(264, 186);
            this.btnNouvellepartie.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNouvellepartie.Name = "btnNouvellepartie";
            this.btnNouvellepartie.Size = new System.Drawing.Size(192, 96);
            this.btnNouvellepartie.TabIndex = 1;
            this.btnNouvellepartie.Text = "Nouvelle partie";
            this.btnNouvellepartie.UseVisualStyleBackColor = false;
            this.btnNouvellepartie.Click += new System.EventHandler(this.btnNouvellepartie_Click);
            this.btnNouvellepartie.MouseEnter += new System.EventHandler(this.btnNouvellepartie_MouseEnter);
            this.btnNouvellepartie.MouseLeave += new System.EventHandler(this.btnNouvellepartie_MouseLeave);
            // 
            // btnClassement
            // 
            this.btnClassement.BackColor = System.Drawing.Color.Transparent;
            this.btnClassement.BackgroundImage = global::PacMan.Properties.Resources.Capture_d_ecran_2024_04_02_103459_removebg_preview_cleanup;
            this.btnClassement.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnClassement.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClassement.FlatAppearance.BorderSize = 0;
            this.btnClassement.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClassement.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnClassement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClassement.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClassement.Location = new System.Drawing.Point(264, 262);
            this.btnClassement.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnClassement.Name = "btnClassement";
            this.btnClassement.Size = new System.Drawing.Size(192, 96);
            this.btnClassement.TabIndex = 2;
            this.btnClassement.Text = "Classement";
            this.btnClassement.UseVisualStyleBackColor = false;
            this.btnClassement.Click += new System.EventHandler(this.btnClassement_Click);
            this.btnClassement.MouseEnter += new System.EventHandler(this.btnClassement_MouseEnter);
            this.btnClassement.MouseLeave += new System.EventHandler(this.btnClassement_MouseLeave);
            // 
            // btnQuitter
            // 
            this.btnQuitter.BackColor = System.Drawing.Color.Transparent;
            this.btnQuitter.BackgroundImage = global::PacMan.Properties.Resources.Capture_d_ecran_2024_04_02_103459_removebg_preview_cleanup;
            this.btnQuitter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnQuitter.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatAppearance.BorderSize = 0;
            this.btnQuitter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuitter.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuitter.Location = new System.Drawing.Point(264, 339);
            this.btnQuitter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnQuitter.Name = "btnQuitter";
            this.btnQuitter.Size = new System.Drawing.Size(192, 96);
            this.btnQuitter.TabIndex = 3;
            this.btnQuitter.Text = "Quitter";
            this.btnQuitter.UseVisualStyleBackColor = false;
            this.btnQuitter.Click += new System.EventHandler(this.btnQuitter_Click);
            this.btnQuitter.MouseEnter += new System.EventHandler(this.btnQuitter_MouseEnter);
            this.btnQuitter.MouseLeave += new System.EventHandler(this.btnQuitter_MouseLeave);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PacMan.Properties.Resources.Screenshot_2024_04_14_151646;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 517);
            this.ControlBox = false;
            this.Controls.Add(this.btnQuitter);
            this.Controls.Add(this.btnClassement);
            this.Controls.Add(this.btnNouvellepartie);
            this.Controls.Add(this.pctboxCaveman);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Menu";
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.pctboxCaveman)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pctboxCaveman;
        private System.Windows.Forms.Button btnNouvellepartie;
        private System.Windows.Forms.Button btnClassement;
        private System.Windows.Forms.Button btnQuitter;
    }
}