using DocumentosBrsileiros.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentosBrsileiros.Domain.Entities;

public class ResultadoValidacao
{
    public bool Valido { get; private set; }
    public string? Documento { get; private set; }
    public TipoDocumento TipoDocumento { get; private set; }
    public string? DocumentoFormato { get; private set; }
    public IReadOnlyList<string> Erros { get; private set; } = new List<string>();
    public DateTime ValidaEm { get; private set; }

    private ResultadoValidacao() { }

    public static ResultadoValidacao Criar(bool valido, string? documento, TipoDocumento tipoDocumento, string? documentoFormato, IReadOnlyList<string> erros)
    {
        var resultado = new ResultadoValidacao();
        resultado.Valido = valido;
        resultado.Documento = documento;
        resultado.TipoDocumento = tipoDocumento;
        resultado.DocumentoFormato = documentoFormato;
        resultado.Erros = erros;
        resultado.ValidaEm = DateTime.UtcNow;
        return resultado;
    }
}
