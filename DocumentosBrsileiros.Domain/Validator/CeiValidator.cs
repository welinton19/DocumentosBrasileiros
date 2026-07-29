using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Services;

namespace DocumentosBrsileiros.Domain.Validator;

public class CeiValidator : IDocumentoValidator
{
    public TipoDocumento TipoDocumentoSuportado => TipoDocumento.CEI;
    public ResultadoValidacao Validar(Documento documento)
    {
        var doc = documento.Valor?.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

        if (string.IsNullOrEmpty(doc) || doc.Length != 12)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CEI deve conter 12 dígitos." });

        if (!doc.All(char.IsDigit))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CEI deve conter apenas números." });

        
        int[] pesos = { 7, 4, 1, 8, 5, 2, 1, 6, 3, 7, 4 };
        var soma = 0;

        for (int i = 0; i < 11; i++)
        {
            var produto = int.Parse(doc[i].ToString()) * pesos[i];
            soma += (produto / 10) + (produto % 10); 
        }

        var digito = soma % 10;
        if (digito != 0) digito = 10 - digito;

        if (digito != int.Parse(doc[11].ToString()))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CEI com dígito verificador inválido." });

        return ResultadoValidacao.Criar(true, documento.Valor, TipoDocumentoSuportado, null,
            new List<string>());
    }
}

