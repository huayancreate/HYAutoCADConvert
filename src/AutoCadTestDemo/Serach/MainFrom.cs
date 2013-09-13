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
    public partial class MainFrom : Form
    {
        public MainFrom()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            MysqlOperate operate = new MysqlOperate();
            DataTable dt = operate.GetCodeDto(txtOldCode.Text);
            lbNewCode.DataSource = dt;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["NewCode"].ToString().Contains(txtOldCode.Text))
                {
                    lbNewCode.DisplayMember = "OldCode";
                    break;
                }
                else
                {
                    lbNewCode.DisplayMember = "NewCode";
                }
            }

        }

        private void btnEditPass_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Close();
            EditPassForm pass = new EditPassForm();
            pass.ShowDialog();
        }
    }
}
