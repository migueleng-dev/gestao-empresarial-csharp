using System.ComponentModel.DataAnnotations;
using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Application.DTOs;

public class RegistroPontoCreateDto
{
    [Required(ErrorMessage = "O ID do funcionário é obrigatório")]
    public int FuncionarioId { get; set; }

    [Required(ErrorMessage = "O tipo de registro é obrigatório")]
    public TipoRegistro Tipo { get; set; }

    public string? Localizacao { get; set; }
    public string? Observacao { get; set; }
}
