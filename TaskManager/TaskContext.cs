using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskModel> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLSERVER;Database=todolist;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(256);
        }
    }
}
