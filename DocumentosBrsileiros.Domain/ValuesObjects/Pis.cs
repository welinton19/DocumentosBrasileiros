namespace DocumentosBrsileiros.Domain.ValuesObjects;

public sealed class Pis
{
    public string? Valor { get; }
    public bool Valido { get; }
    public string Formatado => /* 12345678900 */ Valor;
    public Pis(string? valor)
    {
        Valor = valor?.Replace(".", "").Replace("-", "");
        Valido = true;
    }
}
