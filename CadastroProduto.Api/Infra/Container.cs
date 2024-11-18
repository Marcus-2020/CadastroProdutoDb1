using CadastroProduto.Api.Data.Repositories;
using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Services;
using CadastroProduto.Api.Domain.Validators;

namespace CadastroProduto.Api.Infra;

public static class Container
{
    public static void AddServices(this IServiceCollection sc)
    {
        sc.AddScoped<IProdutoRepository, ProdutoRepository>();
        sc.AddScoped<IValidator<Produto>, ProdutoValidator>();
        sc.AddScoped<IProdutoService, ProdutoService>();
    }
}