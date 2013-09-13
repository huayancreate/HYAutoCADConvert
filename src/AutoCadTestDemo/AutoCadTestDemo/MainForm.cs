using AutoCAD;
using SymBBAuto;
using AcadmAuto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Runtime.InteropServices;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Common;
using System.Xml;
using System.Configuration;

namespace AutoCadConvert
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadConfig();
        }


        /// <summary>
        /// 修改CAD图纸内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSelectPath.Text))
            {
                MessageBox.Show("请选择待处理文件路径！");
                return;
            }
            if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                MessageBox.Show("请选保存文件路径！");
                return;
            }
            if (string.IsNullOrEmpty(txtExcelPath.Text))
            {
                MessageBox.Show("请选择Excel文件路径！");
                return;
            }
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Bussiness.Process p = new Bussiness.Process();
            p.Init();
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            Util.UpdateConfg();
            MessageBox.Show("图纸修改完成，修改所花时间为：" + seconds.ToString());
            //UpdateCAD();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try
            //{
            //    acAppComObj.Quit();
            //}
            //catch
            //{

            //}
        }
        /// <summary>
        /// 选择保存文件位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelect_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdFile = new FolderBrowserDialog();
            fbdFile.ShowDialog();
            txtExcelPath.Text = fbdFile.SelectedPath;
        }

        public string AppConfig
        {
            get
            {
                int intPos = Application.StartupPath.Trim().IndexOf("bin") - 1;
                string strDirectoryPath = System.IO.Path.Combine(Application.StartupPath.Substring(0, intPos), "App.config");
                return strDirectoryPath;
            }
        }

        public void SetAppSettings(string AppKey, string AppValue)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Application.ExecutablePath + ".config");
            XmlNode node = doc.SelectSingleNode(@"//add[@key='" + AppKey + "']");
            XmlElement ele = (XmlElement)node;
            if (node != null)
                ele.SetAttribute("value", AppValue);
            else
            {
                XmlElement xElem2;
                xElem2 = doc.CreateElement("add");
                xElem2.SetAttribute("key", AppKey);
                xElem2.SetAttribute("value", AppValue);
                node.AppendChild(xElem2);
            }
            doc.Save(Application.ExecutablePath + ".config");
            LoadConfig();
        }

        /// <summary>
        /// 选择待处理的图纸文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFile = new FolderBrowserDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                txtSelectPath.Text = saveFile.SelectedPath + @"\";
                SetAppSettings("filePath", txtSelectPath.Text.Trim());
            }
        }

        /// <summary>
        /// 选择保存的文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectSave_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saveFile = new FolderBrowserDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = saveFile.SelectedPath + @"\";
                SetAppSettings("savePath", txtSavePath.Text.Trim());
            }
        }

        /// <summary>
        /// 选择Excel的文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog saveFile = new OpenFileDialog();
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = saveFile.FileName;
                SetAppSettings("xls", txtExcelPath.Text.Trim());
            }
        }

        private void LoadConfig()
        {
            var xlsPath = Util.GetXmlValue("xls");//ConfigurationManager.AppSettings["xls"].ToString();
            if (!string.IsNullOrEmpty(xlsPath))
            {
                txtExcelPath.Text = xlsPath;
            }
            var savePath = Util.GetXmlValue("savePath");//ConfigurationManager.AppSettings["savePath"].ToString();
            if (!string.IsNullOrEmpty(savePath))
            {
                txtSavePath.Text = savePath;
            }
            var filePath = Util.GetXmlValue("filePath");//ConfigurationManager.AppSettings["filePath"].ToString();
            if (!string.IsNullOrEmpty(filePath))
            {
                txtSelectPath.Text = filePath;
            }
        }
    }
}
