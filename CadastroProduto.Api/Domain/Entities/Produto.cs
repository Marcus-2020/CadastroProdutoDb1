using Microsoft.AspNetCore.Authentication;

namespace CadastroProduto.Api.Domain.Entities;

public class Produto : BaseEntity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Valor { get; set; }
    public List<Arquivo> Arquivos { get; set; }
    public Dictionary<string, object> Atributos { get; set; }
}