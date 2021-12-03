using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication3.Models
{
    public class UserContext
    {
        string cs = ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;

        public List<User> GetUser()
        {
            List<User> UserList = new List<User>();
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spGetUsers", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                User user = new User();
                user.Id = Convert.ToInt32(dr.GetValue(0).ToString());
                user.FirstName = dr.GetValue(1).ToString();
                user.LastName = dr.GetValue(2).ToString();
                user.DateOfBirth = Convert.ToDateTime(dr.GetValue(3).ToString());
                user.Gender = dr.GetValue(4).ToString();
                user.EmailAddress = dr.GetValue(5).ToString();
                user.Password = dr.GetValue(6).ToString();

                UserList.Add(user);
            }
            con.Close();
            return UserList;
        }

        public bool AddUser(User user)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spAddUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", user.Gender);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);
            cmd.Parameters.AddWithValue("@Password", hashing.HashPassword(user.Password));
            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public bool UpdateUser(User user)
        {

            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand("spUpdateUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", user.Id);
            cmd.Parameters.AddWithValue("@FirstName", user.FirstName);
            cmd.Parameters.AddWithValue("@LastName", user.LastName);
            cmd.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
            cmd.Parameters.AddWithValue("@Gender", user.Gender);
            cmd.Parameters.AddWithValue("@EmailAddress", user.EmailAddress);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool LoginUser(string email, string pswd)
        {
           
            try
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "Select * from UserData where EmailAddress = @Email AND Password = @Pass;";

                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.Add("@Email", SqlDbType.VarChar);
                cmd.Parameters["@Email"].Value = email;
                //cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Pass", hashing.HashPassword(pswd));
              
                SqlDataReader dr = cmd.ExecuteReader();
                con.Close();
                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;

            }
           

        }


       
    }
}