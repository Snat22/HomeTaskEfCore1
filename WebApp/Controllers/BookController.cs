using Domain.DTOs.BookDtos;
using Domain.Responses;
using Infrastructure.Services.BookServices;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;
[Route("/api/Book")]
[ApiController]
public class BookController(IBookService service) :ControllerBase
{
    [HttpGet("Get-All-Books")]
    public async Task<Response<List<GetBookDto>>> GetBooks()
    {
        return await service.GetBookListAsync();
    }

    [HttpGet("BookId:int")]
    public async Task<Response<GetBookDto>> GetBookById(int BookId)
    {
        return await service.GetBookByIdAsync(BookId);
    }

    [HttpPost("Add-Book")]
    public async Task<Response<string>> AddBook(AddBookDto add)
    {
        return await service.AddBookAsync(add);
    }

    [HttpPut("Update-Book")]

    public async Task<Response<string>> UpdateBook(UpdateBookDto update)
    {
        return await service.UpdateBookAsync(update);
    }

    [HttpDelete("bookId:int")]
    public async Task<Response<bool>> DeleteBook(int BookId)
    {
        return await service.DeleteBookAsync(BookId);
    }


}
