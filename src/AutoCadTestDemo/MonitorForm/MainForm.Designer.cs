namespace MonitorForm
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSystemConfig = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.tmrLoad = new System.Timers.Timer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmrLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.btnSystemConfig);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(653, 56);
            this.panel1.TabIndex = 0;
            // 
            // btnSystemConfig
            // 
            this.btnSystemConfig.Location = new System.Drawing.Point(546, 10);
            this.btnSystemConfig.Name = "btnSystemConfig";
            this.btnSystemConfig.Size = new System.Drawing.Size(94, 32);
            this.btnSystemConfig.TabIndex = 0;
            this.btnSystemConfig.Text = "服务器配置";
            this.btnSystemConfig.UseVisualStyleBackColor = true;
            this.btnSystemConfig.Click += new System.EventHandler(this.btnSystemConfig_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Location = new System.Drawing.Point(1, 63);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(653, 320);
            this.MainPanel.TabIndex = 1;
            // 
            // tmrLoad
            // 
            this.tmrLoad.Enabled = true;
            this.tmrLoad.Interval = 5000D;
            this.tmrLoad.SynchronizingObject = this;
            this.tmrLoad.Elapsed += new System.Timers.ElapsedEventHandler(this.tmrLoad_Elapsed);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MonitorForm.Properties.Resources.华研标志;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(115, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(145, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "图纸处理监控程序";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 385);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图纸文件处理监控程序";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tmrLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel MainPanel;
        private global::System.Windows.Forms.Button btnSystemConfig;
        private System.Timers.Timer tmrLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}

