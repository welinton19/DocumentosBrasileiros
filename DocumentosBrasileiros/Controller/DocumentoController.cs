using DocumentosBrasileiros.Application.DTOs;
using DocumentosBrsileiros.Domain.Enum;
using DocumentosBrsileiros.Domain.Exceptions;
using DocumentosBrsileiros.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DocumentosBrasileiros.Controller;

[Route("api/[controller]")]
[ApiController]
public class DocumentoController : ControllerBase
{
    private readonly IDocumentoValidatorService _documentoValidatorService;

    public DocumentoController(IDocumentoValidatorService documentoValidatorService)
    {
        _documentoValidatorService = documentoValidatorService;

    }

    /// <summary>
    /// Valida um documento Brasileiro (CPF,CNPJ, CNH, NIS, CEI E PIS) com base no tipo fornecido.
    /// </summary>

    [HttpPost("validar")]
    [ProducesResponseType(typeof(ValidarDocumentoResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Validar([FromBody] ValidarDocumentoRequest request) 
    {
        try
        {
            var resultado = _documentoValidatorService.Validar(request);
            return Ok(resultado);
        }
        catch (TipoDocumentoNaoSuportadoException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
        catch (DomainException ex)
        {
            return BadRequest(new { erro = ex.Message });
        }
    }

    /// <summary>
    /// Retorna os tipos de documentos suportados
    /// </summary>
    [HttpGet("tipos")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult TiposSuportados()
    {
        var tipos = Enum.GetNames<TipoDocumento>();
        return Ok(new { tiposSuportados = tipos });
    }
}

