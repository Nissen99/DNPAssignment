using Microsoft.EntityFrameworkCore.Migrations;

namespace AssignmentDataServer.Migrations
{
    public partial class _2_MoveModelsAndDataToShared : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "Jobs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "InterestId",
                table: "Interests",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jobs",
                newName: "JobId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interests",
                newName: "InterestId");
        }
    }
}
