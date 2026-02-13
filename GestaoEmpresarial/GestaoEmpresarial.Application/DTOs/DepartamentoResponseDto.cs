namespace GestaoEmpresarial.Application.DTOs;

public class DepartamentoResponseDto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public bool Ativo { get; set; }
    public int TotalFuncionarios { get; set; }
}
