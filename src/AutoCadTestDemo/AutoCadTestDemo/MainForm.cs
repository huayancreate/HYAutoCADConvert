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

namespace AutoCadTestDemo
{
    public partial class MainForm : Form
    {
        //AcadApplication AcadApp;
        AcadDocument AcadDoc;
        List<string> list = new List<string>();
        Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]$");

        public MainForm()
        {
            InitializeComponent();
            lvwList.DataSource = null;
            btnOpenFiles.Enabled = false;
        }

        /// <summary>
        /// 选择要编辑的图纸
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFiles_Click(object sender, EventArgs e)
        {
            var count = 0;
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    DirectoryInfo dir = new DirectoryInfo(dialog.SelectedPath);
            //    count = GetAllFiles(dir);
            //}
            OpenFileDialog ofdFile = new OpenFileDialog();
            ofdFile.Filter = "CAD文件(*.dwg)|*.dwg|CAD图形文件(*.dxf)|*.dxf";
            ofdFile.Title = "打开CAD文件";
            ofdFile.Multiselect = true;
            ofdFile.ShowDialog();

            if (ofdFile.FileName == "")
            {
                MessageBox.Show("选择CAD文件无效", "文件无效"); return;
            }
            string[] FileList = ofdFile.FileNames;
            lvwList.DataSource = FileList;
            btnUpdate.Enabled = true;
            lblTips.Text = "当前共有: " + count + " 张图纸需要处理";

        }
        public int GetAllFiles(DirectoryInfo dir)
        {
            var j = 0;
            FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
            foreach (FileSystemInfo info in fileinfo)
            {
                if (info is DirectoryInfo)
                {
                    GetAllFiles((DirectoryInfo)info);
                }
                else
                {
                    j++;
                    var extension = info.Extension;
                    if (extension.Equals(".dwg") || extension.Equals(".dwt") || extension.Equals(".dws") || extension.Equals(".dxf"))
                    {
                        this.lvwList.Items.Add(info.FullName);
                    }
                }
            }
            return j;
        }

        private void UpdateCAD()
        {
            var showInfo = "";
            if (string.IsNullOrEmpty(txtSavePath.Text))
            {
                MessageBox.Show("请选择文件保存位置！", "提示信息"); return;
            }
            var FilePath = "";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int k = 0; k < lvwList.Items.Count; k++)
            {
                lblTips.Text = "当前共有: " + lvwList.Items.Count + " 张图纸需要处理,现在正在处理第 " + (k + 1) + " 张";
                FilePath = lvwList.Items[k].ToString();

                //启动线程去处理

                AcadDoc = acAppComObj.Documents.Open(FilePath, null, null);
                acAppComObj.Application.Visible = false;
                AcadBlocks blocks = AcadDoc.Blocks;

                foreach (AcadBlock block in blocks)
                {
                    foreach (AcadEntity entity in block)
                    {
                        //if (entity.ObjectName == "AcDbBlockReference")
                        //{
                        //    var s = ((AcadBlockReference)entity);
                        //    if (s.HasAttributes)
                        //    {
                        //        AcadAttributeReference bb;
                        //        object[] aa = (object[])s.GetAttributes();
                        //        for (int i = 0; i < aa.Length; i++)
                        //        {
                        //            bb = aa[i] as AcadAttributeReference;
                        //            if (bb != null)
                        //            {
                        //                if (bb.TagString != "---------" && bb.TagString != "------" && !bb.TagString.Contains("GEN-TITLE-MAT") && !bb.TagString.Contains("GEN-TITLE-DES") && bb.TagString != "01" && !bb.TagString.Contains("GEN-TITLE-SCA{6.14,1}"))
                        //                {
                        //                    bb.TextString = "";
                        //                }
                        //                if (regex.IsMatch(bb.TextString))
                        //                {
                        //                    OleDbParameter[] parameters = new OleDbParameter[2];
                        //                    parameters[0] = new OleDbParameter("@OldCode", OleDbType.VarChar, 50);
                        //                    parameters[0].Value = bb.TextString;
                        //                    parameters[1] = new OleDbParameter("@NewCode", OleDbType.VarChar, 50);
                        //                    parameters[1].Value = bb.TextString;
                        //                    AccessDBUtil.ExecuteInsert("insert into code (OldCode,NewCode) values(?,?)", parameters);
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        //else if (entity.ObjectName == "AcDbMText")
                        //{
                        //    AcadMText mtext = entity as AcadMText;
                        //    if (mtext != null)
                        //    {
                        //        if (mtext.TextString.Contains("FAX") || mtext.TextString.Contains("TEL") || mtext.TextString.Contains("TOMITA"))
                        //        {
                        //            mtext.TextString = "";
                        //        }
                        //    }
                        //}
                        //else
                        if (entity.ObjectName == "AcmPartRef")
                        {
                            AXDBLib.AcadObject obj = entity as AXDBLib.AcadObject;
                            McadSymbolBBMgr symbb = (McadSymbolBBMgr)acAppComObj.GetInterfaceObject("SymBBAuto.McadSymbolBBMgr");
                            McadBOMMgr bommgr = (McadBOMMgr)symbb.BOMMgr;
                            var number = bommgr.GetPartAttribute(obj, "DESCR", false);
                            showInfo += "\n" + number;

                            //if (regex.IsMatch(number))
                            //{
                            //    string newCode = getByNewCode(number);
                            //    if (!string.IsNullOrEmpty(newCode))
                            //        bommgr.SetPartAttribute(obj, "DESCR", newCode);
                            //}
                        }
                        //entity.Update();
                    }
                }
                //if (acAppComObj.ActiveDocument.Saved == false)
                //{
                //    acAppComObj.ActiveDocument.SaveAs(txtSavePath.Text + "\\" + AcadDoc.Name, AcSaveAsType.ac2013_dwg, null);
                //    InsertHistory(AcadDoc.Name, "成功");
                //    GC.Collect();
                //}
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            MessageBox.Show("图纸修改完成，修改所花时间为：" + seconds.ToString());
            MessageBox.Show(showInfo);
        }

        private void StartCAD()
        {
            OpenCad();
        }
        /// <summary>
        /// 修改CAD图纸内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //worker = new BackgroundWorker();
            //worker.WorkerReportsProgress = true;
            //worker.WorkerSupportsCancellation = true;
            //worker.DoWork += new DoWorkEventHandler(UpdateCad_DoWork);
            //worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //worker.RunWorkerAsync();
            UpdateCAD();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                acAppComObj.Quit();
            }
            catch
            {

            }
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
            txtSavePath.Text = fbdFile.SelectedPath;
        }

        private void btnStartPorcess_Click(object sender, EventArgs e)
        {
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            //Stopwatch stopwatch = new Stopwatch();
            //stopwatch.Start();
            //StartCAD();
            //btnOpenFiles.Enabled = true;
            //stopwatch.Stop(); //  停止监视
            //TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            //double hours = timespan.TotalHours; // 总小时
            //double minutes = timespan.TotalMinutes;  // 总分钟
            //double seconds = timespan.TotalSeconds;  //  总秒数
            //double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            //MessageBox.Show("CAD启动时间：" + seconds.ToString());
            worker.RunWorkerAsync();
        }

        void BindData()
        {
            //DataSet ds = AccessDBUtil.ExecuteQuery("select * from code");
            //lvwList.DataSource = ds.Tables[0].Rows[0].ItemArray;
            //int result = AccessDBUtil.ExecuteInsert("insert into code (OldCode,NewCode) values ('1','1')");
        }

        void WriteReaderTxt(string dwgName)
        {
            if (!File.Exists(Application.StartupPath + "\\图纸处理记录.txt"))
            {
                FileStream fs1 = new FileStream(Application.StartupPath + "\\图纸处理记录.txt", FileMode.Create, FileAccess.Write);//创建写入文件   
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(dwgName + "  处理完成");//
                sw.Close();
                fs1.Close();
            }
            else
            {
                FileStream fs1 = new FileStream(Application.StartupPath + "\\图纸处理记录.txt", FileMode.Append, FileAccess.Write);//读取写入文件   
                StreamWriter sw = new StreamWriter(fs1);
                sw.WriteLine(dwgName + "  处理完成");//
                sw.Close();
                fs1.Close();
            }
        }

        AcadApplication acAppComObj = null;
        void OpenCad()
        {
            const string strProgId = "AutoCAD.Application";
            // Get a running instance of AutoCAD获取正在运行的AutoCAD实例；
            try
            {
                acAppComObj = (AcadApplication)Marshal.GetActiveObject(strProgId);
            }
            catch // An error occurs if no instance is running没有正在运行的实例时出错；
            {
                try
                {
                    // Create a new instance of AutoCAD创建新的AutoCAD实例；
                    acAppComObj = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(strProgId), true);
                }
                catch
                {
                    // If an instance of AutoCAD is not created then message and exit创建新实例不成功就显示信息并退出；
                    MessageBox.Show("创建新实例不成功");

                    return;
                }
            }
        }

        public static string getByNewCode(string oldCode)
        {
            string sql = "select newcode from code where oldcode=?";
            OleDbParameter[] parameters = new OleDbParameter[1];
            parameters[0] = new OleDbParameter("@oldCode", OleDbType.VarChar, 50);
            parameters[0].Value = oldCode;
            DataSet ds = AccessDBUtil.ExecuteQuery(sql, parameters);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    return row["newcode"].ToString();
                }
            }
            return "";
        }

        #region 异步操作测试
        private BackgroundWorker worker = null;
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("取消操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else if (e.Error != null)
            {
                MessageBox.Show("出现错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                btnOpenFiles.Enabled = true;
            }
        }

        //private void UpdateCad_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{
        //    if (e.Cancelled)
        //    {
        //        MessageBox.Show("取消操作", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    }
        //    else if (e.Error != null)
        //    {
        //        MessageBox.Show("出现错误", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    else
        //    {
        //        MessageBox.Show("图纸修改完成", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //StartCAD();
            //UpdateCAD();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            OpenCadWork((BackgroundWorker)sender, e);
        }

        private void OpenCadWork(BackgroundWorker worke, DoWorkEventArgs e)
        {
            OpenCad();
            Thread.Sleep(2000);
            //AcadDoc.SendCommand("sdi\n0\n");
            //AcadDoc.SendCommand("taskbar\n0\n");
            //StartCAD();
        }

        //private void UpdateCad_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    UpdateCadDoWork((BackgroundWorker)sender, e);
        //    //Test((BackgroundWorker)sender, e);
        //}

        //private void UpdateCadDoWork(BackgroundWorker worker, DoWorkEventArgs e)
        //{
        //    UpdateCAD();
        //}
        #endregion

        void InsertHistory(string fileName, string state)
        {
            OleDbParameter[] parameters = new OleDbParameter[2];
            parameters[0] = new OleDbParameter("@FileName", OleDbType.VarChar, 50);
            parameters[0].Value = fileName;
            parameters[1] = new OleDbParameter("@State", OleDbType.VarChar, 50);
            parameters[1].Value = state;
            AccessDBUtil.ExecuteInsert("insert into History (FileName,State) values(?,?)", parameters);
        }
    }
}
