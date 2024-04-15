using Infrastructure.Data;
using Infrastructure.Services.BookServices;
using Infrastructure.Services.LoanServices;
using Infrastructure.Services.MemberServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var connection = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<DataContext>(conf=> conf.UseNpgsql(connection));

builder.Services.AddScoped<IBookService,BookService>();
builder.Services.AddScoped<ILoanService,LoanService>();
builder.Services.AddScoped<IMemberService,MemberService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();

