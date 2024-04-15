using Domain.Entities;
using Domain.Responses;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class DataContext:DbContext
{
    public DataContext(DbContextOptions<DataContext> options) :base(options)
    {
        
    }

    public DbSet<Book> Books{ get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set;}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region Relation and Db
            modelBuilder.Entity<Loan>()
                .HasKey(e => e.Id); 

            modelBuilder.Entity<Loan>()
                .Property(e => e.LoanDate)
                .HasColumnType("date"); 

            modelBuilder.Entity<Loan>()
                .Property(e => e.ReturnDate)
                .HasColumnType("date"); 

            modelBuilder.Entity<Loan>()
                .HasOne(b => b.Book) 
                .WithMany()
                .HasForeignKey(l => l.BookId)
                .OnDelete(DeleteBehavior.Cascade); 

            base.OnModelCreating(modelBuilder);
        }
    

        #endregion
}
