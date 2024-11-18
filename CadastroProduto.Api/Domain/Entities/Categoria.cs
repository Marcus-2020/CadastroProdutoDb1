namespace CadastroProduto.Api.Domain.Entities;

public class Categoria : BaseEntity
{
    public string Nome { get; set; }
    public Categoria? CategoriaPai { get; set; }
}