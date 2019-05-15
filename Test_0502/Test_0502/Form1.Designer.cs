namespace Test_0502
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.gbImg = new System.Windows.Forms.GroupBox();
            this.Btn_Load = new System.Windows.Forms.Button();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.BtnRight = new System.Windows.Forms.Button();
            this.BtnCount = new System.Windows.Forms.Button();
            this.tbFileName = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            this.gbImg.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbImg
            // 
            this.pbImg.Location = new System.Drawing.Point(6, 20);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(248, 129);
            this.pbImg.TabIndex = 0;
            this.pbImg.TabStop = false;
            this.pbImg.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseClick);
            // 
            // gbImg
            // 
            this.gbImg.Controls.Add(this.pbImg);
            this.gbImg.Location = new System.Drawing.Point(12, 12);
            this.gbImg.Name = "gbImg";
            this.gbImg.Size = new System.Drawing.Size(260, 155);
            this.gbImg.TabIndex = 1;
            this.gbImg.TabStop = false;
            this.gbImg.Text = "Image";
            // 
            // Btn_Load
            // 
            this.Btn_Load.Location = new System.Drawing.Point(18, 218);
            this.Btn_Load.Name = "Btn_Load";
            this.Btn_Load.Size = new System.Drawing.Size(75, 23);
            this.Btn_Load.TabIndex = 2;
            this.Btn_Load.Text = "Load";
            this.Btn_Load.UseVisualStyleBackColor = true;
            this.Btn_Load.Click += new System.EventHandler(this.LoadBtn_Img_Click);
            // 
            // BtnLeft
            // 
            this.BtnLeft.Location = new System.Drawing.Point(137, 218);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(20, 23);
            this.BtnLeft.TabIndex = 3;
            this.BtnLeft.Text = "◀";
            this.BtnLeft.UseVisualStyleBackColor = true;
            this.BtnLeft.Click += new System.EventHandler(this.BtnControl_Click);
            // 
            // BtnRight
            // 
            this.BtnRight.Location = new System.Drawing.Point(244, 218);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(21, 23);
            this.BtnRight.TabIndex = 5;
            this.BtnRight.Text = "▶";
            this.BtnRight.UseVisualStyleBackColor = true;
            this.BtnRight.Click += new System.EventHandler(this.BtnControl_Click);
            // 
            // BtnCount
            // 
            this.BtnCount.Enabled = false;
            this.BtnCount.Location = new System.Drawing.Point(163, 218);
            this.BtnCount.Name = "BtnCount";
            this.BtnCount.Size = new System.Drawing.Size(75, 23);
            this.BtnCount.TabIndex = 4;
            this.BtnCount.Text = "Count";
            this.BtnCount.UseVisualStyleBackColor = true;
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(18, 173);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.ReadOnly = true;
            this.tbFileName.Size = new System.Drawing.Size(247, 21);
            this.tbFileName.TabIndex = 6;
            this.tbFileName.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.tbFileName);
            this.Controls.Add(this.BtnRight);
            this.Controls.Add(this.BtnCount);
            this.Controls.Add(this.BtnLeft);
            this.Controls.Add(this.Btn_Load);
            this.Controls.Add(this.gbImg);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            this.gbImg.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.GroupBox gbImg;
        private System.Windows.Forms.Button Btn_Load;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnCount;
        private System.Windows.Forms.TextBox tbFileName;
    }
}

