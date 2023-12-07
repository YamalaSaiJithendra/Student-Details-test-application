using Microsoft.Data.SqlClient;
using Practice1.Models;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;
//using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace Practice1.Repository
{
    public class StudentRepository
    {
        private string con;
        private SqlConnection constr = new SqlConnection();

        private SqlConnection connection()
        {

            IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

            con = configuration.GetConnectionString("getconn");
            constr  = new SqlConnection(con);
            return constr;
            //SqlConnection  constr  = new SqlConnection(configuration.GetConnectionString("getconn"));
        }
        public bool AddStudentDetails(StudentModel obj )
        {
            //connection();
            SqlConnection con = connection();   
            SqlCommand com = new SqlCommand("AddStudent", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Age", obj.Age);
            com.Parameters.AddWithValue("@Gender", obj.Gender);
            com.Parameters.AddWithValue("@City", obj.City);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }
        public List<StudentModel> GetAllStudents()
        {
            //connection();
            SqlConnection con = connection();
            List<StudentModel> StdList = new List<StudentModel>();
            

            SqlCommand com = new SqlCommand("GetStudents", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {

                StdList.Add(

                    new StudentModel
                    {

                        StudentId = Convert.ToInt32(dr["Id"]),
                        Name =Convert.ToString(dr["Name"]),
                        Age= Convert.ToInt32(dr["Age"]),
                        Gender=Convert.ToBoolean(dr["Gender"]),
                        City = Convert.ToString(dr["City"])

                    }
                    );
            }
            return StdList;
        }

        public bool UpdateStudent(StudentModel obj)
        {

            //connection();
            SqlConnection con = connection();
            SqlCommand com = new SqlCommand("UpdateStudent", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", obj.StudentId);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Age", obj.Age);
            com.Parameters.AddWithValue("@Gender", obj.Gender.ToString());
            com.Parameters.AddWithValue("@City", obj.City);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }

        }
        public bool DeleteStudent(int Id)
        {

            //connection();
            SqlConnection con = connection();
            SqlCommand com = new SqlCommand("DeleteStudentById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@StudentId", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }   
        }
    }
}
