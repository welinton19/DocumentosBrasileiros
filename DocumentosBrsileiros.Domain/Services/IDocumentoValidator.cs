using DocumentosBrsileiros.Domain.Entities;
using DocumentosBrsileiros.Domain.Enum;

namespace DocumentosBrsileiros.Domain.Services;

public interface IDocumentoValidator
{
    TipoDocumento TipoDocumentoSuportado { get; }
    ResultadoValidacao Validar(Documento documento);
}
