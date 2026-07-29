namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Cnpj
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 12.345.678/0001-90 */ $"{Valor?.Substring(0, 2)}.{Valor?.Substring(2, 3)}.{Valor?.Substring(5, 3)}/{Valor?.Substring(8, 4)}-{Valor?.Substring(12, 2)}";

    public Cnpj(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "").Replace("/", "");
        Valido = true;
    }
}
