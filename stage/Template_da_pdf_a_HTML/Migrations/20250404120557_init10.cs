using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template_da_pdf_a_HTML.Migrations
{
    /// <inheritdoc />
    public partial class init10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Generi_idGenere",
                table: "Libri");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenzaPrestito",
                table: "Prestiti",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "idGenere",
                table: "Libri",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Generi_idGenere",
                table: "Libri",
                column: "idGenere",
                principalTable: "Generi",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libri_Generi_idGenere",
                table: "Libri");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataScadenzaPrestito",
                table: "Prestiti",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<int>(
                name: "idGenere",
                table: "Libri",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Libri_Generi_idGenere",
                table: "Libri",
                column: "idGenere",
                principalTable: "Generi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
