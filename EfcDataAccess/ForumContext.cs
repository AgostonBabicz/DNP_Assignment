using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class ForumContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
       //optionsBuilder.UseSqlite(@"Data Source = /Users/AgostonBabicz/Documents/GitHub/DNP_Assignment/EfcDataAccess/DB.db");
       // This is an absolute path for the DB. Please change it in order to make the application work. The relative path didn't work for some reason.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(modelBuilder);
    }
    
}