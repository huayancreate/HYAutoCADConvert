namespace MainTools
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
            this.btnOpenConvert = new System.Windows.Forms.Button();
            this.btnOPenSearch = new System.Windows.Forms.Button();
            this.btnOpenEditBlock = new System.Windows.Forms.Button();
            this.btnOpenMonitor = new System.Windows.Forms.Button();
            this.btnOpenExcelCopy = new System.Windows.Forms.Button();
            this.btnOpenExcelHandle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOpenConvert
            // 
            this.btnOpenConvert.Location = new System.Drawing.Point(64, 35);
            this.btnOpenConvert.Name = "btnOpenConvert";
            this.btnOpenConvert.Size = new System.Drawing.Size(163, 23);
            this.btnOpenConvert.TabIndex = 0;
            this.btnOpenConvert.Text = "打开图纸批量修改程序";
            this.btnOpenConvert.UseVisualStyleBackColor = true;
            // 
            // btnOPenSearch
            // 
            this.btnOPenSearch.Location = new System.Drawing.Point(64, 113);
            this.btnOPenSearch.Name = "btnOPenSearch";
            this.btnOPenSearch.Size = new System.Drawing.Size(163, 23);
            this.btnOPenSearch.TabIndex = 1;
            this.btnOPenSearch.Text = "打开编号查询程序";
            this.btnOPenSearch.UseVisualStyleBackColor = true;
            // 
            // btnOpenEditBlock
            // 
            this.btnOpenEditBlock.Location = new System.Drawing.Point(64, 74);
            this.btnOpenEditBlock.Name = "btnOpenEditBlock";
            this.btnOpenEditBlock.Size = new System.Drawing.Size(163, 23);
            this.btnOpenEditBlock.TabIndex = 1;
            this.btnOpenEditBlock.Text = "打开图纸批量修改块程序";
            this.btnOpenEditBlock.UseVisualStyleBackColor = true;
            // 
            // btnOpenMonitor
            // 
            this.btnOpenMonitor.Location = new System.Drawing.Point(64, 154);
            this.btnOpenMonitor.Name = "btnOpenMonitor";
            this.btnOpenMonitor.Size = new System.Drawing.Size(163, 23);
            this.btnOpenMonitor.TabIndex = 2;
            this.btnOpenMonitor.Text = "打开图纸处理监控程序";
            this.btnOpenMonitor.UseVisualStyleBackColor = true;
            // 
            // btnOpenExcelCopy
            // 
            this.btnOpenExcelCopy.Location = new System.Drawing.Point(269, 35);
            this.btnOpenExcelCopy.Name = "btnOpenExcelCopy";
            this.btnOpenExcelCopy.Size = new System.Drawing.Size(163, 23);
            this.btnOpenExcelCopy.TabIndex = 3;
            this.btnOpenExcelCopy.Text = "打开Excel批量拷贝程序";
            this.btnOpenExcelCopy.UseVisualStyleBackColor = true;
            // 
            // btnOpenExcelHandle
            // 
            this.btnOpenExcelHandle.Location = new System.Drawing.Point(269, 74);
            this.btnOpenExcelHandle.Name = "btnOpenExcelHandle";
            this.btnOpenExcelHandle.Size = new System.Drawing.Size(163, 23);
            this.btnOpenExcelHandle.TabIndex = 4;
            this.btnOpenExcelHandle.Text = "打开Excel批量替换程序";
            this.btnOpenExcelHandle.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 234);
            this.Controls.Add(this.btnOpenExcelHandle);
            this.Controls.Add(this.btnOpenExcelCopy);
            this.Controls.Add(this.btnOpenMonitor);
            this.Controls.Add(this.btnOpenEditBlock);
            this.Controls.Add(this.btnOPenSearch);
            this.Controls.Add(this.btnOpenConvert);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOpenConvert;
        private System.Windows.Forms.Button btnOPenSearch;
        private System.Windows.Forms.Button btnOpenEditBlock;
        private System.Windows.Forms.Button btnOpenMonitor;
        private System.Windows.Forms.Button btnOpenExcelCopy;
        private System.Windows.Forms.Button btnOpenExcelHandle;
    }
}