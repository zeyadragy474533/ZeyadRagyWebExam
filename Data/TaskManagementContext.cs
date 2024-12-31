using Microsoft.EntityFrameworkCore;
using ZeyadRagyWebExam.Models;

namespace ZeyadRagyWebExam.Data
{
    public class TaskManagementContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LEVASCH-STD050;Database=Web_Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }

      public DbSet<Job> Jobs { get; set; }
      public DbSet<Project> Projects { get; set; }
      public DbSet<TeamMember> TeamMembers { get; set; }
    }
}
