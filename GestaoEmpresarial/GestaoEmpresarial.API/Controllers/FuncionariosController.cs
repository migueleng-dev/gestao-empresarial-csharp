using GestaoEmpresarial.Application.DTOs;
using GestaoEmpresarial.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GestaoEmpresarial.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FuncionariosController : ControllerBase
{
    private readonly FuncionarioService _service;

    public FuncionariosController(FuncionarioService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FuncionarioResponseDto>>> GetAll()
    {
        var funcionarios = await _service.GetAllAsync();
        return Ok(funcionarios);
    }

    [HttpGet("ativos")]
    public async Task<ActionResult<IEnumerable<FuncionarioResponseDto>>> GetAtivos()
    {
        var funcionarios = await _service.GetAtivosAsync();
        return Ok(funcionarios);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FuncionarioResponseDto>> GetById(int id)
    {
        var funcionario = await _service.GetByIdAsync(id);
        if (funcionario == null)
            return NotFound(new { message = "Funcionário não encontrado" });

        return Ok(funcionario);
    }

    [HttpPost]
    public async Task<ActionResult<FuncionarioResponseDto>> Create([FromBody] FuncionarioCreateDto dto)
    {
        try
        {
            var funcionario = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = funcionario.Id }, funcionario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<FuncionarioResponseDto>> Update(int id, [FromBody] FuncionarioCreateDto dto)
    {
        try
        {
            var funcionario = await _service.UpdateAsync(id, dto);
            return Ok(funcionario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPatch("{id}/demitir")]
    public async Task<ActionResult> Demitir(int id)
    {
        try
        {
            await _service.DemitirAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }
}
