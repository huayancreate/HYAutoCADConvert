namespace Monitor
{
    partial class MyGroupBox
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.gbxDwgDetail = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDwgCount = new System.Windows.Forms.Label();
            this.lblProcessDwgCount = new System.Windows.Forms.Label();
            this.lblProcessTime = new System.Windows.Forms.Label();
            this.lblErrorDwgCount = new System.Windows.Forms.Label();
            this.lblProcessEndTime = new System.Windows.Forms.Label();
            this.gbxDwgDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxDwgDetail
            // 
            this.gbxDwgDetail.Controls.Add(this.lblProcessEndTime);
            this.gbxDwgDetail.Controls.Add(this.lblErrorDwgCount);
            this.gbxDwgDetail.Controls.Add(this.lblProcessTime);
            this.gbxDwgDetail.Controls.Add(this.lblProcessDwgCount);
            this.gbxDwgDetail.Controls.Add(this.lblDwgCount);
            this.gbxDwgDetail.Controls.Add(this.label5);
            this.gbxDwgDetail.Controls.Add(this.label4);
            this.gbxDwgDetail.Controls.Add(this.label3);
            this.gbxDwgDetail.Controls.Add(this.label2);
            this.gbxDwgDetail.Controls.Add(this.label1);
            this.gbxDwgDetail.Location = new System.Drawing.Point(4, 0);
            this.gbxDwgDetail.Name = "gbxDwgDetail";
            this.gbxDwgDetail.Size = new System.Drawing.Size(645, 79);
            this.gbxDwgDetail.TabIndex = 0;
            this.gbxDwgDetail.TabStop = false;
            this.gbxDwgDetail.Text = "gbxDwgDetail";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前共需处理图纸：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前已处理图纸：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "已处理时间：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "当前处理错误图纸：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(355, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "预计结束时间：";
            // 
            // lblDwgCount
            // 
            this.lblDwgCount.AutoSize = true;
            this.lblDwgCount.Location = new System.Drawing.Point(184, 16);
            this.lblDwgCount.Name = "lblDwgCount";
            this.lblDwgCount.Size = new System.Drawing.Size(41, 12);
            this.lblDwgCount.TabIndex = 5;
            this.lblDwgCount.Text = "label6";
            // 
            // lblProcessDwgCount
            // 
            this.lblProcessDwgCount.AutoSize = true;
            this.lblProcessDwgCount.Location = new System.Drawing.Point(184, 36);
            this.lblProcessDwgCount.Name = "lblProcessDwgCount";
            this.lblProcessDwgCount.Size = new System.Drawing.Size(41, 12);
            this.lblProcessDwgCount.TabIndex = 6;
            this.lblProcessDwgCount.Text = "label7";
            // 
            // lblProcessTime
            // 
            this.lblProcessTime.AutoSize = true;
            this.lblProcessTime.Location = new System.Drawing.Point(184, 54);
            this.lblProcessTime.Name = "lblProcessTime";
            this.lblProcessTime.Size = new System.Drawing.Size(41, 12);
            this.lblProcessTime.TabIndex = 7;
            this.lblProcessTime.Text = "label8";
            // 
            // lblErrorDwgCount
            // 
            this.lblErrorDwgCount.AutoSize = true;
            this.lblErrorDwgCount.Location = new System.Drawing.Point(474, 17);
            this.lblErrorDwgCount.Name = "lblErrorDwgCount";
            this.lblErrorDwgCount.Size = new System.Drawing.Size(41, 12);
            this.lblErrorDwgCount.TabIndex = 8;
            this.lblErrorDwgCount.Text = "label9";
            // 
            // lblProcessEndTime
            // 
            this.lblProcessEndTime.AutoSize = true;
            this.lblProcessEndTime.Location = new System.Drawing.Point(450, 54);
            this.lblProcessEndTime.Name = "lblProcessEndTime";
            this.lblProcessEndTime.Size = new System.Drawing.Size(47, 12);
            this.lblProcessEndTime.TabIndex = 9;
            this.lblProcessEndTime.Text = "label10";
            // 
            // MyGroupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbxDwgDetail);
            this.Name = "MyGroupBox";
            this.Size = new System.Drawing.Size(652, 83);
            this.gbxDwgDetail.ResumeLayout(false);
            this.gbxDwgDetail.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.GroupBox gbxDwgDetail;
        public System.Windows.Forms.Label lblProcessEndTime;
        public System.Windows.Forms.Label lblErrorDwgCount;
        public System.Windows.Forms.Label lblProcessTime;
        public System.Windows.Forms.Label lblProcessDwgCount;
        public System.Windows.Forms.Label lblDwgCount;
    }
}
