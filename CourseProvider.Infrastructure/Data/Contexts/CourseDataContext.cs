﻿using CourseProvider.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Data.Contexts;

public class CourseDataContext(DbContextOptions<CourseDataContext> options) : DbContext(options)
{
    public DbSet<CourseEntity> Courses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CourseEntity>().ToContainer("Courses");
        modelBuilder.Entity<CourseEntity>().HasPartitionKey(x => x.Id);
        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Rating);
        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Author, a => a.OwnsOne(x => x.SocialMedia));
        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Included);
        modelBuilder.Entity<CourseEntity>().OwnsMany(x => x.Highlights);
        modelBuilder.Entity<CourseEntity>().OwnsMany(x => x.Content);
        modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Prices);
    }
}