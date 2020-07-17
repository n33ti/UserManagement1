using System;
using System.Collections.Generic;

namespace UserManagement.Models
{
    public partial class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string IsActive { get; set; }
    }
}
