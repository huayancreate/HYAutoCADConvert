using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Monitor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ConfigSettings();
            LoadForm();

        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            if (new ConfigForm(this).ShowDialog() != DialogResult.OK)
            {
                return;
            }
            //this.LoadForm();
        }

        public void LoadForm()
        {
            this.MainPanel.Controls.Clear();
            Hashtable hash = GetAppSettings();
            LoadControl(hash);
        }

        private void tmrLoad_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LoadForm();
            //this.Refresh();
        }

        private Hashtable GetAppSettings()
        {
            Hashtable hash = new Hashtable();
            hash.Clear();
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings");
            XmlElement ele = (XmlElement)node;
            XmlNodeList elemList = ele.GetElementsByTagName("add");
            foreach (XmlElement obj in elemList)
            {
                hash.Add(obj.GetAttribute("name"), obj.GetAttribute("connectionString"));
            }
            return hash;
        }

        public void LoadControl(Hashtable hash)
        {
            int num = 0;
            foreach (DictionaryEntry dictionaryEntry in hash)
            {
                MysqlOperate operate = this.Operate(dictionaryEntry.Value.ToString());
                if (operate.OpenConnection() == true)
                {
                    MyGroupBox myGroupBox = new MyGroupBox();
                    myGroupBox.gbxDwgDetail.Text = dictionaryEntry.Key.ToString();
                    myGroupBox.Location = new Point(5, 3 + num * 94);
                    myGroupBox.lblDwgCount.Text = operate.DrwingsCount("").ToString();
                    myGroupBox.lblErrorDwgCount.Text = operate.DrwingsCount("2").ToString();
                    myGroupBox.lblProcessDwgCount.Text = operate.DrwingsCount("1").ToString();
                    myGroupBox.lblProcessEndTime.Text = this.GetFinishTime(int.Parse(myGroupBox.lblDwgCount.Text), int.Parse(myGroupBox.lblProcessDwgCount.Text), int.Parse(myGroupBox.lblErrorDwgCount.Text), operate);
                    myGroupBox.lblProcessTime.Text = this.GetRemainTime(operate);
                    this.MainPanel.Controls.Add((Control)myGroupBox);
                    ++num;
                }
                else
                {
                    continue;
                }
            }
        }

        public MysqlOperate Operate(string connectionStr)
        {
            return new MysqlOperate(connectionStr);
        }

        public string GetRemainTime(MysqlOperate operate)
        {
            var dateTime = operate.GetInitDateTime();
            if (!string.IsNullOrEmpty(dateTime))
            {
                DateTime dt = new DateTime();
                dt = Convert.ToDateTime(dateTime);
                DateTime dtNow = DateTime.Now;
                TimeSpan ts = dtNow - dt;
                return ts.Hours.ToString() + "小时" + ts.Minutes.ToString() + "分钟" + ts.Seconds.ToString() + "秒";
            }
            return "0小时0分钟0秒";
        }

        public string GetFinishTime(int Count, int processCount, int errorCount, MysqlOperate operate)
        {
            var dateTime = operate.GetInitDateTime();
            if (!string.IsNullOrEmpty(dateTime))
            {
                DateTime dt = new DateTime();
                DateTime dtNow = DateTime.Now;
                TimeSpan ts = dtNow - Convert.ToDateTime(dt);
                var remainCount = Count - (processCount + errorCount);
                if (remainCount != 0)
                {
                    if (processCount != 0)
                    {
                        var temp = ts.TotalSeconds / processCount;
                        var finish = Convert.ToInt32((Count - processCount) * temp);
                        TimeSpan tsFinish = new TimeSpan(0, 0, finish);
                        return tsFinish.Hours.ToString() + "小时" + tsFinish.Minutes.ToString() + "分钟" + tsFinish.Seconds.ToString() + "秒";
                    }
                    else
                    {
                        return "0小时0分钟0秒";
                    }
                }
            }
            return "0小时0分钟0秒";
        }

        private void ConfigSettings()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings");
            XmlElement ele = (XmlElement)node;
            XmlNodeList elemList = ele.GetElementsByTagName("add");
            if (elemList.Count <= 0)
            {
                var msg = "系统检测到还没有配置检测服务器，是否配置?";
                if (MessageBox.Show(msg, "系统提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    ConfigForm form = new ConfigForm(this);
                    form.ShowDialog();
                }
            }
        }
    }
}
