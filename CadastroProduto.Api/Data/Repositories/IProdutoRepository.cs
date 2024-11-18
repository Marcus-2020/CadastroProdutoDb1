using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Models;

namespace CadastroProduto.Api.Data.Repositories;

public interface IProdutoRepository
{
    Resultado<string> AdicionaProduto(Produto produto);
}