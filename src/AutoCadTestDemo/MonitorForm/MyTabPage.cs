using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using Monitor;

namespace Monitor
{
    public partial class MyTabPage : UserControl
    {
        public MyTabPage()
        {
            InitializeComponent();
        }

        public void LoadControl(Hashtable hash)
        {
            //tabControl1.TabPages.
            TabControl tabc = new TabControl();
            tabc.Size = new Size(652, 320);
            foreach (DictionaryEntry de in hash)
            {
                var dbUtil = Operate(de.Value.ToString());
                TabPage tabpage = new TabPage();
                tabpage.Name = de.Key.ToString();
                tabpage.Text = de.Key.ToString();
                Label label1 = new Label();
                label1.AutoSize = true;
                label1.Location = new System.Drawing.Point(23, 36);
                label1.Name = "label1";
                label1.Size = new System.Drawing.Size(113, 12);
                label1.TabIndex = 0;
                label1.Text = "当前共需处理图纸：";

                Label label2 = new Label();
                label2.AutoSize = true;
                label2.Location = new System.Drawing.Point(142, 36);
                label2.Name = "label2";
                label2.Size = new System.Drawing.Size(41, 12);
                label2.TabIndex = 1;
                label2.Text = dbUtil.DrwingsCount("").ToString();

                Label label3 = new Label();
                label3.AutoSize = true;
                label3.Location = new System.Drawing.Point(394, 36);
                label3.Name = "label3";
                label3.Size = new System.Drawing.Size(41, 12);
                label3.TabIndex = 3;
                label3.Text = dbUtil.DrwingsCount("1").ToString();

                Label label4 = new Label();
                label4.AutoSize = true;
                label4.Location = new System.Drawing.Point(311, 36);
                label4.Name = "label4";
                label4.Size = new System.Drawing.Size(77, 12);
                label4.TabIndex = 2;
                label4.Text = "已处理图纸：";

                Label label5 = new Label();
                label5.AutoSize = true;
                label5.Location = new System.Drawing.Point(106, 85);
                label5.Name = "label5";
                label5.Size = new System.Drawing.Size(41, 12);
                label5.TabIndex = 5;
                label5.Text = GetRemainTime(dbUtil);

                Label label6 = new Label();
                label6.AutoSize = true;
                label6.Location = new System.Drawing.Point(23, 85);
                label6.Name = "label6";
                label6.Size = new System.Drawing.Size(77, 12);
                label6.TabIndex = 4;
                label6.Text = "已处理时间：";

                Label label7 = new Label();
                label7.AutoSize = true;
                label7.Location = new System.Drawing.Point(406, 85);
                label7.Name = "label7";
                label7.Size = new System.Drawing.Size(41, 12);
                label7.TabIndex = 7;
                label7.Text = GetFinishTime(int.Parse(label2.Text), int.Parse(label3.Text), dbUtil);

                Label label8 = new Label();
                label8.AutoSize = true;
                label8.Location = new System.Drawing.Point(311, 85);
                label8.Name = "label8";
                label8.Size = new System.Drawing.Size(89, 12);
                label8.TabIndex = 6;
                label8.Text = "预计结束时间：";

                tabpage.Controls.Add(label1);
                tabpage.Controls.Add(label2);
                tabpage.Controls.Add(label3);
                tabpage.Controls.Add(label4);
                tabpage.Controls.Add(label5);
                tabpage.Controls.Add(label6);
                tabpage.Controls.Add(label7);
                tabpage.Controls.Add(label8);
                //tabpage.Controls.Add(lblResult);
                tabc.Controls.Add(tabpage);
            }
            this.Controls.Add(tabc);
        }

        public MysqlOperate Operate(string connectionStr)
        {
            return new MysqlOperate(connectionStr);
        }

        public string GetRemainTime(MysqlOperate operate)
        {
            DateTime dt = operate.GetInitDateTime();
            DateTime dtNow = DateTime.Now;
            TimeSpan ts = dtNow - dt;
            return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
        }

        public string GetFinishTime(int Count, int processCount, MysqlOperate operate)
        {
            DateTime dt = operate.GetInitDateTime();
            DateTime dtNow = DateTime.Now;
            TimeSpan ts = dtNow - dt;
            if (processCount != 0)
            {
                var temp = ts.TotalSeconds / processCount;
                var finish = Convert.ToInt32((Count - processCount) * temp);
                TimeSpan tsFinish = new TimeSpan(0, 0, finish);
                return tsFinish.Hours.ToString() + "小时" + tsFinish.Minutes.ToString() + "分钟" + tsFinish.Seconds.ToString() + "秒";
            }
            return "0小时0分钟0秒";
        }

        private void MyTabPage_Load(object sender, EventArgs e)
        {
        }
    }
}
