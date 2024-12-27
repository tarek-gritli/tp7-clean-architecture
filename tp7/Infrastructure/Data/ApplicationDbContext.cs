using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using tp7.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options)
        : base(options) { }

    public DbSet<Movie> Movies { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<MovieReview> MovieReviews { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .Entity<Movie>()
            .HasOne(m => m.Genre)
            .WithMany(g => g.Movies)
            .HasForeignKey(m => m.GenreId);

        modelBuilder.Entity<Movie>().HasMany(m => m.Customers).WithMany(c => c.Movies);

        modelBuilder
            .Entity<MovieReview>()
            .HasOne(mr => mr.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(mr => mr.MovieId);

        modelBuilder
            .Entity<MovieReview>()
            .HasOne(mr => mr.Customer)
            .WithMany(c => c.Reviews)
            .HasForeignKey(mr => mr.CustomerId);
    }
}
