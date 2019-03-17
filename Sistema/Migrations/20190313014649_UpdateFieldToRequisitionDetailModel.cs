using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class UpdateFieldToRequisitionDetailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_RequisitionStatus_RequisitionStatusId",
                table: "Requisition");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionStatusId",
                table: "Requisition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionDetailId",
                table: "Requisition",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_RequisitionStatus_RequisitionStatusId",
                table: "Requisition",
                column: "RequisitionStatusId",
                principalTable: "RequisitionStatus",
                principalColumn: "RequisitionStatusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Requisition_RequisitionStatus_RequisitionStatusId",
                table: "Requisition");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionStatusId",
                table: "Requisition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionDetailId",
                table: "Requisition",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Requisition_RequisitionStatus_RequisitionStatusId",
                table: "Requisition",
                column: "RequisitionStatusId",
                principalTable: "RequisitionStatus",
                principalColumn: "RequisitionStatusId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
