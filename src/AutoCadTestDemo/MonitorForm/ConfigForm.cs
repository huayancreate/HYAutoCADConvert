using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace MonitorForm
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            SetAppSettings("123", "1231");
        }

        public string AppConfig()
        {
            int intPos = Application.StartupPath.Trim().IndexOf("bin") - 1;
            string strDirectoryPath = System.IO.Path.Combine(Application.StartupPath.Substring(0, intPos), "App.config");
            return strDirectoryPath;
        }

        public void SetAppSettings(string AppKey, string AppValue)
        {
            //System.Configuration.ConfigurationSettings.AppSettings.Set(AppKey,AppValue);
            XmlDocument doc = new XmlDocument();
            doc.Load(AppConfig());
            XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings");
            XmlElement ele = (XmlElement)node;
            //if (node != null)
            //    ele.SetAttribute("value", AppValue);
            //else
            //{
            XmlElement xElem2;
            xElem2 = doc.CreateElement("add");
            xElem2.SetAttribute("name", AppKey);
            xElem2.SetAttribute("connectionString", AppValue);
            node.AppendChild(xElem2);
            //}
            doc.Save(AppConfig());
        }

        private void ConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            this.Close();
            MainForm form = new MainForm();
            form.ShowDialog();
        }
    }
}
