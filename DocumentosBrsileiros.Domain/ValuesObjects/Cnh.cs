namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Cnh
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 12345678900 */ Valor;

    public Cnh(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "");
        Valido = true;
    }
}
