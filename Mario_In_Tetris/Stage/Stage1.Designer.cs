namespace Mario_In_Tetris
{
    partial class Stage1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stage1));
            this.MarioTimer = new System.Windows.Forms.Timer(this.components);
            this.MapSize = new System.Windows.Forms.Panel();
            this.Block2 = new System.Windows.Forms.PictureBox();
            this.Escape = new System.Windows.Forms.PictureBox();
            this.Mario = new System.Windows.Forms.PictureBox();
            this.Tetris = new Mario_In_Tetris.DisplayPanel();
            this.Block3 = new System.Windows.Forms.PictureBox();
            this.NextBlock = new Mario_In_Tetris.DisplayPanel();
            this.btnGameStart = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Label();
            this.Block1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.TetrisTimer = new System.Windows.Forms.Timer(this.components);
            this.MapSize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Block2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escape)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Block3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Block1)).BeginInit();
            this.SuspendLayout();
            // 
            // MarioTimer
            // 
            this.MarioTimer.Interval = 20;
            this.MarioTimer.Tick += new System.EventHandler(this.MarioTimer_Tick);
            // 
            // MapSize
            // 
            this.MapSize.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.MapSize.Controls.Add(this.Escape);
            this.MapSize.Controls.Add(this.Mario);
            this.MapSize.Controls.Add(this.Block2);
            this.MapSize.Controls.Add(this.Tetris);
            this.MapSize.Controls.Add(this.Block3);
            this.MapSize.Controls.Add(this.NextBlock);
            this.MapSize.Controls.Add(this.btnGameStart);
            this.MapSize.Controls.Add(this.ResetButton);
            this.MapSize.Controls.Add(this.Block1);
            this.MapSize.Controls.Add(this.textBox1);
            this.MapSize.Location = new System.Drawing.Point(-1, 0);
            this.MapSize.Name = "MapSize";
            this.MapSize.Size = new System.Drawing.Size(769, 690);
            this.MapSize.TabIndex = 18;
            // 
            // Block2
            // 
            this.Block2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Block2.BackgroundImage")));
            this.Block2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Block2.Location = new System.Drawing.Point(441, 498);
            this.Block2.Name = "Block2";
            this.Block2.Size = new System.Drawing.Size(89, 191);
            this.Block2.TabIndex = 40;
            this.Block2.TabStop = false;
            // 
            // Escape
            // 
            this.Escape.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Escape.BackgroundImage")));
            this.Escape.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Escape.Location = new System.Drawing.Point(459, 448);
            this.Escape.Name = "Escape";
            this.Escape.Size = new System.Drawing.Size(60, 50);
            this.Escape.TabIndex = 19;
            this.Escape.TabStop = false;
            // 
            // Mario
            // 
            this.Mario.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Mario.BackgroundImage")));
            this.Mario.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Mario.Location = new System.Drawing.Point(150, 448);
            this.Mario.Name = "Mario";
            this.Mario.Size = new System.Drawing.Size(20, 25);
            this.Mario.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Mario.TabIndex = 17;
            this.Mario.TabStop = false;
            // 
            // Tetris
            // 
            this.Tetris.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Tetris.Location = new System.Drawing.Point(201, 168);
            this.Tetris.Name = "Tetris";
            this.Tetris.Size = new System.Drawing.Size(240, 450);
            this.Tetris.TabIndex = 19;
            // 
            // Block3
            // 
            this.Block3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Block3.BackgroundImage")));
            this.Block3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Block3.Location = new System.Drawing.Point(201, 615);
            this.Block3.Name = "Block3";
            this.Block3.Size = new System.Drawing.Size(241, 74);
            this.Block3.TabIndex = 41;
            this.Block3.TabStop = false;
            // 
            // NextBlock
            // 
            this.NextBlock.Location = new System.Drawing.Point(437, 38);
            this.NextBlock.Name = "NextBlock";
            this.NextBlock.Size = new System.Drawing.Size(321, 83);
            this.NextBlock.TabIndex = 39;
            // 
            // btnGameStart
            // 
            this.btnGameStart.Location = new System.Drawing.Point(646, 649);
            this.btnGameStart.Margin = new System.Windows.Forms.Padding(0, 6, 0, 6);
            this.btnGameStart.Name = "btnGameStart";
            this.btnGameStart.Size = new System.Drawing.Size(112, 35);
            this.btnGameStart.TabIndex = 38;
            this.btnGameStart.Text = "Game Start";
            this.btnGameStart.UseVisualStyleBackColor = true;
            // 
            // ResetButton
            // 
            this.ResetButton.AutoSize = true;
            this.ResetButton.BackColor = System.Drawing.Color.Yellow;
            this.ResetButton.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResetButton.Location = new System.Drawing.Point(700, 9);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(58, 16);
            this.ResetButton.TabIndex = 37;
            this.ResetButton.Text = "Reset";
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // Block1
            // 
            this.Block1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Block1.BackgroundImage")));
            this.Block1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Block1.Location = new System.Drawing.Point(110, 498);
            this.Block1.Name = "Block1";
            this.Block1.Size = new System.Drawing.Size(92, 191);
            this.Block1.TabIndex = 17;
            this.Block1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("굴림", 1F);
            this.textBox1.Location = new System.Drawing.Point(0, 448);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(803, 2);
            this.textBox1.TabIndex = 20;
            // 
            // TetrisTimer
            // 
            this.TetrisTimer.Interval = 1000;
            this.TetrisTimer.Tick += new System.EventHandler(this.TetrisTimer_Tick);
            // 
            // Stage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(767, 689);
            this.Controls.Add(this.MapSize);
            this.Name = "Stage1";
            this.Text = "Stage1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDownHandler);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MapSize.ResumeLayout(false);
            this.MapSize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Block2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Escape)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Mario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Block3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Block1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer MarioTimer;
        private System.Windows.Forms.Panel MapSize;
        private System.Windows.Forms.PictureBox Mario;
        private System.Windows.Forms.PictureBox Block1;
        private System.Windows.Forms.PictureBox Escape;
        private System.Windows.Forms.Label ResetButton;
        private System.Windows.Forms.Button btnGameStart;
        private DisplayPanel Tetris;
        private DisplayPanel NextBlock;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Timer TetrisTimer;
        private System.Windows.Forms.PictureBox Block2;
        private System.Windows.Forms.PictureBox Block3;
    }
}

