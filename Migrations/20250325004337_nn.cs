using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMDB.Migrations
{
    /// <inheritdoc />
    public partial class nn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medias_MediaType_MediaTypeId",
                table: "medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MediaType",
                table: "MediaType");

            migrationBuilder.RenameTable(
                name: "MediaType",
                newName: "mediaTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_mediaTypes",
                table: "mediaTypes",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_medias_mediaTypes_MediaTypeId",
                table: "medias",
                column: "MediaTypeId",
                principalTable: "mediaTypes",
                principalColumn: "MediaTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_medias_mediaTypes_MediaTypeId",
                table: "medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_mediaTypes",
                table: "mediaTypes");

            migrationBuilder.RenameTable(
                name: "mediaTypes",
                newName: "MediaType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MediaType",
                table: "MediaType",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_medias_MediaType_MediaTypeId",
                table: "medias",
                column: "MediaTypeId",
                principalTable: "MediaType",
                principalColumn: "MediaTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
