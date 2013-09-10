namespace MonitorForm
{
    partial class ConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.btnSet = new System.Windows.Forms.Button();
            this.txtServeIp = new System.Windows.Forms.TextBox();
            this.txtServePoint = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtServe = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(151, 169);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(104, 37);
            this.btnSet.TabIndex = 6;
            this.btnSet.Text = "配置";
            this.btnSet.UseVisualStyleBackColor = true;
            this.btnSet.Click += new System.EventHandler(this.btnSet_Click);
            // 
            // txtServeIp
            // 
            this.txtServeIp.Location = new System.Drawing.Point(151, 48);
            this.txtServeIp.Name = "txtServeIp";
            this.txtServeIp.Size = new System.Drawing.Size(172, 21);
            this.txtServeIp.TabIndex = 2;
            // 
            // txtServePoint
            // 
            this.txtServePoint.Location = new System.Drawing.Point(151, 75);
            this.txtServePoint.Name = "txtServePoint";
            this.txtServePoint.Size = new System.Drawing.Size(172, 21);
            this.txtServePoint.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(151, 103);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(172, 21);
            this.txtUserName.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "用户名：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "密码：";
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(151, 131);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(172, 21);
            this.txtPassWord.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(61, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "服务器名称：";
            // 
            // txtServe
            // 
            this.txtServe.Location = new System.Drawing.Point(151, 19);
            this.txtServe.Name = "txtServe";
            this.txtServe.Size = new System.Drawing.Size(172, 21);
            this.txtServe.TabIndex = 1;
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 218);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtServe);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtServePoint);
            this.Controls.Add(this.txtServeIp);
            this.Controls.Add(this.btnSet);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器配置";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ConfigForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.TextBox txtServeIp;
        private System.Windows.Forms.TextBox txtServePoint;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtServe;
    }
}