using AutoCAD;
using AutoCadConvert.Config;
using Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoCadConvert.Bussiness
{
    public class Process
    {
        public List<AbstractTask> taskList = new List<AbstractTask>();
        private Rules rules;
        private AbstractTask task;
        private AcadApplication acAppComObj = null;
        private int currentPage = 0;

        private void Open()
        {
            const string strProgId = "AutoCAD.Application";
            //获取正在运行的AutoCAD实例；
            try
            {
                acAppComObj = (AcadApplication)Marshal.GetActiveObject(strProgId);
            }
            catch //没有正在运行的实例时出错；
            {
                try
                {
                    //创建新的AutoCAD实例；
                    acAppComObj = (AcadApplication)Activator.CreateInstance(Type.GetTypeFromProgID(strProgId), true);
                }
                catch
                {
                    //创建新实例不成功就显示信息并退出；
                    //MessageBox.Show("创建新实例不成功");
                    return;
                }
            }
        }

        public void Init()
        {
            if (Util.GetInitTime() == null) Util.InitDateTime();
            InitRules();
            InitProcess();
            InitThreadPool();
            InitTask();
        }

        private void InitProcess()
        {
            this.Open();
            Thread.Sleep(10000);
            string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
            DirectoryInfo dir = new DirectoryInfo(filePath);
            Util.GetAllFiles(dir, rules);
        }

        private void Run()
        {
            if (taskList.Count == 0)
            {
                return;
            }
            foreach (AbstractTask task in taskList)
            {
                task.AcAppComObj = this.acAppComObj;
                task.Run();
                if (!task.KillFlag)
                {
                    this.acAppComObj = null;
                    this.Open();
                    Thread.Sleep(10000);
                }
            }
            taskList.Clear();
            currentPage++;
            InitTask();
        }

        private void InitThreadPool()
        {
            ThreadPool.SetMaxThreads(ConfigConstant.MAX_TASKS, ConfigConstant.MAX_TASKS);
        }

        private void InitRules()
        {
            rules = GetRules();
        }

        private Rules GetRules()
        {
            //TODO
            Rules rules = new Rules();
            if (!File.Exists(ConfigurationManager.AppSettings["xls"].ToString()))
                return null;
            DataSet ds = Util.InitializeWorkbook(ConfigurationManager.AppSettings["xls"].ToString());
            int count = ds.Tables[0].Rows.Count;
            for (int i = 1; i < count; i++)//从第二行开始读取数据
            {
                rules.SetRules(ds.Tables[0].Rows[i][0].ToString(), ds.Tables[0].Rows[i][1].ToString());
                CreateDir(ds.Tables[0].Rows[i][1].ToString());
            }
            CreateDir("失败的图纸文件");
            return rules;
        }

        private void InitTask()
        {
            //TODO 获取需要执行的任务
            List<HistoryDto> drwings = Util.GetDrwingsList(currentPage);
            for (int i = 0; i < drwings.Count; i++)
            {
                task = TaskFactroy.CreateTaskByType(TaskType.DefaultTask);
                task.AbsPath = drwings[i].FilePath;
                task.AcAppComObj = this.acAppComObj;
                task.SavePath = ConfigurationManager.AppSettings["savePath"].ToString();
                task.SetDefaultRules(rules);
                task.TaskName = drwings[i].FileName;
                task.Init();
                taskList.Add(task);
            }
            Run();
        }
        private void CreateDir(string name)
        {
            var path = ConfigurationManager.AppSettings["savePath"].ToString() + name;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
