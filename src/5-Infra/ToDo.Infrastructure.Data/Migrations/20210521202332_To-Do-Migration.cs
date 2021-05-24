using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ToDo.Infrastructure.Data.Migrations
{
    public partial class ToDoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    Bairro = table.Column<string>(type: "text", nullable: true),
                    Logradouro = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Complemento = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: true),
                    Cidade = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genero",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pessoa",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    EnderecoId = table.Column<int>(type: "integer", nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoa", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoa_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InstituicaoEnsino",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaId = table.Column<int>(type: "integer", nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstituicaoEnsino", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstituicaoEnsino_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaId = table.Column<int>(type: "integer", nullable: true),
                    Senha = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PessoaId = table.Column<int>(type: "integer", nullable: true),
                    InstituicaoEnsinoId = table.Column<int>(type: "integer", nullable: true),
                    Cpf = table.Column<string>(type: "text", nullable: true),
                    Situacao = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cliente_InstituicaoEnsino_InstituicaoEnsinoId",
                        column: x => x.InstituicaoEnsinoId,
                        principalTable: "InstituicaoEnsino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cliente_Pessoa_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClienteBloqueio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    Situacao = table.Column<int>(type: "integer", nullable: false, defaultValue: 2),
                    BloqueadoAte = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValue: new DateTime(2021, 6, 20, 16, 23, 31, 759, DateTimeKind.Local).AddTicks(5063))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteBloqueio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClienteBloqueio_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    DataInicio = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 5, 21, 16, 23, 31, 763, DateTimeKind.Local).AddTicks(645)),
                    DataDevolucao = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValue: new DateTime(2021, 6, 20, 16, 23, 31, 763, DateTimeKind.Local).AddTicks(1554)),
                    Situacao = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LivroReserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClienteId = table.Column<int>(type: "integer", nullable: true),
                    Reservado = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroReserva", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroReserva_Cliente_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Titulo = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    GeneroId = table.Column<int>(type: "integer", nullable: true),
                    Autor = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Sinopse = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    ImagemCapa = table.Column<byte[]>(type: "bytea", nullable: true),
                    Disponivel = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    LivroReservaId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Genero_GeneroId",
                        column: x => x.GeneroId,
                        principalTable: "Genero",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livro_LivroReserva_LivroReservaId",
                        column: x => x.LivroReservaId,
                        principalTable: "LivroReserva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LivroEmprestimo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LivroId = table.Column<int>(type: "integer", nullable: true),
                    Pendente = table.Column<bool>(type: "boolean", nullable: false),
                    EmprestimoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LivroEmprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Emprestimo_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LivroEmprestimo_Livro_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_InstituicaoEnsinoId",
                table: "Cliente",
                column: "InstituicaoEnsinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_PessoaId",
                table: "Cliente",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClienteBloqueio_ClienteId",
                table: "ClienteBloqueio",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ClienteId",
                table: "Emprestimo",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_InstituicaoEnsino_PessoaId",
                table: "InstituicaoEnsino",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_GeneroId",
                table: "Livro",
                column: "GeneroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_LivroReservaId",
                table: "Livro",
                column: "LivroReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestimo_EmprestimoId",
                table: "LivroEmprestimo",
                column: "EmprestimoId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroEmprestimo_LivroId",
                table: "LivroEmprestimo",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_LivroReserva_ClienteId",
                table: "LivroReserva",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoa_EnderecoId",
                table: "Pessoa",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PessoaId",
                table: "Usuario",
                column: "PessoaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteBloqueio");

            migrationBuilder.DropTable(
                name: "LivroEmprestimo");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Genero");

            migrationBuilder.DropTable(
                name: "LivroReserva");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "InstituicaoEnsino");

            migrationBuilder.DropTable(
                name: "Pessoa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
