using DocumentosBrsileiros.Domain.Enum;

namespace DocumentosBrsileiros.Domain.Exceptions;

public class DocumentoInvalidoException : DomainException
{
    public DocumentoInvalidoException(string mensagem) : base(mensagem) { }
}
