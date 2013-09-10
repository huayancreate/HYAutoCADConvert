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
    public partial class EditPassForm : Form
    {
        public EditPassForm()
        {
            InitializeComponent();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            MysqlOperate operate = new MysqlOperate();
            if (!txtNewPass.Text.Trim().Equals(txtAgainPass.Text.Trim()))
            {
                MessageBox.Show("新密码和重复新密码不一致，请重新输入！");
                return;
            }
            if (!operate.UpdatePass(txtOldPass.Text, txtNewPass.Text))
            {
                MessageBox.Show("密码修改失败，请检查原始密码是否正确？");
            }
            else
            {
                if (MessageBox.Show("密码修改成功，请重新登录！") == DialogResult.OK)
                {
                    this.Visible = false;
                    this.Close();
                    LoginForm login = new LoginForm();
                    login.Show();
                }

            }
        }

        private void EditPassForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Visible = false;
            this.Close();
            MainFrom form = new MainFrom();
            form.ShowDialog();
        }
    }
}
