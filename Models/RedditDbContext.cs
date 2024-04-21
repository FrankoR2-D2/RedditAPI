using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;


namespace RedditAPI.Models
{
    public class RedditDbContext : DbContext
    {
        public RedditDbContext(DbContextOptions<RedditDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Votes)
                .WithOne(v => v.User)
                .HasForeignKey(v => v.UserId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<Post>()
                .HasMany(p => p.Votes)
                .WithOne(v => v.Post)
                .HasForeignKey(v => v.PostId)
                .IsRequired(false); // PostId is nullable in Vote

            modelBuilder.Entity<Comment>()
                .HasMany(c => c.Votes)
                .WithOne(v => v.Comment)
                .HasForeignKey(v => v.CommentId)
                .IsRequired(false); // CommentId is nullable in Vote
        }
    }


}
