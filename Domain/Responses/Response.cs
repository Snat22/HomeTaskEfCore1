using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Description { get; set; }
    public T? Data { get; set; }

    public Response(HttpStatusCode statusCode, string messages,T data)
    {
        StatusCode = (int)statusCode;
        Description.Add(messages);
        Data = data;
    }
     public Response(HttpStatusCode statusCode, List<string> messages,T data)
    {
        StatusCode = (int)statusCode;
        Description = messages;
        Data = data;
    }

     public Response(HttpStatusCode statusCode, string messages)
    {
        StatusCode = (int)statusCode;
        Description.Add(messages);
    }

     public Response(HttpStatusCode statusCode, List<string> messages)
    {
        StatusCode = (int)statusCode;
        Description =messages;
        
    }

    public Response(HttpStatusCode statusCode, T data)
    {
        StatusCode = (int) statusCode;
        Data = data;
    }
    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
    
    
    
}
