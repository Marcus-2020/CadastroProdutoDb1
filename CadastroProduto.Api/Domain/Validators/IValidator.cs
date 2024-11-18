namespace CadastroProduto.Api.Domain.Validators;

public interface IValidator<T>
{
    (bool EhValido, Dictionary<string, string> Erros) Valida(T obj);
}