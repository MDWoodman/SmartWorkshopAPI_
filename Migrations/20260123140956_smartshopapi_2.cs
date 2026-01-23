using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWorkshopAPI.Migrations
{
    /// <inheritdoc />
    public partial class smartshopapi_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProcessStrategy",
                table: "Orders",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProcessStrategy",
                table: "Orders");
        }
    }
}
