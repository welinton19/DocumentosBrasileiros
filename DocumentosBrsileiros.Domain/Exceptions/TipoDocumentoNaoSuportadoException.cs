namespace DocumentosBrsileiros.Domain.Exceptions;

public class TipoDocumentoNaoSuportadoException : DomainException
{
    public TipoDocumentoNaoSuportadoException(string mensagem) : base(mensagem) { }
}
