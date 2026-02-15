using GestaoEmpresarial.Domain.Entities;
using GestaoEmpresarial.Domain.Interfaces;
using GestaoEmpresarial.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEmpresarial.Infrastructure.Repositories;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Funcionario>> GetAllAsync()
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento)
            .ToListAsync();
    }

    public async Task<Funcionario?> GetByIdAsync(int id)
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento)
            .Include(f => f.Usuario)
            .FirstOrDefaultAsync(f => f.Id == id);
    }

    public async Task<Funcionario?> GetByCPFAsync(string cpf)
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento)
            .FirstOrDefaultAsync(f => f.CPF == cpf);
    }

    public async Task<IEnumerable<Funcionario>> GetByDepartamentoAsync(int departamentoId)
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento)
            .Where(f => f.DepartamentoId == departamentoId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Funcionario>> GetAtivosAsync()
    {
        return await _context.Funcionarios
            .Include(f => f.Departamento)
            .Where(f => f.Ativo)
            .ToListAsync();
    }

    public async Task<Funcionario> AddAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
        return funcionario;
    }

    public async Task UpdateAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var funcionario = await GetByIdAsync(id);
        if (funcionario != null)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
    }
}
