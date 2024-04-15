using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Responses;

namespace Domain.Entities;

public class Loan
{   [Key]
    public int Id { get; set; }
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }

}
