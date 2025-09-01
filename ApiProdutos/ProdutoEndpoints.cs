using Microsoft.EntityFrameworkCore;
using ApiProdutos.Data;
using ApiProdutos.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace ApiProdutos;

public static class ProdutoEndpoints
{
    public static void MapProdutoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Produtos").WithTags(nameof(Produto));

        group.MapGet("/", async (ApiProdutosContext db) =>
        {
            return await db.Produto.ToListAsync();
        })
        .WithName("GetAllProdutos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Produto>, NotFound>> (int id, ApiProdutosContext db) =>
        {
            return await db.Produto.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Produto model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProdutoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Produto produto, ApiProdutosContext db) =>
        {
            var affected = await db.Produto
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, produto.Id)
                    .SetProperty(m => m.Nome, produto.Nome)
                    .SetProperty(m => m.Preco, produto.Preco)
                    .SetProperty(m => m.Estoque, produto.Estoque)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProduto")
        .WithOpenApi();

        group.MapPost("/", async (Produto produto, ApiProdutosContext db) =>
        {
            db.Produto.Add(produto);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Produto/{produto.Id}",produto);
        })
        .WithName("CreateProduto")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, ApiProdutosContext db) =>
        {
            var affected = await db.Produto
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProduto")
        .WithOpenApi();
    }
}
