using AutoCAD;
using AutoCadTestDemo.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace AutoCadTestDemo.Bussiness
{
    public class Process
    {
        public List<AbstractTask> taskList = new List<AbstractTask>();
        private Rules rules;
        private AbstractTask task;
        private AcadApplication acAppComObj = null;

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
            InitProcess();
            InitThreadPool();
            InitRules();
            InitTask();
            Run();
        }

        private void InitProcess()
        {
            this.Open();
            Thread.Sleep(10000);
            string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
            DirectoryInfo dir = new DirectoryInfo(filePath);
            Util.GetAllFiles(dir);
            Util.GetDrwingsList();
            List<HistoryDto> list = Util.drwings;
        }

        private void Run()
        {
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
            List<HistoryDto> drwings = Util.drwings;
            //drwings.Add(@"C:\Users\wliu\Desktop\chengxu\新建文件夹\DRU0000562.dwg");
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
