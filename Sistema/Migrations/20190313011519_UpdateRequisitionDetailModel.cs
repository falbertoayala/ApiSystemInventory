using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class UpdateRequisitionDetailModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionDetail_Requisition_RequisitionId",
                table: "RequisitionDetail");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionId",
                table: "RequisitionDetail",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionDetail_Requisition_RequisitionId",
                table: "RequisitionDetail",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitionDetail_Requisition_RequisitionId",
                table: "RequisitionDetail");

            migrationBuilder.AlterColumn<int>(
                name: "RequisitionId",
                table: "RequisitionDetail",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitionDetail_Requisition_RequisitionId",
                table: "RequisitionDetail",
                column: "RequisitionId",
                principalTable: "Requisition",
                principalColumn: "RequisitionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
