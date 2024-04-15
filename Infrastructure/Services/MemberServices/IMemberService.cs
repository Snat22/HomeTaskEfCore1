using Domain.DTOs.MemberDtos;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.MemberServices;

public interface IMemberService
{
    Task<Response<List<GetMemberDto>>> GetMembersAsync();
    Task<Response<GetMemberDto>> GetMemberByIdAsync(int id);
    Task<Response<string>> AddMemberAsync(AddMemberDto add);
    Task<Response<string>> UpdateMemberAsync(UpdateMemberDto upd);
    Task<Response<bool>> DeleteMemberAsync(int id);
}
