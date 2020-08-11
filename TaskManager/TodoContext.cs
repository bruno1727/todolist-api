using Microsoft.EntityFrameworkCore;
using TodoList.Models;

namespace TodoList
{
    public class TodoContext : DbContext
    {
        public DbSet<TodoModel> Todo { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        { 
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
