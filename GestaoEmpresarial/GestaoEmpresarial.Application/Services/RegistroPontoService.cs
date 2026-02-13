using GestaoEmpresarial.Application.DTOs;
using GestaoEmpresarial.Domain.Entities;
using GestaoEmpresarial.Domain.Interfaces;

namespace GestaoEmpresarial.Application.Services;

public class RegistroPontoService
{
    private readonly IRegistroPontoRepository _repository;
    private readonly IFuncionarioRepository _funcionarioRepository;

    public RegistroPontoService(
        IRegistroPontoRepository repository,
        IFuncionarioRepository funcionarioRepository)
    {
        _repository = repository;
        _funcionarioRepository = funcionarioRepository;
    }

    public async Task<RegistroPontoResponseDto> RegistrarPontoAsync(RegistroPontoCreateDto dto)
    {
        var funcionario = await _funcionarioRepository.GetByIdAsync(dto.FuncionarioId);
        if (funcionario == null)
            throw new Exception("Funcionário não encontrado");

        if (!funcionario.Ativo)
            throw new Exception("Funcionário inativo não pode registrar ponto");

        var registro = new RegistroPonto
        {
            FuncionarioId = dto.FuncionarioId,
            DataHora = DateTime.Now,
            Tipo = dto.Tipo,
            Localizacao = dto.Localizacao,
            Observacao = dto.Observacao
        };

        var created = await _repository.AddAsync(registro);
        
        return new RegistroPontoResponseDto
        {
            Id = created.Id,
            FuncionarioId = created.FuncionarioId,
            FuncionarioNome = funcionario.Nome,
            DataHora = created.DataHora,
            Tipo = created.Tipo,
            TipoDescricao = created.Tipo.ToString(),
            Localizacao = created.Localizacao,
            Observacao = created.Observacao,
            ManualmenteAjustado = created.ManualmenteAjustado
        };
    }

    public async Task<IEnumerable<RegistroPontoResponseDto>> GetByFuncionarioAsync(int funcionarioId)
    {
        var registros = await _repository.GetByFuncionarioAsync(funcionarioId);
        return registros.Select(MapToDto);
    }

    public async Task<IEnumerable<RegistroPontoResponseDto>> GetByPeriodoAsync(
        int funcionarioId, 
        DateTime inicio, 
        DateTime fim)
    {
        var registros = await _repository.GetByFuncionarioEPeriodoAsync(funcionarioId, inicio, fim);
        return registros.Select(MapToDto);
    }

    public async Task<RegistroPontoResponseDto?> GetUltimoRegistroAsync(int funcionarioId)
    {
        var registro = await _repository.GetUltimoRegistroAsync(funcionarioId);
        return registro != null ? MapToDto(registro) : null;
    }

    private static RegistroPontoResponseDto MapToDto(RegistroPonto r)
    {
        return new RegistroPontoResponseDto
        {
            Id = r.Id,
            FuncionarioId = r.FuncionarioId,
            FuncionarioNome = r.Funcionario?.Nome ?? "",
            DataHora = r.DataHora,
            Tipo = r.Tipo,
            TipoDescricao = r.Tipo.ToString(),
            Localizacao = r.Localizacao,
            Observacao = r.Observacao,
            ManualmenteAjustado = r.ManualmenteAjustado
        };
    }
}
