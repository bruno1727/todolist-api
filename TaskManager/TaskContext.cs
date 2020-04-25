using Microsoft.EntityFrameworkCore;
using TaskManager.Models;

namespace TaskManager
{
    public class TaskContext : DbContext
    {
        public DbSet<TaskModel> Task { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-GC2NVCF;Initial Catalog=taskmanager;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskModel>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<TaskModel>()
                .Property(t => t.Id)
                .HasColumnName("taskid");

            modelBuilder.Entity<TaskModel>()
               .Property(t => t.Description)
               .HasColumnName("description");
        }
    }
}
