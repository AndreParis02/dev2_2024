using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascita = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataMorte = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Generi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Richiesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Cognome = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Oggetto = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Messaggio = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Data_inserimento = table.Column<string>(type: "TEXT", nullable: true),
                    Cancellato = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Richiesta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titolo = table.Column<string>(type: "TEXT", nullable: true),
                    AnnoUscita = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataInserimento = table.Column<string>(type: "TEXT", nullable: true),
                    DataModifica = table.Column<string>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false),
                    Disponibile = table.Column<bool>(type: "INTEGER", nullable: false),
                    idGenere = table.Column<int>(type: "INTEGER", nullable: false),
                    idAutore = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Libri_Autori_idAutore",
                        column: x => x.idAutore,
                        principalTable: "Autori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Libri_Generi_idGenere",
                        column: x => x.idGenere,
                        principalTable: "Generi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentiUtenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Numero = table.Column<string>(type: "TEXT", nullable: true),
                    Scadenza = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataInserimento = table.Column<string>(type: "TEXT", nullable: true),
                    DataModifica = table.Column<string>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false),
                    idTipo = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentiUtenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentiUtenti_Tipi_idTipo",
                        column: x => x.idTipo,
                        principalTable: "Tipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Cognome = table.Column<string>(type: "TEXT", nullable: true),
                    DataNascita = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    DataInserimento = table.Column<string>(type: "TEXT", nullable: true),
                    DataModifica = table.Column<string>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false),
                    idDocumento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Utenti_DocumentiUtenti_idDocumento",
                        column: x => x.idDocumento,
                        principalTable: "DocumentiUtenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestiti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataInizioPrestito = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataScadenzaPrestito = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataInserimento = table.Column<string>(type: "TEXT", nullable: true),
                    DataModifica = table.Column<string>(type: "TEXT", nullable: true),
                    Eliminato = table.Column<bool>(type: "INTEGER", nullable: false),
                    UtenteId = table.Column<int>(type: "INTEGER", nullable: false),
                    LibroId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestiti", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prestiti_Libri_LibroId",
                        column: x => x.LibroId,
                        principalTable: "Libri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prestiti_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DocumentiUtenti_idTipo",
                table: "DocumentiUtenti",
                column: "idTipo");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_idAutore",
                table: "Libri",
                column: "idAutore");

            migrationBuilder.CreateIndex(
                name: "IX_Libri_idGenere",
                table: "Libri",
                column: "idGenere");

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti",
                column: "LibroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_UtenteId",
                table: "Prestiti",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_idDocumento",
                table: "Utenti",
                column: "idDocumento",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prestiti");

            migrationBuilder.DropTable(
                name: "Richiesta");

            migrationBuilder.DropTable(
                name: "Libri");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Autori");

            migrationBuilder.DropTable(
                name: "Generi");

            migrationBuilder.DropTable(
                name: "DocumentiUtenti");

            migrationBuilder.DropTable(
                name: "Tipi");
        }
    }
}
