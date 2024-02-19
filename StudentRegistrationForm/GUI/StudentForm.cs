using DevExpress.XtraEditors;
using StudentRegistrationForm.BLL;
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
    public partial class StudentForm : DevExpress.XtraEditors.XtraForm
    {
        public StudentForm()
        {
            InitializeComponent();
        }

        StudentDAL studentDal = new StudentDAL();
        StudentBll studentBll = new StudentBll();
        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            dgvStudent.DataSource = studentDal.SelectData();

        }
        void Clear()
        {
            txtId.Text = "";
            txtPhone.Text = "";
            cmbBlood.Text = "";
            txtName.Text = "";
            cmdgender.Text = "";
            txtEmail.Text = "";
            txtDesc.Text = "";
            cmbDob.Text = "";
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtPhone.Text != "" && cmbBlood.Text != "" &&
                cmdgender.Text != "" && txtEmail.Text != "" && txtDesc.Text != "" && cmbDob.Text != "")
            {
                studentBll.Name = txtName.Text;
                studentBll.Phone = txtPhone.Text;
                studentBll.Blood = cmbBlood.Text;
                studentBll.Gender = cmdgender.Text;
                studentBll.Email = txtEmail.Text;
                studentBll.Description = txtDesc.Text;
                studentBll.Dob = cmbDob.Text;

                if (studentDal.InsertData(studentBll))
                {
                    MessageBox.Show("Data Saves Succesfully");
                    dgvStudent.DataSource = studentDal.SelectData();
                    Clear();

                }
            }
            else
            {
                MessageBox.Show("Plese fill  all the fields");
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (txtId.Text != "")
            {
                if (txtName.Text != "" && txtPhone.Text != "" && cmbBlood.Text != "" &&
                cmdgender.Text != "" && txtEmail.Text != "" && txtDesc.Text != "" && cmbDob.Text != "")
                {
                    studentBll.Id = int.Parse(txtId.Text);
                    studentBll.Name = txtName.Text;
                    studentBll.Phone = txtPhone.Text;
                    studentBll.Blood = cmbBlood.Text;
                    studentBll.Gender = cmdgender.Text;
                    studentBll.Email = txtEmail.Text;
                    studentBll.Description = txtDesc.Text;
                    studentBll.Dob = cmbDob.Text;

                    if (studentDal.UpdateData(studentBll))
                    {
                        MessageBox.Show("Data Updated Succesfully");
                        dgvStudent.DataSource = studentDal.SelectData();
                        Clear();

                    }
                }
                else
                {
                    MessageBox.Show("Plese fill  all the fields");
                }

            }
            else
            {
                MessageBox.Show("Plese Select the record first");

            }
        }

        private void gridStudent_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = gridStudent.GetDataRow(gridStudent.GetSelectedRows()[0]);

            if(row == null || row [0].ToString() == "")
            {
                return;
            }
            //tabControl.SelectedTabPage = addStudent;
            txtId.Text = row[0].ToString();
            txtName.Text = row[1].ToString();
            txtPhone.Text = row[2].ToString();
            cmbBlood.Text = row[3].ToString();           
            cmdgender.Text = row[4].ToString();
            cmbDob.Text = row[5].ToString();
            txtEmail.Text = row[6].ToString();
            txtDesc.Text = row[7].ToString();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            dgvStudent.ShowPrintPreview();
        }

        private void dgvStudent_Click(object sender, EventArgs e)
        {

        }
    }

    //private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //}
}
