using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Domain.Interfaces;

public interface IFuncionarioRepository
{
    Task<IEnumerable<Funcionario>> GetAllAsync();
    Task<Funcionario?> GetByIdAsync(int id);
    Task<Funcionario?> GetByCPFAsync(string cpf);
    Task<IEnumerable<Funcionario>> GetByDepartamentoAsync(int departamentoId);
    Task<IEnumerable<Funcionario>> GetAtivosAsync();
    Task<Funcionario> AddAsync(Funcionario funcionario);
    Task UpdateAsync(Funcionario funcionario);
    Task DeleteAsync(int id);
}
