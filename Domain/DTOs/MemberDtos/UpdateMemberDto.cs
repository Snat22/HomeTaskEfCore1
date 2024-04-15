namespace Domain.DTOs.MemberDtos;

public class UpdateMemberDto
{
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime MembershipDate { get; set; }
}
