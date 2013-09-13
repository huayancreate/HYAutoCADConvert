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

namespace ExcelHandle
{
    public partial class ExcelHandleMainForm : Form
    {
        public ExcelHandleMainForm()
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
            FolderBrowserDialog fbdFile = new FolderBrowserDialog();
            if (fbdFile.ShowDialog() == DialogResult.OK)
            {
                txtExcelPath.Text = fbdFile.SelectedPath;
            }
        }
        /// <summary>
        /// 选择保存的文件路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSaveExcel_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbdFile = new FolderBrowserDialog();
            if (fbdFile.ShowDialog() == DialogResult.OK)
            {
                txtSaveExcelPath.Text = fbdFile.SelectedPath + @"\";
            }
        }
        /// <summary>
        /// 开始处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            List<string> _list = new List<string>();
            DirectoryInfo dir = new DirectoryInfo(txtExcelPath.Text);
            Bussiness.ExcelProcess.GetAllFiles(dir, _list);
            for (int i = 0; i < _list.Count; i++)
            {
                var fileName = Path.GetFileName(_list[i]);
                Bussiness.ExcelProcess process = new Bussiness.ExcelProcess();
                process.TargetfileName = fileName;
                process.TargetFilePath = txtSaveExcelPath.Text;
                FileStream file = new FileStream(_list[i], FileMode.Open, FileAccess.Read);
                process.Workbook = WorkbookFactory.Create(file);
                process.Run();
            }
            MessageBox.Show("处理完成");
        }
    }
}
