

using DocumentosBrasileiros.Application.DTOs;

namespace DocumentosBrsileiros.Domain.Services;

public interface IDocumentoValidatorService
{
    ValidarDocumentoResponse Validar(ValidarDocumentoRequest request);
}
