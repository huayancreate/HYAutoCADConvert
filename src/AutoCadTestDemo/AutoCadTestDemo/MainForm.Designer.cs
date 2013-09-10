namespace AutoCadConvert
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSelectPath = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.btnImportExcel = new System.Windows.Forms.Button();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.btnSelectSave = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblTips = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSavePath = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSelectPath);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSelectPath);
            this.panel1.Location = new System.Drawing.Point(6, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(679, 76);
            this.panel1.TabIndex = 5;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Location = new System.Drawing.Point(448, 10);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(58, 42);
            this.btnSelectPath.TabIndex = 14;
            this.btnSelectPath.Text = "选择";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "选择处理的文件路径：";
            // 
            // txtSelectPath
            // 
            this.txtSelectPath.Enabled = false;
            this.txtSelectPath.Location = new System.Drawing.Point(137, 15);
            this.txtSelectPath.Multiline = true;
            this.txtSelectPath.Name = "txtSelectPath";
            this.txtSelectPath.Size = new System.Drawing.Size(306, 33);
            this.txtSelectPath.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnImportExcel);
            this.panel2.Controls.Add(this.txtExcelPath);
            this.panel2.Location = new System.Drawing.Point(6, 253);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 78);
            this.panel2.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "选择Excel路径：";
            // 
            // btnImportExcel
            // 
            this.btnImportExcel.Location = new System.Drawing.Point(414, 14);
            this.btnImportExcel.Name = "btnImportExcel";
            this.btnImportExcel.Size = new System.Drawing.Size(58, 42);
            this.btnImportExcel.TabIndex = 14;
            this.btnImportExcel.Text = "选择";
            this.btnImportExcel.UseVisualStyleBackColor = true;
            this.btnImportExcel.Click += new System.EventHandler(this.btnImportExcel_Click);
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Enabled = false;
            this.txtExcelPath.Location = new System.Drawing.Point(103, 19);
            this.txtExcelPath.Multiline = true;
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.Size = new System.Drawing.Size(306, 33);
            this.txtExcelPath.TabIndex = 9;
            // 
            // btnSelectSave
            // 
            this.btnSelectSave.Location = new System.Drawing.Point(410, 14);
            this.btnSelectSave.Name = "btnSelectSave";
            this.btnSelectSave.Size = new System.Drawing.Size(58, 42);
            this.btnSelectSave.TabIndex = 11;
            this.btnSelectSave.Text = "选择";
            this.btnSelectSave.UseVisualStyleBackColor = true;
            this.btnSelectSave.Click += new System.EventHandler(this.btnSelectSave_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(37, 6);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(112, 64);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "确认修改";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnUpdate);
            this.panel3.Location = new System.Drawing.Point(500, 253);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(185, 78);
            this.panel3.TabIndex = 8;
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(327, 88);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(0, 12);
            this.lblTips.TabIndex = 10;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnSelectSave);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtSavePath);
            this.panel4.Location = new System.Drawing.Point(6, 177);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(679, 70);
            this.panel4.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "保存文件路径：";
            // 
            // txtSavePath
            // 
            this.txtSavePath.Enabled = false;
            this.txtSavePath.Location = new System.Drawing.Point(99, 18);
            this.txtSavePath.Multiline = true;
            this.txtSavePath.Name = "txtSavePath";
            this.txtSavePath.Size = new System.Drawing.Size(306, 33);
            this.txtSavePath.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::AutoCadConvert.Properties.Resources.华研标志;
            this.pictureBox1.Location = new System.Drawing.Point(3, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(164, 81);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(237, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(313, 30);
            this.label3.TabIndex = 14;
            this.label3.Text = "图纸文件批量修改程序";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 336);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "图纸文件批量修改程序";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExcelPath;
        private System.Windows.Forms.Button btnSelectSave;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSelectPath;
        private System.Windows.Forms.Button btnImportExcel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSavePath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}