namespace PacMan
{
    partial class LoadingDifficile
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
            this.lblLoadingD = new System.Windows.Forms.Label();
            this.lblTimeD = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblLoadingD
            // 
            this.lblLoadingD.AutoSize = true;
            this.lblLoadingD.BackColor = System.Drawing.Color.Transparent;
            this.lblLoadingD.Font = new System.Drawing.Font("Microsoft YaHei UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoadingD.Location = new System.Drawing.Point(280, 190);
            this.lblLoadingD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLoadingD.Name = "lblLoadingD";
            this.lblLoadingD.Size = new System.Drawing.Size(174, 40);
            this.lblLoadingD.TabIndex = 1;
            this.lblLoadingD.Text = "Loading ...";
            // 
            // lblTimeD
            // 
            this.lblTimeD.AutoSize = true;
            this.lblTimeD.BackColor = System.Drawing.Color.Transparent;
            this.lblTimeD.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeD.Location = new System.Drawing.Point(332, 267);
            this.lblTimeD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimeD.Name = "lblTimeD";
            this.lblTimeD.Size = new System.Drawing.Size(45, 17);
            this.lblTimeD.TabIndex = 2;
            this.lblTimeD.Text = "label2";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar1.ForeColor = System.Drawing.Color.Lime;
            this.progressBar1.Location = new System.Drawing.Point(190, 285);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(322, 32);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // LoadingDifficile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::PacMan.Properties.Resources.Screenshot_2024_04_14_151646;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(718, 517);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblTimeD);
            this.Controls.Add(this.lblLoadingD);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "LoadingDifficile";
            this.Text = "LoadingDifficile";
            this.Load += new System.EventHandler(this.LoadingDifficile_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLoadingD;
        private System.Windows.Forms.Label lblTimeD;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer2;
    }
}