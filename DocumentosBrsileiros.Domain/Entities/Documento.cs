using DocumentosBrsileiros.Domain.Enum;

namespace DocumentosBrsileiros.Domain.Entities;

public class Documento
{
    public string? Valor { get; private set; }
    public TipoDocumento Tipo { get; private set; }
    public string? ValorSintetizado { get; private set; }

    private Documento() { }

    public static Documento Criar(string valor, TipoDocumento tipo)
    {
        var documento = new Documento();
        documento.Valor = valor;
        documento.Tipo = tipo;
        documento.ValorSintetizado = tipo.ToString();
        return documento;
    }
}
