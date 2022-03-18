using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OekakiTradingSite.Models.Entities
{
    public class DataContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Drawing> Drawings { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DataContext(DbContextOptions options) : base(options) 
        { 

        }
    }
}
