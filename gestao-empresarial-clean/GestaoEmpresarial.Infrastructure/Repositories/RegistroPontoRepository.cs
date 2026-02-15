using GestaoEmpresarial.Domain.Entities;
using GestaoEmpresarial.Domain.Interfaces;
using GestaoEmpresarial.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestaoEmpresarial.Infrastructure.Repositories;

public class RegistroPontoRepository : IRegistroPontoRepository
{
    private readonly AppDbContext _context;

    public RegistroPontoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int funcionarioId)
    {
        return await _context.RegistrosPonto
            .Include(r => r.Funcionario)
            .Where(r => r.FuncionarioId == funcionarioId)
            .OrderByDescending(r => r.DataHora)
            .ToListAsync();
    }

    public async Task<IEnumerable<RegistroPonto>> GetByFuncionarioEPeriodoAsync(int funcionarioId, DateTime inicio, DateTime fim)
    {
        return await _context.RegistrosPonto
            .Include(r => r.Funcionario)
            .Where(r => r.FuncionarioId == funcionarioId && 
                       r.DataHora >= inicio && 
                       r.DataHora <= fim)
            .OrderBy(r => r.DataHora)
            .ToListAsync();
    }

    public async Task<RegistroPonto?> GetUltimoRegistroAsync(int funcionarioId)
    {
        return await _context.RegistrosPonto
            .Where(r => r.FuncionarioId == funcionarioId)
            .OrderByDescending(r => r.DataHora)
            .FirstOrDefaultAsync();
    }

    public async Task<RegistroPonto> AddAsync(RegistroPonto registro)
    {
        await _context.RegistrosPonto.AddAsync(registro);
        await _context.SaveChangesAsync();
        return registro;
    }

    public async Task UpdateAsync(RegistroPonto registro)
    {
        _context.RegistrosPonto.Update(registro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var registro = await _context.RegistrosPonto.FindAsync(id);
        if (registro != null)
        {
            _context.RegistrosPonto.Remove(registro);
            await _context.SaveChangesAsync();
        }
    }
}
