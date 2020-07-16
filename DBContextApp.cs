using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace UserManagement
{
   public class DBContextApp : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=CSE1605202;Trusted_Connection=True;database=DB1");
        }
        public DbSet<User> Users { get; set; }
    }
}
