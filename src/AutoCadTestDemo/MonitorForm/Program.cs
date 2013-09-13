using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Monitor
{
    static class Program
    {
        private static ApplicationContext context;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoadForm load = new LoadForm();
            load.Show();
            context = new ApplicationContext();
            context.Tag = load;
            Application.Idle += new EventHandler(Application_Load); //注册程序运行空闲去执行主程序窗体相应初始化代码
            Application.Run(context);
        }

        private static void Application_Load(object sender, EventArgs e)
        {
            Application.Idle -= new EventHandler(Application_Load);
            if (context.MainForm == null)
            {
                MainForm main = new MainForm();
                context.MainForm = main;
                LoadForm load = (LoadForm)context.Tag;
                load.Close();
                main.Show();
            }
        }
    }
}
