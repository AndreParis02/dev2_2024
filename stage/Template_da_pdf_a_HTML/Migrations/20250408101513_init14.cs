using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Autori_idAutore",
                table: "Libri");

            migrationBuilder.AlterColumn<int>(
                name: "idAutore",
                table: "Libri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Autori_idAutore",
                table: "Libri",
                column: "idAutore",
                principalTable: "Autori",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Autori_idAutore",
                table: "Libri");

            migrationBuilder.AlterColumn<int>(
                name: "idAutore",
                table: "Libri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Autori_idAutore",
                table: "Libri",
                column: "idAutore",
                principalTable: "Autori",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
