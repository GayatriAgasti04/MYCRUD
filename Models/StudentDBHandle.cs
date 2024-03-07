using System;
using System.Collections.Generic;
//add namespace
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace MYCRUD.Models
{
    public class StudentDBHandle
    {
        //sql connection
        private SqlConnection con;
        private void Connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["dbconnection"].ToString();
            con = new SqlConnection(constring);
        }

        // Add new Student
        public bool AddStudent(StudentModel smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("AddNewStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;

        }
        // View Student Details
        public List<StudentModel>GetStudent()
        {
            Connection();
       List<StudentModel> StudentList = new List<StudentModel>();
        SqlCommand cmd = new SqlCommand("GetStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sda.Fill(dt);
            con.Close();
            foreach( DataRow dr in dt.Rows)
            {
                StudentList.Add(new StudentModel
                {
                    ID = Convert.ToInt32(dr["ID"]),
                    Name = Convert.ToString(dr["Name"]),
                    City=Convert.ToString(dr["City"]),
                    Address=Convert.ToString(dr["Address"])

                });
               }
            return StudentList;
        }

       //Update code
       public bool UpdateDetails(StudentModel smodel)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("UpdateStudentDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StID", smodel.ID);
            cmd.Parameters.AddWithValue("@Name", smodel.Name);
            cmd.Parameters.AddWithValue("@City", smodel.City);
            cmd.Parameters.AddWithValue("@Address", smodel.Address);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >=1)
                return true;
            else
            return false;


        }

        //Delete Code
        public bool DeleteStudent(int ID)
        {
            Connection();
            SqlCommand cmd = new SqlCommand("DeleteStudent", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@StID", ID);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

}
}