using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace UserManagement
{
    class UserRepo : Interface1
    {
        const string connectionString = "Server=CSE1605202;Trusted_Connection=True;database=DB1";
        SqlConnection con = new SqlConnection();
       
     
        public void AddUser(User user)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            cmd.Connection = con;
            con.Open();
            String name = user.name;
            String address = user.address;
            char isActive = user.isActive == true ? 'T' : 'F';
            cmd.CommandText = "insert into users(name, address, isActive) values('" + name + "', '" + address + "', '" + isActive+ "')";
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public void Delete(int Id)
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = "delete from users where id =" + Id;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public User GetUser(int Id)
        {

            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            cmd.Connection = con;

            cmd.CommandText = "select * from users where id =" + Id;
            SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(cmd);
            DataSet ds3 = new DataSet();
            sqlDataAdapter3.Fill(ds3);
            User user = new User();
            if (ds3.Tables[0].Rows.Count > 0)
            {
                user.Id = Convert.ToInt32(ds3.Tables[0].Rows[0]["Id"]);
                user.name = Convert.ToString(ds3.Tables[0].Rows[0]["name"]);
                user.address = Convert.ToString(ds3.Tables[0].Rows[0]["address"]);
                user.isActive = Convert.ToChar(ds3.Tables[0].Rows[0]["isActive"]) == 'T' || Convert.ToChar(ds3.Tables[0].Rows[0]["isActive"]) == 'T' ? true : false;

                return user;
            }
            else
                return null;
            
        }

        public List<User> Users()
        {
            List < User > users = new List<User>();
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            cmd.CommandText = "select * from users";
            cmd.Connection = con;

            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sqlDataAdapter1.Fill(ds1);
            users.Clear();
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                bool value = Convert.ToChar(row["isActive"]) == 't' || Convert.ToChar(row["isActive"]) == 'T' ? true : false;

                users.Add(new User()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    name = Convert.ToString(row["name"]),
                    address = Convert.ToString(row["address"]),


                    isActive = value

                }


                    );
            }
            return users;
        }

        public List<User> ActiveUsers()
        {
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = connectionString;
            List<User> users = new List<User>();
            cmd.CommandText = "select * from users where isActive = 't' or isActive = 'T'";
            cmd.Connection = con;

            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd);
            DataSet ds1 = new DataSet();
            sqlDataAdapter1.Fill(ds1);
            users.Clear();
            foreach (DataRow row in ds1.Tables[0].Rows)
            {
                                users.Add(new User()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    name = Convert.ToString(row["name"]),
                    address = Convert.ToString(row["address"]),


                    isActive = true

                }


                    );
            }
            return users;

        }

      
    }
}
