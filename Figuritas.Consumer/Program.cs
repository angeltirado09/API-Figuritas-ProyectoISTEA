using Figuritas.Abstractions.Interfaces;
using Figuritas.Consumer.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddHttpClient<IFiguritaService, FiguritaService>(client =>
{
    client.BaseAddress = new Uri("https://6a3adaf6917c7b14c74e2a0f.mockapi.io/backend/");
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
