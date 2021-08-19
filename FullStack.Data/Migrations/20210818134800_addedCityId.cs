using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStack.Data.Migrations
{
    public partial class addedCityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Provinces_ProvinceId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Cities_CityId",
                table: "Adverts",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adverts_Cities_CityId",
                table: "Adverts");

            migrationBuilder.DropIndex(
                name: "IX_Adverts_CityId",
                table: "Adverts");

            migrationBuilder.CreateIndex(
                name: "IX_Adverts_ProvinceId",
                table: "Adverts",
                column: "ProvinceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adverts_Provinces_ProvinceId",
                table: "Adverts",
                column: "ProvinceId",
                principalTable: "Provinces",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
