using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Utenti_DocumentiUtenti_idDocumento",
                table: "Utenti");

            migrationBuilder.DropIndex(
                name: "IX_Utenti_idDocumento",
                table: "Utenti");

            migrationBuilder.DropColumn(
                name: "idDocumento",
                table: "Utenti");

            migrationBuilder.AddColumn<int>(
                name: "idUtente",
                table: "DocumentiUtenti",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DocumentiUtenti_idUtente",
                table: "DocumentiUtenti",
                column: "idUtente",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DocumentiUtenti_Utenti_idUtente",
                table: "DocumentiUtenti",
                column: "idUtente",
                principalTable: "Utenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DocumentiUtenti_Utenti_idUtente",
                table: "DocumentiUtenti");

            migrationBuilder.DropIndex(
                name: "IX_DocumentiUtenti_idUtente",
                table: "DocumentiUtenti");

            migrationBuilder.DropColumn(
                name: "idUtente",
                table: "DocumentiUtenti");

            migrationBuilder.AddColumn<int>(
                name: "idDocumento",
                table: "Utenti",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Utenti_idDocumento",
                table: "Utenti",
                column: "idDocumento",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Utenti_DocumentiUtenti_idDocumento",
                table: "Utenti",
                column: "idDocumento",
                principalTable: "DocumentiUtenti",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
