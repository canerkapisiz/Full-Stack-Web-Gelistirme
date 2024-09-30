using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTableEgitmen : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EgitmenId",
                table: "Bootcamps",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Egitmenler",
                columns: table => new
                {
                    EgitmenId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EgitmenAd = table.Column<string>(type: "TEXT", nullable: true),
                    EgitmenSoyad = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Eposta = table.Column<string>(type: "TEXT", nullable: true),
                    Telefon = table.Column<string>(type: "TEXT", nullable: true),
                    BaslamaTarihi = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Egitmenler", x => x.EgitmenId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bootcamps_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps",
                column: "EgitmenId",
                principalTable: "Egitmenler",
                principalColumn: "EgitmenId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bootcamps_Egitmenler_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.DropTable(
                name: "Egitmenler");

            migrationBuilder.DropIndex(
                name: "IX_Bootcamps_EgitmenId",
                table: "Bootcamps");

            migrationBuilder.DropColumn(
                name: "EgitmenId",
                table: "Bootcamps");
        }
    }
}
