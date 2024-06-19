namespace PacMan
{
    partial class Pseudo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pseudo));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtboxPseudo = new System.Windows.Forms.TextBox();
            this.lblPseudo = new System.Windows.Forms.Label();
            this.lblChoixPseudo = new System.Windows.Forms.Label();
            this.btnretour = new System.Windows.Forms.Button();
            this.btnValiderPseudo = new System.Windows.Forms.Button();
            this.btnchangerdepseudo = new System.Windows.Forms.Button();
            this.btnSuivant = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(208, 88);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 276);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtboxPseudo
            // 
            this.txtboxPseudo.BackColor = System.Drawing.SystemColors.Window;
            this.txtboxPseudo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxPseudo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtboxPseudo.Location = new System.Drawing.Point(362, 210);
            this.txtboxPseudo.Margin = new System.Windows.Forms.Padding(2);
            this.txtboxPseudo.Name = "txtboxPseudo";
            this.txtboxPseudo.Size = new System.Drawing.Size(76, 25);
            this.txtboxPseudo.TabIndex = 1;
            // 
            // lblPseudo
            // 
            this.lblPseudo.AutoSize = true;
            this.lblPseudo.BackColor = System.Drawing.Color.Transparent;
            this.lblPseudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblPseudo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPseudo.Image = ((System.Drawing.Image)(resources.GetObject("lblPseudo.Image")));
            this.lblPseudo.Location = new System.Drawing.Point(288, 211);
            this.lblPseudo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPseudo.Name = "lblPseudo";
            this.lblPseudo.Size = new System.Drawing.Size(68, 19);
            this.lblPseudo.TabIndex = 2;
            this.lblPseudo.Text = "Pseudo :";
            // 
            // lblChoixPseudo
            // 
            this.lblChoixPseudo.AutoSize = true;
            this.lblChoixPseudo.BackColor = System.Drawing.Color.Transparent;
            this.lblChoixPseudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblChoixPseudo.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChoixPseudo.Image = ((System.Drawing.Image)(resources.GetObject("lblChoixPseudo.Image")));
            this.lblChoixPseudo.Location = new System.Drawing.Point(311, 110);
            this.lblChoixPseudo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblChoixPseudo.Name = "lblChoixPseudo";
            this.lblChoixPseudo.Size = new System.Drawing.Size(129, 19);
            this.lblChoixPseudo.TabIndex = 3;
            this.lblChoixPseudo.Text = "Choix du pseudo ";
            // 
            // btnretour
            // 
            this.btnretour.BackColor = System.Drawing.Color.Transparent;
            this.btnretour.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnretour.BackgroundImage")));
            this.btnretour.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnretour.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatAppearance.BorderSize = 0;
            this.btnretour.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnretour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnretour.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnretour.Location = new System.Drawing.Point(9, 10);
            this.btnretour.Margin = new System.Windows.Forms.Padding(2);
            this.btnretour.Name = "btnretour";
            this.btnretour.Size = new System.Drawing.Size(116, 63);
            this.btnretour.TabIndex = 4;
            this.btnretour.Text = "Retour";
            this.btnretour.UseVisualStyleBackColor = false;
            this.btnretour.Click += new System.EventHandler(this.btnretour_Click);
            this.btnretour.MouseEnter += new System.EventHandler(this.btnretour_MouseEnter);
            this.btnretour.MouseLeave += new System.EventHandler(this.btnretour_MouseLeave);
            // 
            // btnValiderPseudo
            // 
            this.btnValiderPseudo.BackColor = System.Drawing.Color.Transparent;
            this.btnValiderPseudo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnValiderPseudo.BackgroundImage")));
            this.btnValiderPseudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnValiderPseudo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnValiderPseudo.FlatAppearance.BorderSize = 0;
            this.btnValiderPseudo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnValiderPseudo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnValiderPseudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnValiderPseudo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValiderPseudo.Location = new System.Drawing.Point(298, 358);
            this.btnValiderPseudo.Margin = new System.Windows.Forms.Padding(2);
            this.btnValiderPseudo.Name = "btnValiderPseudo";
            this.btnValiderPseudo.Size = new System.Drawing.Size(156, 73);
            this.btnValiderPseudo.TabIndex = 5;
            this.btnValiderPseudo.Text = "Valider mon pseudo";
            this.btnValiderPseudo.UseVisualStyleBackColor = false;
            this.btnValiderPseudo.Click += new System.EventHandler(this.btnValiderPseudo_Click);
            this.btnValiderPseudo.MouseEnter += new System.EventHandler(this.button1_MouseEnter);
            this.btnValiderPseudo.MouseLeave += new System.EventHandler(this.button1_MouseLeave);
            // 
            // btnchangerdepseudo
            // 
            this.btnchangerdepseudo.BackColor = System.Drawing.Color.Transparent;
            this.btnchangerdepseudo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnchangerdepseudo.BackgroundImage")));
            this.btnchangerdepseudo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnchangerdepseudo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnchangerdepseudo.FlatAppearance.BorderSize = 0;
            this.btnchangerdepseudo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnchangerdepseudo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnchangerdepseudo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnchangerdepseudo.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchangerdepseudo.Location = new System.Drawing.Point(9, 67);
            this.btnchangerdepseudo.Margin = new System.Windows.Forms.Padding(2);
            this.btnchangerdepseudo.Name = "btnchangerdepseudo";
            this.btnchangerdepseudo.Size = new System.Drawing.Size(116, 63);
            this.btnchangerdepseudo.TabIndex = 6;
            this.btnchangerdepseudo.Text = "Changer de pseudo";
            this.btnchangerdepseudo.UseVisualStyleBackColor = false;
            this.btnchangerdepseudo.Click += new System.EventHandler(this.btnchangerdepseudo_Click);
            this.btnchangerdepseudo.MouseEnter += new System.EventHandler(this.button1_MouseEnter_1);
            this.btnchangerdepseudo.MouseLeave += new System.EventHandler(this.button1_MouseLeave_1);
            // 
            // btnSuivant
            // 
            this.btnSuivant.BackColor = System.Drawing.Color.Transparent;
            this.btnSuivant.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSuivant.BackgroundImage")));
            this.btnSuivant.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSuivant.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSuivant.FlatAppearance.BorderSize = 0;
            this.btnSuivant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSuivant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnSuivant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSuivant.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSuivant.Location = new System.Drawing.Point(298, 358);
            this.btnSuivant.Margin = new System.Windows.Forms.Padding(2);
            this.btnSuivant.Name = "btnSuivant";
            this.btnSuivant.Size = new System.Drawing.Size(156, 73);
            this.btnSuivant.TabIndex = 7;
            this.btnSuivant.Text = "Suivant";
            this.btnSuivant.UseVisualStyleBackColor = false;
            this.btnSuivant.Click += new System.EventHandler(this.btnSuivant_Click);
            this.btnSuivant.MouseEnter += new System.EventHandler(this.btnSuivant_MouseEnter);
            this.btnSuivant.MouseLeave += new System.EventHandler(this.btnSuivant_MouseLeave);
            // 
            // Pseudo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 517);
            this.ControlBox = false;
            this.Controls.Add(this.btnSuivant);
            this.Controls.Add(this.btnchangerdepseudo);
            this.Controls.Add(this.btnValiderPseudo);
            this.Controls.Add(this.btnretour);
            this.Controls.Add(this.lblChoixPseudo);
            this.Controls.Add(this.lblPseudo);
            this.Controls.Add(this.txtboxPseudo);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Pseudo";
            this.Text = "Pseudo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtboxPseudo;
        private System.Windows.Forms.Label lblPseudo;
        private System.Windows.Forms.Label lblChoixPseudo;
        private System.Windows.Forms.Button btnretour;
        private System.Windows.Forms.Button btnValiderPseudo;
        private System.Windows.Forms.Button btnchangerdepseudo;
        private System.Windows.Forms.Button btnSuivant;
    }
}