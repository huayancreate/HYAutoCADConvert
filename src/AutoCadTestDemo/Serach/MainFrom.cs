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
            lbNewCode.DataSource = operate.GetCodeDto(txtOldCode.Text);
            lbNewCode.DisplayMember = "NewCode";
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
