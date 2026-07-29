using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Services;
using System.Xml;

namespace DocumentosBrsileiros.Domain.Validator;

public class CnpjValidator : IDocumentoValidator
{
    public TipoDocumento TipoDocumentoSuportado => TipoDocumento.CNPJ;

    public ResultadoValidacao Validar(Documento documento)
    {
        var doc = documento.Valor?.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

        if (doc is null || doc.Length != 14)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null, new List<string> { "CNPJ inválido" });

        if(doc.Distinct().Count() == 1)
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null, new List<string> { "CNPJ não pode conter todos os dígitos iguais." });

        if(!doc.All(char.IsDigit))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null, new List<string> { "CNPJ deve conter apenas números." });

        var soma = 0;
        for(int i = 0; i < 12; i++)
            soma += int.Parse(doc[i].ToString()) * (i < 4 ? 5 - i : 13 - i);
        
        var primeiroDigito = (soma % 11) < 2 ? 0 : 11 - (soma % 11);
        if(primeiroDigito == 10 || primeiroDigito == 11) primeiroDigito = 0;
        if(primeiroDigito != int.Parse(doc[12].ToString()))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null, new List<string> { "CNPJ inválido" });

        soma = 0;
        for (int i = 0; i < 13; i++)
            soma += int.Parse(doc[i].ToString()) * (i < 5 ? 6 - i : 14 - i);

        var segundoDigito = (soma % 11) < 2 ? 0 : 11 - (soma % 11);
        if(segundoDigito == 10 || segundoDigito == 11) segundoDigito = 0;
        if(segundoDigito != int.Parse(doc[13].ToString()))
            return ResultadoValidacao.Criar(false, documento.Valor, TipoDocumentoSuportado, null, new List<string> { "CNPJ inválido" });

        return ResultadoValidacao.Criar(true, documento.Valor, TipoDocumentoSuportado, null, new List<string>());
    }
}
