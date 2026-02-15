namespace GestaoEmpresarial.Domain.Entities;

public class RegistroPonto
{
    public int Id { get; set; }
    public int FuncionarioId { get; set; }
    public DateTime DataHora { get; set; }
    public TipoRegistro Tipo { get; set; }
    public string? Localizacao { get; set; }
    public string? Observacao { get; set; }
    public bool ManualmenteAjustado { get; set; } = false;
    public int? AjustadoPorUsuarioId { get; set; }
    
    public Funcionario Funcionario { get; set; } = null!;
}

public enum TipoRegistro
{
    Entrada = 1,
    Saida = 2,
    InicioIntervalo = 3,
    FimIntervalo = 4
}
