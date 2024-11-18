using CadastroProduto.Api.Domain.Entities;
using CadastroProduto.Api.Domain.Enums;

namespace CadastroProduto.Api.Domain.Validators;

public class ProdutoValidator
{
    public (bool, List<(string, string)>) Valida(Produto produto)
    {
        List<(string,string)> erros = [];

        if (produto.Nome.Trim() is null or "")
        {
            erros.Add(("Nome", "Nome é obrigatório"));
        }

        if (produto.Descricao.Trim() is null or "")
        {
            erros.Add(("Descricao", "A descrição do produto é obrigatória"));
        }

        if (produto.Valor <= 0.0M)
        {
            erros.Add(("Valor", "Valor não pode ser menor que 0.01"));
        }

        int countImg = 0;
        int countVideo = 0;
        foreach (var arquivo in produto.Arquivos)
        {
            if (arquivo.Tipo == ArquivoTipoEnum.Imagem)
            {
                if (countImg != 10)
                {
                    countImg++;
                    continue;
                }
                erros.Add(("Arquivos", "Não é permitido mais de 10 imagens"));
                break;
            }

            if (countVideo != 10)
            {
                countVideo++;
                continue;
            }
            erros.Add(("Arquivos", "Não é permitido mais de 10 imagens"));
            break;
        }

        return (erros.Count == 0, erros);
    } 
}