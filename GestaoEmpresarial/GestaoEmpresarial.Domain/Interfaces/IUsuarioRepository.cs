using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Domain.Interfaces;

public interface IUsuarioRepository
{
    Task<Usuario?> GetByIdAsync(int id);
    Task<Usuario?> GetByLoginAsync(string login);
    Task<Usuario> AddAsync(Usuario usuario);
    Task UpdateAsync(Usuario usuario);
}
