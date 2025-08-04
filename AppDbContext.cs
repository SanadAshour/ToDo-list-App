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
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=Sanad_HpEnvy\\SQLEXPRESS;database=Tasks;integrated security=true;TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuring one to many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.TodoItems) //a category has many todoitems
                .WithOne(t => t.Category) //a todoitem has one category
                .HasForeignKey(t => t.CategoryId); //the foreign key is in todoitem

        }
    }
}
