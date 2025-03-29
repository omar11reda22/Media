using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMDB.Migrations
{
    /// <inheritdoc />
    public partial class l : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "Rating",
                table: "medias",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 1,
                column: "Rating",
                value: 9f);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 2,
                column: "Rating",
                value: 10f);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 3,
                column: "Rating",
                value: 10f);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 4,
                column: "Rating",
                value: 9f);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 5,
                column: "Rating",
                value: 10f);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 6,
                column: "Rating",
                value: 9f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "medias",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 1,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 2,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 3,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 4,
                column: "Rating",
                value: 9);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 5,
                column: "Rating",
                value: 10);

            migrationBuilder.UpdateData(
                table: "medias",
                keyColumn: "MediaId",
                keyValue: 6,
                column: "Rating",
                value: 9);
        }
    }
}
