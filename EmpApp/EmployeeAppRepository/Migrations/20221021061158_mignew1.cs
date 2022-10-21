using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeAppRepository.Migrations
{
    public partial class mignew1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_NewDetails",
                table: "NewDetails");

            migrationBuilder.RenameTable(
                name: "NewDetails",
                newName: "Details");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Details",
                table: "Details",
                column: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Details",
                table: "Details");

            migrationBuilder.RenameTable(
                name: "Details",
                newName: "NewDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NewDetails",
                table: "NewDetails",
                column: "UserName");
        }
    }
}
