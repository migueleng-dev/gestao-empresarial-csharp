namespace GestaoEmpresarial.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public int FuncionarioId { get; set; }
    public TipoUsuario Tipo { get; set; }
    public bool Ativo { get; set; } = true;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime? UltimoAcesso { get; set; }
    
    public Funcionario Funcionario { get; set; } = null!;
}

public enum TipoUsuario
{
    Funcionario = 1,
    Gestor = 2,
    RH = 3,
    Administrador = 4
}
