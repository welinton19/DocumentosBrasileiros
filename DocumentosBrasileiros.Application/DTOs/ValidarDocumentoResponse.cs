namespace DocumentosBrasileiros.Application.DTOs;

public class ValidarDocumentoResponse
{
    public bool Valido { get; set; }
    public string? Documento { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public IReadOnlyList<string> Erros { get; set; } = new List<string>();
    public DateTime ValidadoEm { get; set; } = DateTime.UtcNow;
}
