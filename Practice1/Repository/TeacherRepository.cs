using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Practice1.Models;
using System.Data;

namespace Practice1.Repository
{
    public class TeacherRepository
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
        public bool AddTeacherDetails(TeacherModel tcr)
        {
            //connection();
            SqlConnection con = connection();
            SqlCommand com = new SqlCommand("AddTeacher", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Teacher_Name", tcr.Teacher_Name);
            com.Parameters.AddWithValue("@EmpId", tcr.EmpId);
            com.Parameters.AddWithValue("@TeachingSubject", tcr.TeachingSubject);
            com.Parameters.AddWithValue("@Phone_Number", tcr.Phone_Number);
            com.Parameters.AddWithValue("@Experience", tcr.Experience);

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
        public List<TeacherModel> GetAllTeachers()
        {
            //SQL COnnection 
            SqlConnection con = connection();
            
            List<TeacherModel> TcrList = new List<TeacherModel>();

            SqlCommand com = new SqlCommand("GetTeachers", con);
            com.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da = new SqlDataAdapter(com);
            //DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                TcrList.Add(
                    new TeacherModel
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Teacher_Name = Convert.ToString(dr["Teacher_Name"]),
                        TeachingSubject = Convert.ToString(dr["TeachingSubject"]),
                        EmpId = Convert.ToInt32(dr["EmpId"]),
                        Phone_Number= Convert.ToString(dr["Phone_Number"]),
                        Experience = Convert.ToInt32(dr["Experience"])
                    }
                    );
            }
            return TcrList;
        }

        //For Update Teacher data

        public bool UpdatedTeacher(TeacherModel tcr)
        {
            //connection();
            SqlConnection con = connection();
            SqlCommand com = new SqlCommand("UpdateTeacher", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", tcr.Id);
            com.Parameters.AddWithValue("@Teacher_Name", tcr.Teacher_Name);
            com.Parameters.AddWithValue("@EmpId", tcr.EmpId);
            com.Parameters.AddWithValue("@TeachingSubject", tcr.TeachingSubject);
            com.Parameters.AddWithValue("@Phone_Number", tcr.Phone_Number);
            com.Parameters.AddWithValue("@Experience", tcr.Experience);
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
        public bool DeleteTeacher(int id)
        {
            SqlConnection con = connection();
            SqlCommand com = new SqlCommand("DeleteTeacherById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Id", id);
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
