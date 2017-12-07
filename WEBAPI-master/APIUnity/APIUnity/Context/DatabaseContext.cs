using APIUnity.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIUnity.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Scores> Scores { get; set; }
    }
}