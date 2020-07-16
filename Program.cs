using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {


            Interface1 obj = new UserRepo();

            Console.WriteLine("--------------Using Ado .Net-------------");
            List<User> users = obj.Users();

            
            foreach (var user in users)
            {
                Console.WriteLine(user.name + " " + user.address + " " + user.isActive + " " + user.Id);
            }

            users.Clear();

            users = obj.ActiveUsers();
            foreach (var user in users)
            {
                Console.WriteLine(user.name + " " + user.address + " " + user.isActive + " " + user.Id);
            }

            Console.WriteLine("Enter id to show");
             int Id = Convert.ToInt32(Console.ReadLine());
             User user1 = obj.GetUser(Id);
            if (user1 != null)
                Console.WriteLine(user1.name + " " + user1.address + " " + user1.isActive + " " + user1.Id);
            else
                Console.WriteLine("No such user exists");

            Console.WriteLine("Enter id to delete");
            Id = Convert.ToInt32(Console.ReadLine());
            obj.Delete(Id);
            Console.WriteLine("--------user deleted----------");

            Console.WriteLine("Add user");
            User newUser = new User();
            Console.Write("Name :");
            newUser.name = Console.ReadLine();
            Console.Write("isActive :");
            newUser.isActive = Convert.ToChar(Console.ReadLine()) == 't'? true : false;
            Console.Write("Address :");
            newUser.address = Console.ReadLine();
            obj.AddUser(newUser);
            Console.WriteLine("--------user added----------\n\n");


            Console.WriteLine("----Using Database First Approach--------");
            UserRepoDataBaseFirst userRepo = new UserRepoDataBaseFirst();
            Console.WriteLine("Add user");
            Console.Write("Name :");
            User newUser2 = new User();
            newUser2.name = Console.ReadLine();
            Console.Write("isActive :");
            newUser2.isActive = Convert.ToChar(Console.ReadLine()) == 't' ? true : false;
            Console.Write("Address :");
            newUser2.address = Console.ReadLine();
            obj.AddUser(newUser2);
            Console.WriteLine("--------user added----------");
            userRepo.AddUser(newUser);

            Console.WriteLine("Enter id to show");
            Id = Convert.ToInt32(Console.ReadLine());
            user1 = userRepo.GetUser(Id);
            if (user1 != null)
                Console.WriteLine(user1.name + " " + user1.address + " " + user1.isActive + " " + user1.Id);
            else
                Console.WriteLine("No such user exists");

            //    string connectionString = "Server=CSE1605202;Trusted_Connection=True;database=DB1";
            //    SqlConnection con = new SqlConnection();
            //    con.ConnectionString = connectionString;

            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "select * from users";
            //    cmd.Connection = con;

            //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //    DataSet ds = new DataSet();
            //    sqlDataAdapter.Fill(ds);
            //    List<User> users = new List<User>();
            //    foreach (DataRow row in ds.Tables[0].Rows)
            //    {
            //        bool value;

            //            value = Convert.ToChar(row["isActive"]) == 'T' || Convert.ToChar(row["isActive"]) == 't' ? false : true;

            //        users.Add(new User()
            //        {
            //            Id = Convert.ToInt32(row["Id"]),
            //            name = Convert.ToString(row["name"]),
            //            address = Convert.ToString(row["address"]),


            //            isActive = value

            //        }


            //            );


            //    }

            //    foreach (var user in users)
            //    {
            //        Console.WriteLine(user.name + " " + user.address + " " + user.isActive + " " + user.Id);
            //    }

            //    cmd.CommandText = "select * from users where isActive = 't' or isActive = 'T'";
            //    cmd.Connection = con;

            //    SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter(cmd);
            //    DataSet ds1 = new DataSet();
            //    sqlDataAdapter1.Fill(ds1);
            //    users.Clear();
            //    foreach (DataRow row in ds1.Tables[0].Rows)
            //    {
            //        users.Add(new User()
            //        {
            //            Id = Convert.ToInt32(row["Id"]),
            //            name = Convert.ToString(row["name"]),
            //            address = Convert.ToString(row["address"]),


            //            isActive = true

            //        }


            //            );
            //    }
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine(user.name + " " + user.address + " " + user.isActive + " " + user.Id);
            //    }

            //    cmd.CommandText = "select * from users where id =" + 3;
            //    SqlDataAdapter sqlDataAdapter3 = new SqlDataAdapter(cmd);
            //    DataSet ds3 = new DataSet();
            //    sqlDataAdapter3.Fill(ds3);
            //    users.Clear();
            //    foreach (DataRow row in ds3.Tables[0].Rows)
            //    {
            //        users.Add(new User()
            //        {
            //            Id = Convert.ToInt32(row["Id"]),
            //            name = Convert.ToString(row["name"]),
            //            address = Convert.ToString(row["address"]),


            //            isActive = true

            //        }


            //            );
            //    }
            //    foreach (var user in users)
            //    {
            //        Console.WriteLine(user.name + " " + user.address + " " + user.isActive + " " + user.Id);
            //    }




        }
    }
}
