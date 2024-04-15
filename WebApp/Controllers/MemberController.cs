using Domain.DTOs.MemberDtos;
using Domain.Responses;
using Infrastructure.Services.MemberServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Member")]
[ApiController]
public class MemberController(IMemberService service) :ControllerBase
{
    [HttpGet("Get-Members")]

    public async Task<Response<List<GetMemberDto>>> GetMembers()
    {
        return await service.GetMembersAsync();
    }

    [HttpGet("memberId:int")]
    public async Task<Response<GetMemberDto>> GetMemberById(int memberId)
    {
        return await service.GetMemberByIdAsync(memberId);
    }

    [HttpPost("Add-Member")]
    public async Task<Response<string>> AddMember( AddMemberDto add)
    {
        return await service.AddMemberAsync(add);
    }

    [HttpPut("Update-Member")]

    public async Task<Response<string>> UpdateMember(UpdateMemberDto update)
    {
        return await service.UpdateMemberAsync(update);
    }

    [HttpDelete("memberId:int")]
    public async Task<Response<bool>> DeleteMember(int memberId)
    {
        return await service.DeleteMemberAsync(memberId);
    }
}
