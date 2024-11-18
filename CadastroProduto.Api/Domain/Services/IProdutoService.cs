using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Models;

namespace CadastroProduto.Api.Domain.Services;

public interface IProdutoService
{
    Resultado<string> AdicionaProduto(Produto produto);
}