using CardApp.Models;
using CardApp.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CardAppContext>(cntx => cntx.UseSqlServer(
    builder.Configuration.GetConnectionString("CreditCardApp")
    ));
builder.Services.AddScoped<CreditCardRepository>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.Run();
