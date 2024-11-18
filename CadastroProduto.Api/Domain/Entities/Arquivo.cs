using CadastroProduto.Api.Domain.Enums;

namespace CadastroProduto.Api.Domain.Entities;

public class Arquivo : BaseEntity
{
    public ArquivoTipoEnum Tipo { get; set; }
    public byte[] Dados { get; set; }
}