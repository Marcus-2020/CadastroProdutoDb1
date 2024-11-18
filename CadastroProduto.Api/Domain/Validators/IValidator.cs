namespace CadastroProduto.Api.Domain.Validators;

public interface IValidator<T>
{
    (bool, List<(string, string)>) Valida(T obj);
}