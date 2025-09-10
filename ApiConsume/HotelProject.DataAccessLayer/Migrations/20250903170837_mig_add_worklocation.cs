using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelProject.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_worklocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkDepartment",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "WorkLocationId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorkLocations",
                columns: table => new
                {
                    WorkLocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkLocationName = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkLocations", x => x.WorkLocationId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers",
                column: "WorkLocationId",
                principalTable: "WorkLocations",
                principalColumn: "WorkLocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_WorkLocations_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WorkLocations");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_WorkLocationId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkDepartment",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WorkLocationId",
                table: "AspNetUsers");
        }
    }
}
