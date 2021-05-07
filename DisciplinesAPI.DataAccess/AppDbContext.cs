using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DBModels;
using Microsoft.EntityFrameworkCore;

namespace DisciplinesAPI.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }
        public DbSet<Disciplines> Disciplines { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoCourses> VideoCourses { get; set; }
        public DbSet<LessonType> LessonTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                assembly:typeof(AppDbContext).Assembly);
        }
    }
}


