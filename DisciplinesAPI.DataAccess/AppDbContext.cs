using DisciplinesAPI.Models;
using DisciplinesAPI.Models.DBModels;
using Microsoft.EntityFrameworkCore;
using System;

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
            modelBuilder.Entity<LessonType>().HasData(
                new LessonType
                {
                    Id = Guid.NewGuid(),
                    Name = "ПЗ"
                },
                new LessonType
                {
                    Id = Guid.NewGuid(),
                    Name = "ГЗ"
                },
                new LessonType
                {
                    Id = Guid.NewGuid(),
                    Name = "СЕМ"
                },
                new LessonType
                {
                    Id = Guid.NewGuid(),
                    Name = "МЗ"
                },
                new LessonType
                {
                    Id = Guid.NewGuid(),
                    Name = "Лекция"
                }
            );
        }
    }
}


