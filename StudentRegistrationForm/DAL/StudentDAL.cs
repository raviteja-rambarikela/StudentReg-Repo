using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using StudentRegistrationForm.BLL;

namespace StudentRegistrationForm.DAL
{
    class StudentDAL
    {
        SqlConnection connection = new SqlConnection(DbConnection.DbConn);

        #region SelectData
        public DataTable SelectData()
        {
            DataTable table = new DataTable();

            try
            {
                string sql = "SELECT students.id as Id,students.name as Name, students.phone as Phone, students.blood as Blood,students.gender as Gender,students.dob as Dob,students.email as Email, students.description as Description, admin.name as CreatedBy FROM students inner join admin on admin.id = students.createdBy";
                SqlCommand cmd = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                connection.Open();
                adapter.Fill(table);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return table;

        }
        #endregion

        #region Insert & Update Methods
        public bool InsertData(StudentBll student)
        {

            try
            {
                string sql = "INSERT INTO students(name,phone,blood,gender,dob,email,description,createdBy) VALUES(@name,@phone, @blood,@gender,@dob,@email,@description,@createdBy)";

                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@phone", student.Phone);
                cmd.Parameters.AddWithValue("@blood", student.Blood);
                cmd.Parameters.AddWithValue("@gender", student.Gender);
                cmd.Parameters.AddWithValue("@dob", student.Dob);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@description", student.Description);
                cmd.Parameters.AddWithValue("@createdBy", LoginForm.userId);
                connection.Open();
                cmd.ExecuteNonQuery();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return true;

        }

        public bool UpdateData(StudentBll student)
        {
            try
            {
                string sql = "UPDATE students SET name=@name, phone=@phone, blood=@blood, gender=@gender, dob=@dob, email=@email, description=@description, UpdatedBy=@UpdatedBy WHERE id=@id";

                using (SqlCommand cmd = new SqlCommand(sql, connection))
                {
                    cmd.Parameters.AddWithValue("@id", student.Id);
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@phone", student.Phone);
                    cmd.Parameters.AddWithValue("@blood", student.Blood);
                    cmd.Parameters.AddWithValue("@gender", student.Gender);
                    cmd.Parameters.AddWithValue("@dob", student.Dob);
                    cmd.Parameters.AddWithValue("@email", student.Email);
                    cmd.Parameters.AddWithValue("@description", student.Description);
                    cmd.Parameters.AddWithValue("@UpdatedBy", LoginForm.userId);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false; // Return false in case of an exception
            }
            finally
            {
                connection.Close();
            }

            return true; // Return true if the update is successful
        }


        #endregion Insert & Update Methods
    }
}
