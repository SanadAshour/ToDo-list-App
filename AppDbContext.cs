using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T0_Do_List
{
    class AppDbContext: DbContext
    {
        public DbSet<TodoItem> TodoItem { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Sanad_HpEnvy\\SQLEXPRESS;database=Tasks;integrated security=true;TrustServerCertificate=true");
        }
    }
}
