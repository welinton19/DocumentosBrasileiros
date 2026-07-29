using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Services;

namespace DocumentosBrsileiros.Domain.Validator;

public class CnhValidator : IDocumentoValidator
{
    public TipoDocumento TipoDocumentoSuportado => TipoDocumento.CNH;

    public ResultadoValidacao Validar(Documento documento)
    {
        var doc = documento.Valor?.Replace(".", "").Replace("-", "").Trim();

        if (string.IsNullOrEmpty(doc) || doc.Length != 11)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CNH deve conter 11 dígitos." });

        if (!doc.All(char.IsDigit))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CNH deve conter apenas números." });

        if (doc.Distinct().Count() == 1)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CNH inválida." });

        
        var soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(doc[i].ToString()) * (9 - i);

        var primeiro = soma % 11;
        var dstPrimeiro = primeiro >= 10 ? 1 : 0; 
        if (primeiro >= 10) primeiro = 0;

        
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(doc[i].ToString()) * (1 + i);

        var segundo = (soma % 11);
        if (dstPrimeiro == 1) segundo = (segundo + 2) % 11; 
        if (segundo >= 10) segundo = 0;

        if (primeiro != int.Parse(doc[9].ToString()) || segundo != int.Parse(doc[10].ToString()))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CNH com dígitos verificadores inválidos." });

        return ResultadoValidacao.Criar(true, documento.Valor, TipoDocumentoSuportado, null,
            new List<string>());
    }
}

