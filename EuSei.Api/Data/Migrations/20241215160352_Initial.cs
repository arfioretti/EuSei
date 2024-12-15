using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EuSei.Api.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nmae = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsAproved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalMinutos = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questionario_Categorys_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categorys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questionario_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perguntas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    QuestionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Perguntas_Questionario_QuestionarioId",
                        column: x => x.QuestionarioId,
                        principalTable: "Questionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentQuestionarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Inicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Termino = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Acertos = table.Column<int>(type: "int", nullable: false),
                    QuestionarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentQuestionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentQuestionarios_Questionario_QuestionarioId",
                        column: x => x.QuestionarioId,
                        principalTable: "Questionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opcaos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    PerguntaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcaos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcaos_Perguntas_PerguntaId",
                        column: x => x.PerguntaId,
                        principalTable: "Perguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "IsAproved", "Nmae", "PasswordHash", "Phone", "Role" },
                values: new object[] { 1, "arfioretti@gmail.com", true, "Aristides", "AQAAAAIAAYagAAAAELqE+CGl50Fy4DAmViEDLn6+iX8K6yEc+z9x8DK2nsjbDgpvbXIvgvrUpgcsqWNrgw==", "21988575367", "Admin" });

            migrationBuilder.CreateIndex(
                name: "IX_Opcaos_PerguntaId",
                table: "Opcaos",
                column: "PerguntaId");

            migrationBuilder.CreateIndex(
                name: "IX_Perguntas_QuestionarioId",
                table: "Perguntas",
                column: "QuestionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionario_CategoryId",
                table: "Questionario",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionario_UserId",
                table: "Questionario",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentQuestionarios_QuestionarioId",
                table: "StudentQuestionarios",
                column: "QuestionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opcaos");

            migrationBuilder.DropTable(
                name: "StudentQuestionarios");

            migrationBuilder.DropTable(
                name: "Perguntas");

            migrationBuilder.DropTable(
                name: "Questionario");

            migrationBuilder.DropTable(
                name: "Categorys");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
