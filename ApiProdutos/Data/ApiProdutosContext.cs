using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProdutos.Entities;

namespace ApiProdutos.Data
{
    public class ApiProdutosContext : DbContext
    {
        public ApiProdutosContext (DbContextOptions<ApiProdutosContext> options)
            : base(options)
        {
        }

        public DbSet<ApiProdutos.Entities.Produto> Produto { get; set; } = default!;
    }
}
