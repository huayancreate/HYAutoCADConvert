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

namespace AutoCadTestDemo
{
    public partial class MainForm : Form
    {
        //AcadApplication AcadApp;
        AcadDocument AcadDoc;
        List<string> list = new List<string>();
        HSSFWorkbook hssfworkbook;
        //Regex regex = new Regex(@"^[a-zA-Z][a-zA-Z0-9]$");

        public MainForm()
        {
            InitializeComponent();
            lvwList.DataSource = null;
            btnOpenFiles.Enabled = false;

            lblTips.Text = "当前共有: 100000 张图纸需要处理,现在正在处理第 99999 张";
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
            var fileStaus = "";
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
                AcadDoc = acAppComObj.Documents.Open(FilePath, null, null);
                acAppComObj.Application.Visible = false;
                AcadBlocks blocks = AcadDoc.Blocks;
                HistoryDto dto = new HistoryDto();
                CodeDto codeDto = new CodeDto();
                dto.Id = Guid.NewGuid().ToString();
                dto.FileName = AcadDoc.Name;
                dto.FilePath = FilePath;
                try
                {
                    foreach (AcadBlock block in blocks)
                    {
                        foreach (AcadEntity entity in block)
                        {
                            list.Add(entity.ObjectName);

                            ////1.替换基本属性
                            //Util.ReplaceProperty(entity);
                            ////2.替换装配图的明细表编号
                            //Util.ReplaceDrawingCode(entity, acAppComObj);
                            //entity.Update();
                        }
                    }
                    fileStaus = "图纸处理完成";
                    dto.FileStatus = fileStaus;
                    //3.处理情况保存
                    //InsertHistory(dto);
                    codeDto.Id = Guid.NewGuid().ToString();
                    codeDto.OldCode = Util.oldCode;
                    codeDto.NewCode = Util.newCode;
                    //InsertCode(codeDto);
                }
                catch (Exception ex)
                {
                    fileStaus = "图纸处理异常，异常原因：" + ex.Message;
                    dto.FileStatus = fileStaus;
                    //3.处理情况保存
                    //InsertHistory(dto);
                    continue;
                }
                dto.FileStatus = fileStaus;

                //判断是否需要保存，如需要则另存为
                if (acAppComObj.ActiveDocument.Saved == false)
                {
                    acAppComObj.ActiveDocument.SaveAs(txtSavePath.Text + "\\" + Util.newCode, AcSaveAsType.ac2013_dwg, null);
                    GC.Collect();
                }
            }
            stopwatch.Stop(); //  停止监视
            TimeSpan timespan = stopwatch.Elapsed; //  获取当前实例测量得出的总时间
            double hours = timespan.TotalHours; // 总小时
            double minutes = timespan.TotalMinutes;  // 总分钟
            double seconds = timespan.TotalSeconds;  //  总秒数
            double milliseconds = timespan.TotalMilliseconds;  //  总毫秒数
            lvwList.DataSource = list;
            MessageBox.Show(fileStaus);
            //MessageBox.Show("图纸修改完成，修改所花时间为：" + seconds.ToString());
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
            Bussiness.Process p = new Bussiness.Process();
            p.Init();
            //UpdateCAD();
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

        void InsertHistory(HistoryDto dto)
        {
            MysqlOperate operate = new MysqlOperate();
            operate.InsertHistory(dto);
        }

        void InsertCode(CodeDto dto)
        {
            MysqlOperate operate = new MysqlOperate();
            operate.InsertCode(dto);
        }

        private void btnImportExcel_Click(object sender, EventArgs e)
        {
            Util.InitializeWorkbook(@"C:\Users\wliu\Desktop\修改的编号.xls");
        }
    }
}
