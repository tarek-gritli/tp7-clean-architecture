using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tp7.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerReviewsRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "MovieReviews",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000")
            );

            migrationBuilder.CreateIndex(
                name: "IX_MovieReviews_CustomerId",
                table: "MovieReviews",
                column: "CustomerId"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_MovieReviews_Customers_CustomerId",
                table: "MovieReviews",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieReviews_Customers_CustomerId",
                table: "MovieReviews"
            );

            migrationBuilder.DropIndex(name: "IX_MovieReviews_CustomerId", table: "MovieReviews");

            migrationBuilder.DropColumn(name: "CustomerId", table: "MovieReviews");
        }
    }
}
