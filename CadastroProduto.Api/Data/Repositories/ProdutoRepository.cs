using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Models;

namespace CadastroProduto.Api.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    public Resultado<string> AdicionaProduto(Produto produto)
    {
        try
        {
            string sql = 
                """
                    INSERT INTO produto (Id, Nome, Descricao, Valor) VALUES (@Id, @Nome, @Descricao, @Valor);
                """;
            
            // conexão com banco

            var produtoId = Guid.NewGuid();
            produto.Id = produtoId;
            
            return Resultado<string>.Ok(produtoId.ToString());
        }
        catch (Exception ex)
        {
            return Resultado<string>.Falha(new Erro("Ocorreu um erro ao adicionar o produto", ex));
        }
    }    
}