namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Cei
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 1234567890123 */ Valor;

    public Cei(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "");
        Valido = true;
    }
}
