using GestaoEmpresarial.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoEmpresarial.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Funcionario> Funcionarios { get; set; }
    public DbSet<Departamento> Departamentos { get; set; }
    public DbSet<RegistroPonto> RegistrosPonto { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Funcionario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(200);
            entity.Property(e => e.CPF).IsRequired().HasMaxLength(11);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(150);
            entity.Property(e => e.Telefone).HasMaxLength(20);
            entity.Property(e => e.Cargo).IsRequired().HasMaxLength(100);
            
            entity.HasIndex(e => e.CPF).IsUnique();
            entity.HasIndex(e => e.Email).IsUnique();
            
            entity.HasOne(e => e.Departamento)
                  .WithMany(d => d.Funcionarios)
                  .HasForeignKey(e => e.DepartamentoId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
            entity.Property(e => e.Descricao).HasMaxLength(500);
        });

        modelBuilder.Entity<RegistroPonto>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.DataHora).IsRequired();
            entity.Property(e => e.Tipo).IsRequired();
            
            entity.HasOne(e => e.Funcionario)
                  .WithMany(f => f.RegistrosPonto)
                  .HasForeignKey(e => e.FuncionarioId)
                  .OnDelete(DeleteBehavior.Cascade);
                  
            entity.HasIndex(e => new { e.FuncionarioId, e.DataHora });
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Login).IsRequired().HasMaxLength(50);
            entity.Property(e => e.SenhaHash).IsRequired();
            
            entity.HasIndex(e => e.Login).IsUnique();
            
            entity.HasOne(e => e.Funcionario)
                  .WithOne(f => f.Usuario)
                  .HasForeignKey<Usuario>(e => e.FuncionarioId)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>().HasData(
            new Departamento { Id = 1, Nome = "Tecnologia", Descricao = "Departamento de TI", Ativo = true },
            new Departamento { Id = 2, Nome = "Recursos Humanos", Descricao = "RH", Ativo = true },
            new Departamento { Id = 3, Nome = "Financeiro", Descricao = "Setor Financeiro", Ativo = true },
            new Departamento { Id = 4, Nome = "Comercial", Descricao = "Vendas e Marketing", Ativo = true }
        );
    }
}
