using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Domain.Interfaces;

public interface IDepartamentoRepository
{
    Task<IEnumerable<Departamento>> GetAllAsync();
    Task<Departamento?> GetByIdAsync(int id);
    Task<Departamento> AddAsync(Departamento departamento);
    Task UpdateAsync(Departamento departamento);
    Task DeleteAsync(int id);
}
