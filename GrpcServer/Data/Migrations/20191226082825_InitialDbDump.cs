using Microsoft.EntityFrameworkCore.Migrations;

namespace GrpcServer.Migrations
{
    public partial class InitialDbDump : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TransactionEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    TransactionId = table.Column<long>(nullable: false),
                    CustomerName = table.Column<string>(nullable: true),
                    TransactionType = table.Column<string>(nullable: true),
                    TransactionAmount = table.Column<int>(nullable: false),
                    TerminatingBank = table.Column<string>(nullable: true),
                    IssuingBank = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TransactionEntity");
        }
    }
}
