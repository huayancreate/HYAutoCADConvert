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

namespace Monitor
{
    public partial class ConfigForm : Form
    {
        private MainForm mainForm;

        public ConfigForm()
        {
            InitializeComponent();
        }

        public ConfigForm(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
        }

        /// <summary>
        /// 保存配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSet_Click(object sender, EventArgs e)
        {
            this.SetAppSettings(this.txtServe.Text, "Data Source=" + this.txtServeIp.Text + ";User ID=" + this.txtUserName.Text + ";Password=" + this.txtPassWord.Text + ";DataBase=autocad;Charset=gb2312");
            this.Visible = false;
            this.Close();
            this.mainForm.LoadForm();
        }
        public void SetAppSettings(string AppKey, string AppValue)
        {
            //System.Configuration.ConfigurationSettings.AppSettings.Set(AppKey,AppValue);
            XmlDocument doc = new XmlDocument();
            //doc.Load(Application.ExecutablePath + ".config");
            var configPath = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            doc.Load(configPath);
            XmlNode node = doc.SelectSingleNode("/configuration/connectionStrings");
            XmlElement ele = (XmlElement)node;
            XmlNodeList elemList = ele.GetElementsByTagName("add");
            foreach (XmlElement obj in elemList)
            {
                if (obj.GetAttribute("name") == AppKey)
                {
                    MessageBox.Show("当前系统检测到配置文件中存在服务器名称为：" + AppKey + "，请重新输入新的服务器名称！");
                    return;
                }
            }
            XmlElement xElem2;
            xElem2 = doc.CreateElement("add");
            xElem2.SetAttribute("name", AppKey);
            xElem2.SetAttribute("connectionString", AppValue);
            node.AppendChild(xElem2);
            doc.Save(Application.ExecutablePath + ".config");
            doc.Load(Application.ExecutablePath + ".config");
        }
    }
}
