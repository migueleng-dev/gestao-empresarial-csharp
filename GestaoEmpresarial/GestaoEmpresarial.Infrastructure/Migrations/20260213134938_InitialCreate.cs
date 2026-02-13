using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GestaoEmpresarial.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    CPF = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Telefone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDemissao = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Salario = table.Column<decimal>(type: "TEXT", nullable: false),
                    Cargo = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    DepartamentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistrosPonto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataHora = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Localizacao = table.Column<string>(type: "TEXT", nullable: true),
                    Observacao = table.Column<string>(type: "TEXT", nullable: true),
                    ManualmenteAjustado = table.Column<bool>(type: "INTEGER", nullable: false),
                    AjustadoPorUsuarioId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistrosPonto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistrosPonto_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Login = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    SenhaHash = table.Column<string>(type: "TEXT", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    Tipo = table.Column<int>(type: "INTEGER", nullable: false),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UltimoAcesso = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departamentos",
                columns: new[] { "Id", "Ativo", "Descricao", "Nome" },
                values: new object[,]
                {
                    { 1, true, "Departamento de TI", "Tecnologia" },
                    { 2, true, "RH", "Recursos Humanos" },
                    { 3, true, "Setor Financeiro", "Financeiro" },
                    { 4, true, "Vendas e Marketing", "Comercial" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_CPF",
                table: "Funcionarios",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_Email",
                table: "Funcionarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistrosPonto_FuncionarioId_DataHora",
                table: "RegistrosPonto",
                columns: new[] { "FuncionarioId", "DataHora" });

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FuncionarioId",
                table: "Usuarios",
                column: "FuncionarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_Login",
                table: "Usuarios",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistrosPonto");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Departamentos");
        }
    }
}
