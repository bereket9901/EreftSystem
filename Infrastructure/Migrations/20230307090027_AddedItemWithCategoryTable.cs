using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedItemWithCategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemWithCategory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    ItemCategoryId = table.Column<int>(type: "integer", nullable: false),
                    CreateDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ModifiedDateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemWithCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemWithCategory_ItemCategory_ItemCategoryId",
                        column: x => x.ItemCategoryId,
                        principalTable: "ItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemWithCategory_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemWithCategory_ItemCategoryId",
                table: "ItemWithCategory",
                column: "ItemCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemWithCategory_ItemId",
                table: "ItemWithCategory",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemWithCategory");
        }
    }
}
