using Microsoft.EntityFrameworkCore;
using ProjectBunkerWebApi.Models;

namespace ProjectBunkerWebApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<DevLogPost> DevLogPosts { get; set; }
    public DbSet<DevLogComment> DevLogComments { get; set; }
    public DbSet<DevLogLike> DevLogLikes { get; set; }
    public DbSet<DevLogCommentLike> DevLogCommentLikes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasIndex(e => e.Username).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();

            entity.HasMany(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
            
            entity.HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(u => u.PostLikes)
                .WithOne(l => l.Author)
                .HasForeignKey(l => l.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(u => u.CommentLikes)
                .WithOne(cl => cl.Author)
                .HasForeignKey(cl => cl.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<DevLogPost>(entity =>
        {
            entity.HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(p => p.Likes)
                .WithOne(l => l.Post)
                .HasForeignKey(l => l.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // Many-to-many with Categories
            entity.HasMany(p => p.Categories)
                .WithMany(c => c.Posts);
        });
        
        modelBuilder.Entity<DevLogComment>(entity =>
        {
            entity.HasMany(c => c.Likes)
                .WithOne(cl => cl.Comment)
                .HasForeignKey(cl => cl.CommentId)
                .OnDelete(DeleteBehavior.Cascade);
        });
        
        modelBuilder.Entity<DevLogLike>(entity =>
        {
            entity.HasIndex(e => new { e.PostId, e.AuthorId }).IsUnique();
        });

        modelBuilder.Entity<DevLogCommentLike>(entity =>
        {
            entity.HasIndex(e => new { e.CommentId, e.AuthorId }).IsUnique();
        });
        
        //Ignore computed properties
        modelBuilder.Entity<DevLogPost>()
            .Ignore(p => p.Modified);

        modelBuilder.Entity<DevLogComment>()
            .Ignore(c => c.Modified);
    }
}