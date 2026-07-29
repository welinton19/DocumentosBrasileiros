using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Services;

namespace DocumentosBrsileiros.Domain.Validator;

public class CpfValidator : IDocumentoValidator
{
    public TipoDocumento TipoDocumentoSuportado => TipoDocumento.CPF;

    public ResultadoValidacao Validar(Documento documento)
    {
        var doc = documento.Valor?.Replace(".", "").Replace("-", "").Trim();

        if (doc is null || doc.Length != 11)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CPF deve conter 11 dígitos." });

        if (doc.Distinct().Count() == 1)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CPF não pode conter todos os dígitos iguais." });

        if (!doc.All(char.IsDigit))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CPF deve conter apenas números." });

        
        var soma = 0;
        for (int i = 0; i < 9; i++)
            soma += (doc[i] - '0') * (10 - i);

        var digito1 = (soma * 10) % 11;
        if (digito1 == 10 || digito1 == 11) digito1 = 0;
        if (digito1 != (doc[9] - '0'))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CPF inválido." });

        
        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += (doc[i] - '0') * (11 - i);

        var digito2 = (soma * 10) % 11;
        if (digito2 == 10 || digito2 == 11) digito2 = 0;
        if (digito2 != (doc[10] - '0'))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null,
                new List<string> { "CPF inválido." });

        return ResultadoValidacao.Criar(true, documento.Valor, TipoDocumentoSuportado, null,
            new List<string>());
    }
}
