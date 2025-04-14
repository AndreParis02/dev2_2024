using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestiti_Libri_LibroId",
                table: "Prestiti");

            migrationBuilder.DropIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Prestiti");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Prestiti",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestiti_Libri_LibroId",
                table: "Prestiti",
                column: "LibroId",
                principalTable: "Libri",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
