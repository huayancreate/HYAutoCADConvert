using log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
//using System.Linq;
using System.Windows.Forms;

namespace AutoCadConvert
{
    static class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("logerror");
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //log4net 设定----------------------------------------------
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            FileInfo log4netConfigFile = new FileInfo("./log4net.config");
            if (!log4netConfigFile.Exists)
            {
                throw new FileNotFoundException(
                    Directory.GetCurrentDirectory() + " 中找不到log4net.config。", "log4net.config");
            }
            log4net.Config.XmlConfigurator.Configure(log4netConfigFile);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new Form1());
            //Bussiness.Process p = new Bussiness.Process();
            //p.Init();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string msg = GetExceptionMsg(e.Exception, e.ToString());

            logger.Error(msg);
            if (MessageBox.Show("系统出现异常：" + e.Exception.Message + "点击确定后退出程序！") == DialogResult.OK)
            {
                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("acad");
                foreach (System.Diagnostics.Process pkill in ps)
                {
                    pkill.Kill();
                }
                //Application.Exit();
            }
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string msg = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            var ex = e.ExceptionObject as Exception;
            logger.Error(msg);
            if (MessageBox.Show("系统出现异常：" + ex.Message + "点击确定后退出程序！") == DialogResult.OK)
            {
                System.Diagnostics.Process[] ps = System.Diagnostics.Process.GetProcessesByName("acad");
                foreach (System.Diagnostics.Process pkill in ps)
                {
                    pkill.Kill();
                }
                //Application.Exit();
            }
        }

        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }
    }
}
