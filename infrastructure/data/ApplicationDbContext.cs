using System;
using dotenv.net;
using Microsoft.EntityFrameworkCore;
using domain.entities;

namespace infrastructure.data;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            DotEnv.Load();
            optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DATABASE_URL"));
        }
    }



}
