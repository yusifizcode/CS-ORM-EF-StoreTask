using CSharp_ORM_EF.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_ORM_EF.Data.DAL
{
    internal class BravoStoreDbContext:DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Comments> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PGOASLP\SQLEXPRESS;Database=BravoStore;Trusted_Connection=TRUE");
        }
    }
}
