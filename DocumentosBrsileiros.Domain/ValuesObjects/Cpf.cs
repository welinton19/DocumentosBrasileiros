namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Cpf 
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 123.456.789-10 */ $"{Valor?.Substring(0, 3)}.{Valor?.Substring(3, 3)}.{Valor?.Substring(6, 3)}-{Valor?.Substring(9, 2)}";

    public Cpf(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "");
        Valido = true;
    }
}
