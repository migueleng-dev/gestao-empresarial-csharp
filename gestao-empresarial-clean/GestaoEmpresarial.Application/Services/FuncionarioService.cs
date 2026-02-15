using GestaoEmpresarial.Application.DTOs;
using GestaoEmpresarial.Domain.Entities;
using GestaoEmpresarial.Domain.Interfaces;

namespace GestaoEmpresarial.Application.Services;

public class FuncionarioService
{
    private readonly IFuncionarioRepository _repository;

    public FuncionarioService(IFuncionarioRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<FuncionarioResponseDto>> GetAllAsync()
    {
        var funcionarios = await _repository.GetAllAsync();
        return funcionarios.Select(MapToDto);
    }

    public async Task<FuncionarioResponseDto?> GetByIdAsync(int id)
    {
        var funcionario = await _repository.GetByIdAsync(id);
        return funcionario != null ? MapToDto(funcionario) : null;
    }

    public async Task<IEnumerable<FuncionarioResponseDto>> GetAtivosAsync()
    {
        var funcionarios = await _repository.GetAtivosAsync();
        return funcionarios.Select(MapToDto);
    }

    public async Task<FuncionarioResponseDto> CreateAsync(FuncionarioCreateDto dto)
    {
        var cpfExistente = await _repository.GetByCPFAsync(dto.CPF);
        if (cpfExistente != null)
            throw new Exception("Já existe um funcionário com este CPF");

        var funcionario = new Funcionario
        {
            Nome = dto.Nome,
            CPF = dto.CPF,
            Email = dto.Email,
            Telefone = dto.Telefone,
            DataNascimento = dto.DataNascimento,
            DataAdmissao = dto.DataAdmissao,
            Salario = dto.Salario,
            Cargo = dto.Cargo,
            DepartamentoId = dto.DepartamentoId,
            Foto = dto.Foto,
            Ativo = true
        };

        var created = await _repository.AddAsync(funcionario);
        var result = await _repository.GetByIdAsync(created.Id);
        return MapToDto(result!);
    }

    public async Task<FuncionarioResponseDto> UpdateAsync(int id, FuncionarioCreateDto dto)
    {
        var funcionario = await _repository.GetByIdAsync(id);
        if (funcionario == null)
            throw new Exception("Funcionário não encontrado");

        funcionario.Nome = dto.Nome;
        funcionario.Email = dto.Email;
        funcionario.Telefone = dto.Telefone;
        funcionario.DataNascimento = dto.DataNascimento;
        funcionario.Salario = dto.Salario;
        funcionario.Cargo = dto.Cargo;
        funcionario.DepartamentoId = dto.DepartamentoId;
        funcionario.Foto = dto.Foto;

        await _repository.UpdateAsync(funcionario);
        var updated = await _repository.GetByIdAsync(id);
        return MapToDto(updated!);
    }

    public async Task DemitirAsync(int id)
    {
        var funcionario = await _repository.GetByIdAsync(id);
        if (funcionario == null)
            throw new Exception("Funcionário não encontrado");

        funcionario.Ativo = false;
        funcionario.DataDemissao = DateTime.Now;
        await _repository.UpdateAsync(funcionario);
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }

    private static FuncionarioResponseDto MapToDto(Funcionario f)
    {
        return new FuncionarioResponseDto
        {
            Id = f.Id,
            Nome = f.Nome,
            CPF = f.CPF,
            Email = f.Email,
            Telefone = f.Telefone,
            DataNascimento = f.DataNascimento,
            DataAdmissao = f.DataAdmissao,
            DataDemissao = f.DataDemissao,
            Salario = f.Salario,
            Cargo = f.Cargo,
            DepartamentoId = f.DepartamentoId,
            DepartamentoNome = f.Departamento?.Nome ?? "",
            Ativo = f.Ativo,
            Foto = f.Foto
        };
    }
}
