using DocumentosBrasileiros.Application.DTOs;
using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Exceptions;
using DocumentosBrsileiros.Domain.Services;

namespace DocumentosBrasileiros.Application.UseCases;

public class ValidarDocumentoUseCase : IDocumentoValidatorService
{
    private readonly IEnumerable<IDocumentoValidator> _validators;

    public ValidarDocumentoUseCase(IEnumerable<IDocumentoValidator> validators)
    {
        _validators = validators;
    }

    public ValidarDocumentoResponse Validar(ValidarDocumentoRequest request)
    {
        if (!Enum.TryParse<TipoDocumento>(request.Tipo, out var tipo)) 
            throw new TipoDocumentoNaoSuportadoException($"Tipo '{request.Tipo}' não é suportado.");

        var validator = _validators.FirstOrDefault(v => v.TipoDocumentoSuportado == tipo)
            ?? throw new TipoDocumentoNaoSuportadoException($"Nenhum validator encontrado para '{request.Tipo}'.");

        var documento = Documento.Criar(request.Valor, tipo);
        var resultado = validator.Validar(documento);

        return new ValidarDocumentoResponse
        {
            Valido = resultado.Valido,
            Documento = resultado.Documento,
            Tipo = resultado.TipoDocumento.ToString(),
            Erros = resultado.Erros,
            ValidadoEm = resultado.ValidaEm
        };

    }
}
