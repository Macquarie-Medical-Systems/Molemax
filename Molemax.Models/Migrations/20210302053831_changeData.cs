using Microsoft.EntityFrameworkCore.Migrations;

namespace Molemax.Models.Migrations
{
    public partial class changeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DEFAllSkin",
                keyColumn: "CategoryOrImageId",
                keyValue: "pending");

            migrationBuilder.InsertData(
                table: "DEFAllSkin",
                columns: new[] { "CategoryOrImageId", "Category", "Description", "DiseaseName", "ImageId", "IsFirstLevelCategory", "ParentCategoryId" },
                values: new object[] { "DISEASE0", null, null, "Diagnosis Pending", null, -1, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DEFAllSkin",
                keyColumn: "CategoryOrImageId",
                keyValue: "DISEASE0");

            migrationBuilder.InsertData(
                table: "DEFAllSkin",
                columns: new[] { "CategoryOrImageId", "Category", "Description", "DiseaseName", "ImageId", "IsFirstLevelCategory", "ParentCategoryId" },
                values: new object[] { "pending", null, null, "Diagnosis Pending", null, -1, null });
        }
    }
}
