using StudentRegistrationForm.DAL;
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
    public partial class LoginForm : DevExpress.XtraEditors.XtraForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        AdminDAL adminDAL = new AdminDAL();
        public static string userId = "0";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (textUsername.Text != "" && txtPassword.Text != "")
            {
                DataTable adminData = adminDAL.LoginData(textUsername.Text, txtPassword.Text);
                if (adminData.Rows.Count > 0)
                {
                    userId = adminData.Rows[0][0].ToString();
                    this.Hide();
                    DashboardForm dashboard = new DashboardForm();
                    dashboard.Show();

                }
                else
                {
                    MessageBox.Show("Please Enter Valid  Username or Password.");
                }

            }
            else
            {
                MessageBox.Show("Please Enter Username and Password.");

            }


        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            textUsername.Text = "";

            txtPassword.Text = "";
        }
    }
}
