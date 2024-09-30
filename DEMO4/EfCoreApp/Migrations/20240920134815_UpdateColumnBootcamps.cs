using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EfCoreApp.Migrations
{
    /// <inheritdoc />
    public partial class UpdateColumnBootcamps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Kayitlar_BootcampId",
                table: "Kayitlar",
                column: "BootcampId");

            migrationBuilder.CreateIndex(
                name: "IX_Kayitlar_OgrenciId",
                table: "Kayitlar",
                column: "OgrenciId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kayitlar_Bootcamps_BootcampId",
                table: "Kayitlar",
                column: "BootcampId",
                principalTable: "Bootcamps",
                principalColumn: "BootcampId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Kayitlar_Ogrenciler_OgrenciId",
                table: "Kayitlar",
                column: "OgrenciId",
                principalTable: "Ogrenciler",
                principalColumn: "OgrenciId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kayitlar_Bootcamps_BootcampId",
                table: "Kayitlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Kayitlar_Ogrenciler_OgrenciId",
                table: "Kayitlar");

            migrationBuilder.DropIndex(
                name: "IX_Kayitlar_BootcampId",
                table: "Kayitlar");

            migrationBuilder.DropIndex(
                name: "IX_Kayitlar_OgrenciId",
                table: "Kayitlar");
        }
    }
}
