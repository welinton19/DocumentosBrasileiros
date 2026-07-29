using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Services;

namespace DocumentosBrsileiros.Domain.Validator;

public class PisValidator : IDocumentoValidator
{
    public TipoDocumento TipoDocumentoSuportado => TipoDocumento.PIS;

    public ResultadoValidacao Validar(Documento documento)
    {

        var doc = documento.Valor?.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

        if (string.IsNullOrEmpty(doc) || doc.Length != 11)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "PIS deve conter 11 dígitos." });

        if (!doc.All(char.IsDigit))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "PIS deve conter apenas números." });

        int[] pesos = { 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        var soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(doc[i].ToString()) * pesos[i];

        var resto = soma % 11;
        var digito = resto < 2 ? 0 : 11 - resto;

        if (digito != int.Parse(doc[10].ToString()))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "PIS com dígito verificador inválido." });

        return ResultadoValidacao.Criar(true, documento.Valor, TipoDocumentoSuportado, null,
            new List<string>());
    }
}
