using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ExcelCopyFiles
{
    public partial class ExcelCopyFilesMainForm : Form
    {
        public ExcelCopyFilesMainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择Excel文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofdFile = new OpenFileDialog();
            if (ofdFile.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = ofdFile.FileName;
            }
        }

        private void btnSelPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdFile = new FolderBrowserDialog();
            if (fbdFile.ShowDialog() == DialogResult.OK)
            {
                txtSelPath.Text = fbdFile.SelectedPath;
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            Bussiness.CopyFileProcess process = new Bussiness.CopyFileProcess();
            process.SourceFilePath = txtSelPath.Text;
            process.TargetFilePath = txtSavePath.Text;
            string excelname = txtExcelPath.Text;
            FileInfo info = new FileInfo(excelname);
            process.ExcelFullName = info.DirectoryName + "\\new" + info.Name;
            FileStream file = new FileStream(txtExcelPath.Text, FileMode.Open, FileAccess.Read);
            process.Workbook = WorkbookFactory.Create(file);
            process.Run();
            MessageBox.Show("处理完成");
        }

        private void btnSavePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdFile = new FolderBrowserDialog();
            if (fbdFile.ShowDialog() == DialogResult.OK)
            {
                txtSavePath.Text = fbdFile.SelectedPath;
            }
        }
    }
}
