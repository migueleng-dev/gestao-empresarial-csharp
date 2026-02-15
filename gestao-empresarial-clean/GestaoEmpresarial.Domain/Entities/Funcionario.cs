namespace GestaoEmpresarial.Domain.Entities;

public class Funcionario
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }
    public decimal Salario { get; set; }
    public string Cargo { get; set; } = string.Empty;
    public int DepartamentoId { get; set; }
    public bool Ativo { get; set; } = true;
    public string? Foto { get; set; }
    
    public Departamento Departamento { get; set; } = null!;
    public ICollection<RegistroPonto> RegistrosPonto { get; set; } = new List<RegistroPonto>();
    public Usuario? Usuario { get; set; }
}
