using System.Net;
using Domain.DTOs.BookDtos;
using Domain.Responses;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services.BookServices;

public class BookService(DataContext context) : IBookService
{
    
    public async Task<Response<List<GetBookDto>>> GetBookListAsync()
    {
        try
        {
            var book = await context.Books.Where(e=> e.Id > 0).ToListAsync();

            var list = new List<GetBookDto>();
            foreach (var item in book)
            {
                var newBook = new GetBookDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    Author = item.Author,
                    PublishYear = item.PublishYear,
                    Genre = item.Genre

                };
                list.Add(newBook);
            }
            return new Response<List<GetBookDto>>(list);
        }
        catch (System.Exception e)
        {
            return new Response<List<GetBookDto>>(HttpStatusCode.InternalServerError, e.Message);
        }
    }
    public async Task<Response<GetBookDto>> GetBookByIdAsync(int id)
    {
        try
        {
            var book = await context.Books.FirstOrDefaultAsync(e=> e.Id== id);
            if (book==null) return new Response<GetBookDto>(HttpStatusCode.BadRequest,"Not Found!");
            var response = new GetBookDto()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishYear = book.PublishYear,
                Genre = book.Genre
            };
            return new Response<GetBookDto>(response);
        }
        catch (System.Exception e)
        {
            
            return new Response<GetBookDto>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

    
    public async Task<Response<string>> AddBookAsync(AddBookDto add)
    {
        try
        {
            var newBook = new Book()
            {
                Title = add.Title,
                Author = add.Author,
                PublishYear = add.PublishYear,
                Genre = add.Genre
            };
            await context.Books.AddAsync(newBook);
            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Added Sucessfully");
            return new Response<string>(HttpStatusCode.BadRequest,"Error");
        }
        catch (System.Exception e)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, e.Message);
        }
    }

    public async Task<Response<bool>> DeleteBookAsync(int id)
    {
        try
        {
            var delete = await context.Books.FindAsync(id);
            if(delete == null) return new Response<bool>(HttpStatusCode.BadRequest,false);
            context.Remove(delete);
            var res = await context.SaveChangesAsync();
            return new Response<bool>(true); 
        }
        catch (System.Exception e)
        {
            
            return new Response<bool>(HttpStatusCode.InternalServerError,e.Message);
        }
    }


    public async Task<Response<string>> UpdateBookAsync(UpdateBookDto upd)
    {
        try
        {
            var existing = await context.Books.FirstOrDefaultAsync(e=>e.Id ==upd.Id);
            if(existing == null) return new Response<string>(HttpStatusCode.BadRequest,"Error");

            existing.Title = upd.Title;
            existing.Author = upd.Author;
            existing.PublishYear = upd.PublishYear;
            existing.Genre = upd.Genre;
            var res = await context.SaveChangesAsync();
            if(res > 0) return new Response<string>(HttpStatusCode.OK,"Yet Updated");
            return new Response<string>(HttpStatusCode.BadRequest,"Error Updating");
        }
        catch (System.Exception e)
        {
            
            return new Response<string>(HttpStatusCode.InternalServerError,e.Message);
        }
    }

}
