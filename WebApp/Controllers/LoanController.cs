using Domain.DTOs.LoanDtos;
using Domain.Responses;
using Infrastructure.Services.LoanServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Loan")]
[ApiController]
public class LoanController(ILoanService service) :ControllerBase
{
    
    [HttpGet("Get-Loans")]

    public async Task<Response<List<GetLoanDto>>> GetLoans()
    {
        return await service.GetLoanListAsync();
    }

    [HttpGet("LoanId:int")]
    public async Task<Response<GetLoanDto>> GetLoanById(int LoanId)
    {
        return await service.GetLoanByIdAsync(LoanId);
    }

    [HttpPost("Add-Loan")]
    public async Task<Response<string>> AddLoan( AddLoanDto add)
    {
        return await service.AddLoanAsync(add);
    }

    [HttpPut("Update-Loan")]

    public async Task<Response<string>> UpdateLoan(UpdateLoanDto update)
    {
        return await service.UpdateLoanAsync(update);
    }

    [HttpDelete("LoanId:int")]
    public async Task<Response<bool>> DeleteLoan(int LoanId)
    {
        return await service.DeleteLoanAsync(LoanId);
    }
}
