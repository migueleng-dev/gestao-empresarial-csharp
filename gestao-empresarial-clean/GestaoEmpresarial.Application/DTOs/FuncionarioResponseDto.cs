namespace GestaoEmpresarial.Application.DTOs;

public class FuncionarioResponseDto
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
    public string DepartamentoNome { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public string? Foto { get; set; }
}
