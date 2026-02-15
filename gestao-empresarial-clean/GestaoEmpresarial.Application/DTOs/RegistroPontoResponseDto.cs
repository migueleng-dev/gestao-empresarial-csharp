using GestaoEmpresarial.Domain.Entities;

namespace GestaoEmpresarial.Application.DTOs;

public class RegistroPontoResponseDto
{
    public int Id { get; set; }
    public int FuncionarioId { get; set; }
    public string FuncionarioNome { get; set; } = string.Empty;
    public DateTime DataHora { get; set; }
    public TipoRegistro Tipo { get; set; }
    public string TipoDescricao { get; set; } = string.Empty;
    public string? Localizacao { get; set; }
    public string? Observacao { get; set; }
    public bool ManualmenteAjustado { get; set; }
}
