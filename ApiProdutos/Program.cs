using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ApiProdutos.Data;
using ApiProdutos;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApiProdutosContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ApiProdutosContext") ?? throw new InvalidOperationException("Connection string 'ApiProdutosContext' not found.")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapProdutoEndpoints();
app.Run();