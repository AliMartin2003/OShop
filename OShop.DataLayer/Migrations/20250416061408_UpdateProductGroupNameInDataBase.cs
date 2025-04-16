using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OShop.DataLayer.Migrations
{
    public partial class UpdateProductGroupNameInDataBase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProducGrouptName",
                table: "ProductGroups",
                newName: "ProductGroupName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductGroupName",
                table: "ProductGroups",
                newName: "ProducGrouptName");
        }
    }
}
