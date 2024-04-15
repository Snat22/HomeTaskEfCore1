using System.Net;
using Domain.DTOs.LoanDtos;
using Domain.Entities;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.LoanServices;

public class LoanService(DataContext context) : ILoanService
{

        public async Task<Response<GetLoanDto>> GetLoanByIdAsync(int id)
    {
        try
        {
            
        var loan = await context.Loans.FirstOrDefaultAsync(e=> e.Id == id);
        if (loan == null) return new Response<GetLoanDto>(HttpStatusCode.BadRequest,"Not Found");

        var response = new GetLoanDto()
        {
            Id = loan.Id,
            BookId = loan.BookId,
            MemberId = loan.MemberId,
            LoanDate = loan.LoanDate,
            ReturnDate = loan.ReturnDate
        };
        return new Response<GetLoanDto>(response);
        }
        catch (System.Exception e)
        {
            
            return new Response<GetLoanDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    public async Task<Response<List<GetLoanDto>>> GetLoanListAsync()
    {
        try
        {
            
        var loan = await context.Loans.Where(e=> e.Id > 0).ToListAsync();
        if(loan == null) return new Response<List<GetLoanDto>>(HttpStatusCode.BadRequest,"Error");

        var list = new List<GetLoanDto>();

        foreach (var item in loan)
        {
            var newLoan = new GetLoanDto()
            {
                Id = item.Id,
                BookId = item.BookId,
                MemberId = item.MemberId,
                LoanDate = item.LoanDate,
                ReturnDate = item.ReturnDate
            };
            list.Add(newLoan);
        }
        return new Response<List<GetLoanDto>>(HttpStatusCode.OK,list);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetLoanDto>>(HttpStatusCode.InternalServerError,e.Message);
        }
    }
        public async Task<Response<string>> AddLoanAsync(AddLoanDto add)
    {
        try
        {
            var loan = new Loan()
            {
                BookId = add.BookId,
                MemberId = add.MemberId,
                LoanDate = add.LoanDate,
                ReturnDate = add.ReturnDate
            };
            await context.Loans.AddAsync(loan);
            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Added");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<string>> UpdateLoanAsync(UpdateLoanDto upd)
    {
        try
        {
            var existing = await context.Loans.FirstOrDefaultAsync(e=> e.Id==upd.Id);
            if(existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Error");

            existing.BookId = upd.BookId;
            existing.MemberId = upd.MemberId;
            existing.LoanDate = upd.LoanDate;
            existing.ReturnDate = upd.ReturnDate;

            var res = await context.SaveChangesAsync();

            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<bool>> DeleteLoanAsync(int id)
    {
        try
        {
           var delete = await context.Loans.FindAsync(id);
           if(delete == null) return new Response<bool>(HttpStatusCode.NotFound,false);
            context.Loans.Remove(delete);
           await context.SaveChangesAsync();
           return new Response<bool>(HttpStatusCode.OK,true);

        }
        catch (System.Exception e)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


}
