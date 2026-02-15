using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Domain.Interfaces;

public interface IRegistroPontoRepository
{
    Task<IEnumerable<RegistroPonto>> GetByFuncionarioAsync(int funcionarioId);
    Task<IEnumerable<RegistroPonto>> GetByFuncionarioEPeriodoAsync(int funcionarioId, DateTime inicio, DateTime fim);
    Task<RegistroPonto?> GetUltimoRegistroAsync(int funcionarioId);
    Task<RegistroPonto> AddAsync(RegistroPonto registro);
    Task UpdateAsync(RegistroPonto registro);
    Task DeleteAsync(int id);
}
