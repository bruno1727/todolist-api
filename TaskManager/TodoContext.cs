using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoModel> Todo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=todolist;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoModel>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
