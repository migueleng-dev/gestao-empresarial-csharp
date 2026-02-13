using GestaoEmpresarial.Application.DTOs;
using GestaoEmpresarial.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PontoController : ControllerBase
{
    private readonly RegistroPontoService _service;

    public PontoController(RegistroPontoService service)
    {
        _service = service;
    }

    [HttpPost("registrar")]
    public async Task<ActionResult<RegistroPontoResponseDto>> Registrar([FromBody] RegistroPontoCreateDto dto)
    {
        try
        {
            var registro = await _service.RegistrarPontoAsync(dto);
            return CreatedAtAction(nameof(GetUltimo), new { funcionarioId = dto.FuncionarioId }, registro);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpGet("funcionario/{funcionarioId}")]
    public async Task<ActionResult<IEnumerable<RegistroPontoResponseDto>>> GetByFuncionario(int funcionarioId)
    {
        var registros = await _service.GetByFuncionarioAsync(funcionarioId);
        return Ok(registros);
    }

    [HttpGet("funcionario/{funcionarioId}/periodo")]
    public async Task<ActionResult<IEnumerable<RegistroPontoResponseDto>>> GetByPeriodo(
        int funcionarioId,
        [FromQuery] DateTime inicio,
        [FromQuery] DateTime fim)
    {
        var registros = await _service.GetByPeriodoAsync(funcionarioId, inicio, fim);
        return Ok(registros);
    }

    [HttpGet("funcionario/{funcionarioId}/ultimo")]
    public async Task<ActionResult<RegistroPontoResponseDto>> GetUltimo(int funcionarioId)
    {
        var registro = await _service.GetUltimoRegistroAsync(funcionarioId);
        if (registro == null)
            return NotFound(new { message = "Nenhum registro encontrado" });

        return Ok(registro);
    }
}
