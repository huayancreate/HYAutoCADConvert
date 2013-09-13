namespace ExcelHandle
{
    partial class ExcelHandleMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExcelHandleMainForm));
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.txtSaveExcelPath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelExcel = new System.Windows.Forms.Button();
            this.btnSaveExcel = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(111, 14);
            this.txtExcelPath.Multiline = true;
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(222, 38);
            this.txtExcelPath.TabIndex = 0;
            this.txtExcelPath.Text = "原始excel文件目录";
            // 
            // txtSaveExcelPath
            // 
            this.txtSaveExcelPath.Enabled = false;
            this.txtSaveExcelPath.Location = new System.Drawing.Point(111, 14);
            this.txtSaveExcelPath.Multiline = true;
            this.txtSaveExcelPath.Name = "txtSaveExcelPath";
            this.txtSaveExcelPath.Size = new System.Drawing.Size(222, 36);
            this.txtSaveExcelPath.TabIndex = 1;
            this.txtSaveExcelPath.Text = "生成excel文件目录";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ExcelHandle.Properties.Resources.华研标志;
            this.pictureBox1.Location = new System.Drawing.Point(2, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(139, 61);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(157, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(268, 30);
            this.label3.TabIndex = 15;
            this.label3.Text = "Excel图号替换程序";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSelExcel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtExcelPath);
            this.panel1.Location = new System.Drawing.Point(2, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(415, 65);
            this.panel1.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnSaveExcel);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtSaveExcelPath);
            this.panel2.Location = new System.Drawing.Point(2, 141);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(415, 65);
            this.panel2.TabIndex = 17;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnProcess);
            this.panel3.Location = new System.Drawing.Point(420, 70);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 136);
            this.panel3.TabIndex = 18;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "选择保存路径：";
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
            // btnSaveExcel
            // 
            this.btnSaveExcel.Location = new System.Drawing.Point(336, 12);
            this.btnSaveExcel.Name = "btnSaveExcel";
            this.btnSaveExcel.Size = new System.Drawing.Size(75, 38);
            this.btnSaveExcel.TabIndex = 3;
            this.btnSaveExcel.Text = "选择";
            this.btnSaveExcel.UseVisualStyleBackColor = true;
            this.btnSaveExcel.Click += new System.EventHandler(this.btnSaveExcel_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(27, 26);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(125, 75);
            this.btnProcess.TabIndex = 4;
            this.btnProcess.Text = "开始处理";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // ExcelHandleMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 261);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExcelHandleMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Excel图号替换程序";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.TextBox txtSaveExcelPath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSelExcel;
        private System.Windows.Forms.Button btnSaveExcel;
        private System.Windows.Forms.Button btnProcess;
    }
}

