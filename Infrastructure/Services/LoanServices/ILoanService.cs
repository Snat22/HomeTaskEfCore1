using Domain.DTOs.LoanDtos;
using Domain.Entities;
using Domain.Responses;

namespace Infrastructure.Services.LoanServices;

public interface ILoanService
{
    Task<Response<List<GetLoanDto>>> GetLoanListAsync();
    Task<Response<GetLoanDto>> GetLoanByIdAsync(int id);
    Task<Response<string>> AddLoanAsync(AddLoanDto add);
    Task<Response<string>> UpdateLoanAsync(UpdateLoanDto upd);
    Task<Response<bool>> DeleteLoanAsync(int id);
}
