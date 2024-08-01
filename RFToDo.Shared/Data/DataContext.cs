using Microsoft.EntityFrameworkCore;
using RFToDo.Shared.Models;

namespace RFToDo.Shared.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 
        
        }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tasks>(entity =>
            {
                entity.ToTable("Tasks");
                entity.HasOne(c=>c.Goal)
                .WithMany(c=>c.Tasks)
                .HasForeignKey(c=>c.GoalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Task_Goal");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
