using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Milestone1.Migrations
{
    public partial class cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartItem",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    itemMerchid = table.Column<int>(nullable: true),
                    price = table.Column<long>(nullable: false),
                    CartID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItem", x => x.id);
                    table.ForeignKey(
                        name: "FK_CartItem_Merch_itemMerchid",
                        column: x => x.itemMerchid,
                        principalTable: "Merch",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_itemMerchid",
                table: "CartItem",
                column: "itemMerchid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItem");
        }
    }
}
