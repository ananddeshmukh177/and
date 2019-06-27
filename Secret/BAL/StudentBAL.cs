using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BOL;
namespace BAL
{
    public static class StudentBAL
    {
        public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\user14\Desktop\D\Secret\CRUD_MVC\App_Data\Secret.mdf;Integrated Security=True";

        public static bool Insert(string namee, int phone, string email, string pass)
        {
            bool status = false;

            SqlConnection con = new SqlConnection(conString);
            string insertQuery = "insert into Student(namee,phone,email,pass) values('" + namee + "','" + phone + "','" + email + "','" + pass + "')";

            try
            {
                con.Open();
                SqlCommand c = new SqlCommand(insertQuery,con);
                c.ExecuteNonQuery();
               
                status = true;
            }catch(SqlException e)
            {
                throw e;
            }
            con.Close();
            return status;
        }

        public static List<Student> GetAllStudent()
        {
            List<Student> std = new List<Student>();

            string query = "select * from Student";
            SqlConnection con = new SqlConnection(conString);
           
            SqlCommand c = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader dataReader = c.ExecuteReader();

                while(dataReader.Read())
                {
                    string name = dataReader["namee"].ToString();
                    int phone = int.Parse(dataReader["phone"].ToString());
                    string email = dataReader["email"].ToString();

                    std.Add(new Student() { Name = name, Phone = phone, Email = email });
                }

                dataReader.Close();

            }
            catch(SqlException e)
            {
                throw e;
            }

            con.Close();

            return std;
            
        }
    }
}
