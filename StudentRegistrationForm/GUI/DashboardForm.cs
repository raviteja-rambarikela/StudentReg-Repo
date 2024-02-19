using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationForm
{
    public partial class DashboardForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public DashboardForm()
        {
            InitializeComponent();
        }

        private void barButtonItem7_ItemClick(object sender, ItemClickEventArgs e)
        {
            ThemeForm theme = new ThemeForm();
            theme.MdiParent = this;
            theme.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void barButtonItem9_ItemClick(object sender, ItemClickEventArgs e)
        {
            AboutForm about = new AboutForm();
            about.MdiParent = this;
            about.Show();

        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            StudentForm student = new StudentForm();
            student.MdiParent = this;
            student.Show();
        }

        private void barButtonItem4_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}