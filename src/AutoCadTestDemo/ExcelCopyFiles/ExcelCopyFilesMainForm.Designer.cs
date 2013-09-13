namespace ExcelCopyFiles
{
    partial class ExcelCopyFilesMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelCopyFilesMainForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSelPath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSavePath = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnProcess);
            this.panel3.Location = new System.Drawing.Point(432, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(162, 207);
            this.panel3.TabIndex = 23;
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(26, 71);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(111, 67);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "开始处理";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSelPath);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSelPath);
            this.panel2.Location = new System.Drawing.Point(3, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 65);
            this.panel2.TabIndex = 22;
            // 
            // btnSelPath
            // 
            this.btnSelPath.Location = new System.Drawing.Point(336, 12);
            this.btnSelPath.Name = "btnSelPath";
            this.btnSelPath.Size = new System.Drawing.Size(75, 38);
            this.btnSelPath.TabIndex = 3;
            this.btnSelPath.Text = "选择";
            this.btnSelPath.UseVisualStyleBackColor = true;
            this.btnSelPath.Click += new System.EventHandler(this.btnSelPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择查找路径：";
            // 
            // txtSelPath
            // 
            this.txtSelPath.Enabled = false;
            this.txtSelPath.Location = new System.Drawing.Point(111, 14);
            this.txtSelPath.Multiline = true;
            this.txtSelPath.Name = "txtSelPath";
            this.txtSelPath.Size = new System.Drawing.Size(222, 36);
            this.txtSelPath.TabIndex = 1;
            this.txtSelPath.Text = "查找文件路径";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSelExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtExcelPath);
            this.panel1.Location = new System.Drawing.Point(3, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 65);
            this.panel1.TabIndex = 21;
            // 
            // btnSelExcel
            // 
            this.btnSelExcel.Location = new System.Drawing.Point(336, 14);
            this.btnSelExcel.Name = "btnSelExcel";
            this.btnSelExcel.Size = new System.Drawing.Size(75, 38);
            this.btnSelExcel.TabIndex = 2;
            this.btnSelExcel.Text = "选择";
            this.btnSelExcel.UseVisualStyleBackColor = true;
            this.btnSelExcel.Click += new System.EventHandler(this.btnSelExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择Excel文件：";
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(111, 14);
            this.txtExcelPath.Multiline = true;
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(222, 38);
            this.txtExcelPath.TabIndex = 0;
            this.txtExcelPath.Text = "Excel路径";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(158, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 30);
            this.label3.TabIndex = 20;
            this.label3.Text = "图纸批量拷贝程序";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExcelCopyFiles.Properties.Resources.华研标志;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSavePath);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.txtSavePath);
            this.panel4.Location = new System.Drawing.Point(3, 212);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(415, 65);
            this.panel4.TabIndex = 24;
            // 
            // btnSavePath
            // 
            this.btnSavePath.Location = new System.Drawing.Point(336, 12);
            this.btnSavePath.Name = "btnSavePath";
            this.btnSavePath.Size = new System.Drawing.Size(75, 38);
            this.btnSavePath.TabIndex = 3;
            this.btnSavePath.Text = "选择";
            this.btnSavePath.UseVisualStyleBackColor = true;
            this.btnSavePath.Click += new System.EventHandler(this.btnSavePath_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "选择保存路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(111, 14);
            this.txtSavePath.Multiline = true;
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(222, 36);
            this.txtSavePath.TabIndex = 1;
            this.txtSavePath.Text = "文件保存路径";
            // 
            // ExcelCopyFilesMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 285);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelCopyFilesMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图纸批量拷贝程序";
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSelPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelPath;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSavePath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSavePath;
    }
}

