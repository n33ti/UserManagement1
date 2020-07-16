using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagement
{
    public class UserRepoDataBaseFirst : Interface1
    {
        
        public List<User> ActiveUsers()
        {
            var context = new DBContextApp();

            dynamic users = context.Users
                                       .Where(s => s.isActive == true);
            return users;
                                      
        }

        public void AddUser(User user)
        {
            using (var context = new DBContextApp())
            {

                var std = new User()
                {
                    name = user.name,
                    address = user.address,
                    isActive = user.isActive
                };

                context.Users.Add(std);
                context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            var context = new DBContextApp();

            dynamic user = context.Users
                                       .Where(s => s.Id == Id)
                                       .FirstOrDefault();
            context.Users.Remove(user);
        }

        public User GetUser(int Id)
        {

            var context = new DBContextApp();
            foreach( User  user in context.Users.ToList())
                {
                if (user.Id == Id)
                    return user;
            }
            return null;
           
        }

        public List<User> Users()
        {
            var context = new DBContextApp();

            dynamic users = context.Users;
            return users;
        }
    }
}
