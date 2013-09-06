using Search;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Serach
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MysqlOperate operate = new MysqlOperate();
            if (!operate.UserLogin(txtUserName.Text, txtUserPass.Text))
            {
                MessageBox.Show("登录失败，请检查用户名或密码");
            }
            else
            {
                this.Visible = false;
                MainFrom form = new MainFrom();
                form.ShowDialog();
            }
        }
    }
}
