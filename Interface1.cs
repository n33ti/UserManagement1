using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement
{
    interface Interface1
    {
        List<User> Users();
        User GetUser(int Id);

        void Delete(int Id);

        void AddUser(User user);

        List<User> ActiveUsers();


    }
}
