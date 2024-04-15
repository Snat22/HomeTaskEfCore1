namespace Domain.DTOs.LoanDtos;

public class UpdateLoanDto
{
    
    public int Id { get; set;}
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
