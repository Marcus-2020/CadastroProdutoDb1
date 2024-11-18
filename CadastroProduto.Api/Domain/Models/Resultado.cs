namespace CadastroProduto.Api.Domain.Models;

public struct Resultado<T>
{
    private bool _sucesso;
    public bool EhSucesso => _sucesso;
    public bool EhFalha => !_sucesso;

    private T? _valor;
    public T? Valor => _valor;
    
    public Erro Erro { get; private set; }
    

    private Resultado(bool sucesso, T? valor, Erro erro = default)
    {
        _sucesso = sucesso;
        _valor = valor;
        Erro = erro;
    }

    public static Resultado<T> Ok(T valor)
    {
        return new Resultado<T>(true, valor);
    }

    public static Resultado<T> Falha(Erro erro)
    {
        return new Resultado<T>(false, default, erro);
    }
}

public struct Erro
{
    public string Message { get; private set; }
    public Exception? Exception { get; private set; }

    public Erro(string message, Exception? exception = null)
    {
        Message = message;
        Exception = exception;
    }
}