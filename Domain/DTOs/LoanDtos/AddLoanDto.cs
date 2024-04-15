namespace Domain.DTOs.LoanDtos;

public class AddLoanDto
{    
    public int BookId { get; set; }
    public int MemberId { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime ReturnDate { get; set; }
}
