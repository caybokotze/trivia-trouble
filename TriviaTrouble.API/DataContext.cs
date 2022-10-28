using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using TriviaTrouble.Models;

namespace TriviaTrouble;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
        
    }

    public DbSet<Question>? Questions { get; set; }
    public DbSet<Answer>? Answers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Question>()
            .ToTable("Questions")
            .HasKey(c => c.Id);

        modelBuilder.Entity<Answer>()
            .ToTable("Answers")
            .HasKey(c => c.Id);

        // modelBuilder.Entity<Question>()
        //     .HasOne(e => e.Answers)
        //     .WithMany()
        //     .HasForeignKey<>()
        //
        // modelBuilder.Entity<Answer>()
        //     .HasOne(o => o.Question)
        //     .WithMany()
        //     .HasForeignKey(fk => fk.Id);
    }
}