using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Desktop_Information_System
{
    public partial class Homepage : Form
    {
        private AddDataPage addDataPage = new AddDataPage();

        public Homepage()
        {
            InitializeComponent();
        }

        private void addUserControl(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            panelContainer.Controls.Clear();
            panelContainer.Controls.Add(userControl);
            userControl.BringToFront();
        }

        private void addDataBtn_Click(object sender, EventArgs e)
        {
            addUserControl(addDataPage);
        }

        private void viewAllBtn_Click(object sender, EventArgs e)
        {
            ViewAllPage viewAllPage = new ViewAllPage();
            addUserControl(viewAllPage);
        }

        private void viewByUserGroupBtn_Click(object sender, EventArgs e)
        {
            ViewByUserGroupPage viewByUserGroupPage = new ViewByUserGroupPage();
            addUserControl(viewByUserGroupPage);
        }
    }
}
