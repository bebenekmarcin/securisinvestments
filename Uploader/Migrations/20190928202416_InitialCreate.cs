using Microsoft.EntityFrameworkCore.Migrations;

namespace Uploader.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Investments",
                columns: table => new
                {
                    InvestmentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fund = table.Column<string>(nullable: true),
                    Value = table.Column<long>(nullable: false),
                    Collateral = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investments", x => x.InvestmentId);
                });

            migrationBuilder.CreateTable(
                name: "InvestmentTotals",
                columns: table => new
                {
                    InvestmentTotalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueTotal = table.Column<long>(nullable: false),
                    CollateralTotal = table.Column<long>(nullable: false),
                    NetTotal = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvestmentTotals", x => x.InvestmentTotalId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Investments");

            migrationBuilder.DropTable(
                name: "InvestmentTotals");
        }
    }
}
