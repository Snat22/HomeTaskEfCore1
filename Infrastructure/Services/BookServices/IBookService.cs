using Domain.DTOs.BookDtos;
using Domain.Responses;

namespace Infrastructure.Services.BookServices;

public interface IBookService
{
    Task<Response<List<GetBookDto>>> GetBookListAsync();
    Task<Response<GetBookDto>> GetBookByIdAsync(int id);
    Task<Response<string>> AddBookAsync(AddBookDto add);
    Task<Response<string>> UpdateBookAsync(UpdateBookDto upd);
    Task<Response<bool>> DeleteBookAsync(int id); 
}
