using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorForm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadForm();
        }

        private void btnSystemConfig_Click(object sender, EventArgs e)
        {
            ConfigForm form = new ConfigForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadForm();
            }
        }

        private void LoadForm()
        {
            MainPanel.Controls.Clear();
            MyTabPage tabPage = new MyTabPage();
            MainPanel.Controls.Add(tabPage);
        }

        private void tmrLoad_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            LoadForm();
        }
    }
}
