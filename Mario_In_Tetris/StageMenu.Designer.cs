namespace Mario_In_Tetris
{
    partial class StageMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StageMenu));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Stage3 = new System.Windows.Forms.PictureBox();
            this.Stage5 = new System.Windows.Forms.PictureBox();
            this.Stage4 = new System.Windows.Forms.PictureBox();
            this.Stage2 = new System.Windows.Forms.PictureBox();
            this.Stage1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Stage3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Stage3
            // 
            this.Stage3.Image = ((System.Drawing.Image)(resources.GetObject("Stage3.Image")));
            this.Stage3.Location = new System.Drawing.Point(286, 32);
            this.Stage3.Name = "Stage3";
            this.Stage3.Size = new System.Drawing.Size(60, 60);
            this.Stage3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Stage3.TabIndex = 9;
            this.Stage3.TabStop = false;
            this.Stage3.Click += new System.EventHandler(this.Stage3_Click);
            // 
            // Stage5
            // 
            this.Stage5.Image = ((System.Drawing.Image)(resources.GetObject("Stage5.Image")));
            this.Stage5.Location = new System.Drawing.Point(521, 32);
            this.Stage5.Name = "Stage5";
            this.Stage5.Size = new System.Drawing.Size(60, 60);
            this.Stage5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Stage5.TabIndex = 8;
            this.Stage5.TabStop = false;
            this.Stage5.Click += new System.EventHandler(this.Stage5_Click);
            // 
            // Stage4
            // 
            this.Stage4.Image = ((System.Drawing.Image)(resources.GetObject("Stage4.Image")));
            this.Stage4.Location = new System.Drawing.Point(402, 32);
            this.Stage4.Name = "Stage4";
            this.Stage4.Size = new System.Drawing.Size(60, 60);
            this.Stage4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Stage4.TabIndex = 7;
            this.Stage4.TabStop = false;
            this.Stage4.Click += new System.EventHandler(this.Stage4_Click);
            // 
            // Stage2
            // 
            this.Stage2.Image = ((System.Drawing.Image)(resources.GetObject("Stage2.Image")));
            this.Stage2.Location = new System.Drawing.Point(170, 32);
            this.Stage2.Name = "Stage2";
            this.Stage2.Size = new System.Drawing.Size(60, 60);
            this.Stage2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Stage2.TabIndex = 6;
            this.Stage2.TabStop = false;
            this.Stage2.Click += new System.EventHandler(this.Stage2_Click);
            // 
            // Stage1
            // 
            this.Stage1.Image = ((System.Drawing.Image)(resources.GetObject("Stage1.Image")));
            this.Stage1.Location = new System.Drawing.Point(55, 32);
            this.Stage1.Name = "Stage1";
            this.Stage1.Size = new System.Drawing.Size(60, 60);
            this.Stage1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Stage1.TabIndex = 5;
            this.Stage1.TabStop = false;
            this.Stage1.Click += new System.EventHandler(this.Stage1_Click);
            // 
            // StageMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.Stage3);
            this.Controls.Add(this.Stage5);
            this.Controls.Add(this.Stage4);
            this.Controls.Add(this.Stage2);
            this.Controls.Add(this.Stage1);
            this.Name = "StageMenu";
            this.Text = "StageMenu";
            ((System.ComponentModel.ISupportInitialize)(this.Stage3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Stage1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Stage3;
        private System.Windows.Forms.PictureBox Stage5;
        private System.Windows.Forms.PictureBox Stage4;
        private System.Windows.Forms.PictureBox Stage2;
        private System.Windows.Forms.PictureBox Stage1;
        private System.Windows.Forms.Timer timer1;
    }
}