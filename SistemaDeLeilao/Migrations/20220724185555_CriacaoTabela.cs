using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeLeilao.Migrations
{
    public partial class CriacaoTabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Perfil = table.Column<int>(type: "int", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Embarcadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Embarcadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Embarcadores_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transportadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportadores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportadores_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    EmbarcadoresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Embarcadores_EmbarcadoresId",
                        column: x => x.EmbarcadoresId,
                        principalTable: "Embarcadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Funcionarios_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmbarcadoresModelTransportadorModel",
                columns: table => new
                {
                    EmbarcadoresId = table.Column<int>(type: "int", nullable: false),
                    TransportadorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmbarcadoresModelTransportadorModel", x => new { x.EmbarcadoresId, x.TransportadorId });
                    table.ForeignKey(
                        name: "FK_EmbarcadoresModelTransportadorModel_Embarcadores_EmbarcadoresId",
                        column: x => x.EmbarcadoresId,
                        principalTable: "Embarcadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmbarcadoresModelTransportadorModel_Transportadores_TransportadorId",
                        column: x => x.TransportadorId,
                        principalTable: "Transportadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeOferta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoColeta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnderecoEntrega = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    EmbarcadoresId = table.Column<int>(type: "int", nullable: true),
                    FuncionarioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Oferta_Embarcadores_EmbarcadoresId",
                        column: x => x.EmbarcadoresId,
                        principalTable: "Embarcadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Oferta_Funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<double>(type: "float", nullable: false),
                    TransportadorId = table.Column<int>(type: "int", nullable: true),
                    OfertaId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Lance_Oferta_OfertaId",
                        column: x => x.OfertaId,
                        principalTable: "Oferta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lance_Transportadores_TransportadorId",
                        column: x => x.TransportadorId,
                        principalTable: "Transportadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Embarcadores_UsuarioId",
                table: "Embarcadores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_EmbarcadoresModelTransportadorModel_TransportadorId",
                table: "EmbarcadoresModelTransportadorModel",
                column: "TransportadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_EmbarcadoresId",
                table: "Funcionarios",
                column: "EmbarcadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_UsuarioId",
                table: "Funcionarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_OfertaId",
                table: "Lance",
                column: "OfertaId");

            migrationBuilder.CreateIndex(
                name: "IX_Lance_TransportadorId",
                table: "Lance",
                column: "TransportadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_EmbarcadoresId",
                table: "Oferta",
                column: "EmbarcadoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_FuncionarioId",
                table: "Oferta",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportadores_UsuarioId",
                table: "Transportadores",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmbarcadoresModelTransportadorModel");

            migrationBuilder.DropTable(
                name: "Lance");

            migrationBuilder.DropTable(
                name: "Oferta");

            migrationBuilder.DropTable(
                name: "Transportadores");

            migrationBuilder.DropTable(
                name: "Funcionarios");

            migrationBuilder.DropTable(
                name: "Embarcadores");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
