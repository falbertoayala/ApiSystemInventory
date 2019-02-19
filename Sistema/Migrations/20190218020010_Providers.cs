using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sistema.Migrations
{
    public partial class Providers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProvidersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProviderName = table.Column<string>(maxLength: 100, nullable: false),
                    ProviderRtn = table.Column<string>(maxLength: 14, nullable: false),
                    ProviderPhone1 = table.Column<string>(maxLength: 8, nullable: false),
                    ProviderPhone2 = table.Column<string>(nullable: true),
                    ProviderEmail = table.Column<string>(maxLength: 100, nullable: false),
                    ProviderContact = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProvidersId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Providers");
        }
    }
}
