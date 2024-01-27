using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ViewMovieData.Model.Migrations
{
    /// <inheritdoc />
    public partial class Initiate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsOutNow = table.Column<bool>(type: "bit", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    VideoTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Movies_VideoTypes_VideoTypeId",
                        column: x => x.VideoTypeId,
                        principalTable: "VideoTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Animation" },
                    { 4, "Biography" },
                    { 5, "Comedy" },
                    { 6, "Crime" },
                    { 7, "Documentary" },
                    { 8, "Drama" },
                    { 9, "Family" },
                    { 10, "Fantasy" },
                    { 11, "Film-Noir" },
                    { 12, "History" },
                    { 13, "Horror" },
                    { 14, "Musical" },
                    { 15, "Mystery" },
                    { 16, "Romance" },
                    { 17, "Sci-Fi" },
                    { 18, "Sport" },
                    { 19, "Thriller" },
                    { 20, "War" },
                    { 21, "Western" }
                });

            migrationBuilder.InsertData(
                table: "VideoTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Feature Film" },
                    { 2, "Short Film" },
                    { 3, "Documentary" },
                    { 4, "Animated Film" },
                    { 5, "Experimental Film" },
                    { 6, "Commercial" },
                    { 7, "Music Video" },
                    { 8, "Educational Film" },
                    { 9, "TV Show" },
                    { 10, "Web Series" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "GenreId", "IsOutNow", "Name", "ProductionDate", "VideoTypeId" },
                values: new object[,]
                {
                    { 1, 1, true, "Movie 1", new DateOnly(2022, 1, 1), 1 },
                    { 2, 2, false, "Movie 2", new DateOnly(2023, 2, 2), 2 },
                    { 3, 3, true, "Movie 3", new DateOnly(2024, 3, 3), 3 },
                    { 4, 4, false, "Movie 4", new DateOnly(2022, 1, 4), 4 },
                    { 5, 5, true, "Movie 5", new DateOnly(2022, 1, 5), 5 },
                    { 6, 1, false, "Movie 6", new DateOnly(2022, 1, 6), 1 },
                    { 7, 2, true, "Movie 7", new DateOnly(2022, 1, 7), 2 },
                    { 8, 3, false, "Movie 8", new DateOnly(2022, 1, 8), 3 },
                    { 9, 4, true, "Movie 9", new DateOnly(2022, 1, 9), 4 },
                    { 10, 5, false, "Movie 10", new DateOnly(2022, 1, 10), 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_VideoTypeId",
                table: "Movies",
                column: "VideoTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "VideoTypes");
        }
    }
}
