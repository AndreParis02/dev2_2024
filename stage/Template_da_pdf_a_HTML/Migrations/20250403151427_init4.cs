using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti");

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti",
                column: "LibroId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti");

            migrationBuilder.CreateIndex(
                name: "IX_Prestiti_LibroId",
                table: "Prestiti",
                column: "LibroId",
                unique: true);
        }
    }
}
