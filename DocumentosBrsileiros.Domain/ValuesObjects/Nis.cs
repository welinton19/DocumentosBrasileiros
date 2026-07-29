namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Nis
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 1234567890123 */ Valor;

    public Nis(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "");
        Valido = true;
    }
}
