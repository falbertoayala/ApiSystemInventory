using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class UpdateFieldToRequisitionStatusModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RequisitionDetail",
                table: "RequisitionStatus",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "RequisitionStatus",
                newName: "RequisitionDetail");
        }
    }
}
