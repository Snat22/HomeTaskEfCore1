using System.Net;
using Domain.DTOs.MemberDtos;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.MemberServices;

public class MemberService(DataContext context) : IMemberService
{
    public async Task<Response<GetMemberDto>> GetMemberByIdAsync(int id)
    {
        try
        {
            var member = await context.Members.FirstOrDefaultAsync(e=> e.Id == id);
            if (member == null) return new Response<GetMemberDto>(HttpStatusCode.BadRequest,"Not Found");

            var response = new GetMemberDto()
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                MembershipDate = member.MembershipDate
            };

            return new Response<GetMemberDto>(response);
        }
        catch (System.Exception e)
        {
            return new Response<GetMemberDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetMemberDto>>> GetMembersAsync()
    {
        try
        {
            var member = await context.Members.Where(e=>e.Id > 0).ToListAsync();
            if (member == null) return new Response<List<GetMemberDto>>(HttpStatusCode.BadRequest,"Table free");

            var list = new List<GetMemberDto>();

            foreach (var item in member)
            {
                
                var newMember = new GetMemberDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName= item.LastName,
                    MembershipDate = item.MembershipDate
                };
                list.Add(newMember);
            }
            return new Response<List<GetMemberDto>>(list);
        }
        catch (System.Exception e)
        {
            
            return new Response<List<GetMemberDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<string>> AddMemberAsync(AddMemberDto add)
    {
        try
        {
            var memner = new Member()
            {
                FirstName = add.FirstName,
                LastName = add.LastName,
                MembershipDate = add.MembershipDate
            };
            await context.Members.AddAsync(memner);
            var res = await context.SaveChangesAsync();
            if(res > 0)return new Response<string>(HttpStatusCode.OK,"Added");
            return new Response<string>(HttpStatusCode.BadRequest,"Can't (-_-) )");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
    
    public async Task<Response<string>> UpdateMemberAsync(UpdateMemberDto upd)
    {
        try
        {
            var existing = await context.Members.FirstOrDefaultAsync(x => x.Id== upd.Id);
            if(existing==null) return new Response<string>(HttpStatusCode.BadRequest,"Error");

            existing.FirstName = upd.FirstName;
            existing.LastName = upd.LastName;
            existing.MembershipDate = upd.MembershipDate;

            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError , e.Message);
        }
    }

    public async Task<Response<bool>> DeleteMemberAsync(int id)
    {
        try
        {
            var delete = await context.Members.FindAsync(id);
            if(delete==null) return new Response<bool>(HttpStatusCode.NotFound,false);
            context.Members.Remove(delete);
            await context.SaveChangesAsync();
            return new Response<bool>(HttpStatusCode.OK,true);

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


}
