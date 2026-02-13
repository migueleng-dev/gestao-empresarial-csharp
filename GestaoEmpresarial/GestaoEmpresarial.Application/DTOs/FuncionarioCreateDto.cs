using System.ComponentModel.DataAnnotations;

namespace GestaoEmpresarial.Application.DTOs;

public class FuncionarioCreateDto
{
    [Required(ErrorMessage = "O nome é obrigatório")]
    [StringLength(200, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 200 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O CPF é obrigatório")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 caracteres")]
    public string CPF { get; set; } = string.Empty;

    [Required(ErrorMessage = "O email é obrigatório")]
    [EmailAddress(ErrorMessage = "Email inválido")]
    public string Email { get; set; } = string.Empty;

    [Phone(ErrorMessage = "Telefone inválido")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "A data de nascimento é obrigatória")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "A data de admissão é obrigatória")]
    public DateTime DataAdmissao { get; set; }

    [Required(ErrorMessage = "O salário é obrigatório")]
    [Range(0, double.MaxValue, ErrorMessage = "O salário deve ser maior que zero")]
    public decimal Salario { get; set; }

    [Required(ErrorMessage = "O cargo é obrigatório")]
    [StringLength(100, ErrorMessage = "O cargo deve ter no máximo 100 caracteres")]
    public string Cargo { get; set; } = string.Empty;

    [Required(ErrorMessage = "O departamento é obrigatório")]
    public int DepartamentoId { get; set; }

    public string? Foto { get; set; }
}
