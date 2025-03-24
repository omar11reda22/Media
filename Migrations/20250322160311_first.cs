using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IMDB.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    Actor_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.Actor_ID);
                });

            migrationBuilder.CreateTable(
                name: "directors",
                columns: table => new
                {
                    Director_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BIO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: false),
                    nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directors", x => x.Director_ID);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    Genre_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.Genre_ID);
                });

            migrationBuilder.CreateTable(
                name: "MediaType",
                columns: table => new
                {
                    MediaTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MediaType", x => x.MediaTypeId);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "medias",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    Poster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false),
                    TrailerURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MediaTypeId = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: true),
                    Episodes = table.Column<int>(type: "int", nullable: true),
                    Seasons = table.Column<int>(type: "int", nullable: true),
                    Studio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DirectorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_medias", x => x.MediaId);
                    table.ForeignKey(
                        name: "FK_medias_MediaType_MediaTypeId",
                        column: x => x.MediaTypeId,
                        principalTable: "MediaType",
                        principalColumn: "MediaTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_medias_directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "directors",
                        principalColumn: "Director_ID");
                });

            migrationBuilder.CreateTable(
                name: "watchlists",
                columns: table => new
                {
                    WatchlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_watchlists", x => x.WatchlistId);
                    table.ForeignKey(
                        name: "FK_watchlists_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movie_Actors",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    ActorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movie_Actors", x => new { x.MediaId, x.ActorId });
                    table.ForeignKey(
                        name: "FK_Movie_Actors_actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "actors",
                        principalColumn: "Actor_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movie_Actors_medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movie_Genres",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movie_Genres", x => new { x.MediaId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_movie_Genres_genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "genres",
                        principalColumn: "Genre_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movie_Genres_medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    MediaId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    ReviewText = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => new { x.MediaId, x.UserId });
                    table.ForeignKey(
                        name: "FK_reviews_medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "movieWatchlists",
                columns: table => new
                {
                    WatchlistId = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movieWatchlists", x => new { x.MediaId, x.WatchlistId });
                    table.ForeignKey(
                        name: "FK_movieWatchlists_medias_MediaId",
                        column: x => x.MediaId,
                        principalTable: "medias",
                        principalColumn: "MediaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_movieWatchlists_watchlists_WatchlistId",
                        column: x => x.WatchlistId,
                        principalTable: "watchlists",
                        principalColumn: "WatchlistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MediaType",
                columns: new[] { "MediaTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Movie" },
                    { 2, "Anime" },
                    { 3, "Series" }
                });

            migrationBuilder.InsertData(
                table: "actors",
                columns: new[] { "Actor_ID", "BIO", "Name", "image", "nationality" },
                values: new object[,]
                {
                    { 1, "An award-winning American actor known for Inception and Titanic.", "Leonardo DiCaprio", "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Leonardo_DiCaprio_2014.jpg/800px-Leonardo_DiCaprio_2014.jpg", "American" },
                    { 2, "Famous for his role as Batman in The Dark Knight Trilogy.", "Christian Bale", "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Christian_Bale_2019.jpg/800px-Christian_Bale_2019.jpg", "British" },
                    { 3, "Best known for Breaking Bad.", "Bryan Cranston", "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Bryan_Cranston_by_Gage_Skidmore_2.jpg/800px-Bryan_Cranston_by_Gage_Skidmore_2.jpg", "American" },
                    { 4, "Famous for playing Daenerys Targaryen in Game of Thrones.", "Emilia Clarke", "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Emilia_Clarke_by_Gage_Skidmore.jpg/800px-Emilia_Clarke_by_Gage_Skidmore.jpg", "British" },
                    { 5, "Japanese voice actor known for voicing Eren Yeager in Attack on Titan.", "Yuki Kaji", "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Yuki_Kaji_Anime_Expo_2018.jpg/800px-Yuki_Kaji_Anime_Expo_2018.jpg", "Japanese" },
                    { 6, "Japanese voice actress known for Asuna in Sword Art Online.", "Haruka Tomatsu", "https://upload.wikimedia.org/wikipedia/commons/3/3a/Haruka_Tomatsu_Anime_Expo_2018.jpg", "Japanese" }
                });

            migrationBuilder.InsertData(
                table: "directors",
                columns: new[] { "Director_ID", "BIO", "Name", "birthdate", "image", "nationality" },
                values: new object[,]
                {
                    { 1, "Renowned for his complex storytelling and innovative cinematography.", "Christopher Nolan", new DateOnly(1970, 7, 30), "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Christopher_Nolan_Cannes_2018.jpg/800px-Christopher_Nolan_Cannes_2018.jpg", "British-American" },
                    { 2, "Known for his nonlinear storytelling and stylized violence.", "Quentin Tarantino", new DateOnly(1963, 3, 27), "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Quentin_Tarantino_by_Gage_Skidmore.jpg/800px-Quentin_Tarantino_by_Gage_Skidmore.jpg", "American" },
                    { 3, "Legendary Japanese animator and co-founder of Studio Ghibli.", "Hayao Miyazaki", new DateOnly(1941, 1, 5), "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/Hayao_Miyazaki_cropped_1_Hayao_Miyazaki_201211.jpg/800px-Hayao_Miyazaki_cropped_1_Hayao_Miyazaki_201211.jpg", "Japanese" },
                    { 4, "Famous for Cowboy Bebop and Samurai Champloo.", "Shinichiro Watanabe", new DateOnly(1965, 5, 24), "https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Shinichiro_Watanabe_at_Anime_Expo_2016.jpg/800px-Shinichiro_Watanabe_at_Anime_Expo_2016.jpg", "Japanese" }
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "Genre_ID", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Adventure" },
                    { 3, "Drama" },
                    { 4, "Fantasy" },
                    { 5, "Sci-Fi" },
                    { 6, "Thriller" },
                    { 7, "Mystery" },
                    { 8, "Crime" },
                    { 9, "Romance" },
                    { 10, "Animation" }
                });

            migrationBuilder.InsertData(
                table: "medias",
                columns: new[] { "MediaId", "Description", "DirectorId", "Duration", "Episodes", "MediaTypeId", "Poster", "Rating", "ReleaseDate", "Seasons", "Studio", "Title", "TrailerURL", "Year" },
                values: new object[,]
                {
                    { 1, "A thief with the ability to enter people's dreams takes on the heist of his life.", 1, 148, null, 1, "https://m.media-amazon.com/images/I/51NBpSY0NHL._AC_.jpg", 9, new DateOnly(2010, 7, 16), null, null, "Inception", "https://www.youtube.com/watch?v=YoHD9XEInc0", 2010 },
                    { 2, "Batman faces off against his greatest enemy, the Joker, in a battle for Gotham's soul.", 1, 152, null, 1, "https://m.media-amazon.com/images/I/51EbJvl8gJL._AC_.jpg", 10, new DateOnly(2008, 7, 18), null, null, "The Dark Knight", "https://www.youtube.com/watch?v=EXeTwQWrcwY", 2008 },
                    { 3, "In a world where titans eat humans, a group of soldiers fight for survival.", null, null, 75, 2, "https://m.media-amazon.com/images/I/81ETPpG5dZL._AC_SL1500_.jpg", 10, new DateOnly(2013, 4, 7), 4, "Wit Studio", "Attack on Titan", "https://www.youtube.com/watch?v=MGRm4IzK1SQ", 2013 },
                    { 4, "Two strangers find themselves mysteriously connected despite never having met.", null, null, 1, 2, "https://m.media-amazon.com/images/I/91zno84lrzL._AC_SY679_.jpg", 9, new DateOnly(2016, 8, 26), null, "CoMix Wave Films", "Naruto", "https://www.youtube.com/watch?v=xU47nhruN-Q", 2016 },
                    { 5, "A high school chemistry teacher turned drug kingpin struggles to balance his new life.", null, null, null, 3, "https://m.media-amazon.com/images/I/81eNnLuUuPL._AC_SL1500_.jpg", 10, new DateOnly(2008, 1, 20), 5, null, "Breaking Bad", "https://www.youtube.com/watch?v=HhesaQXLuRY", 2008 },
                    { 6, "Noble families vie for control of the Iron Throne in the land of Westeros.", null, null, null, 3, "https://m.media-amazon.com/images/I/91YwZl3T52L._AC_SL1500_.jpg", 9, new DateOnly(2011, 4, 17), 8, null, "Game of Thrones", "https://www.youtube.com/watch?v=KPLWWIOCOOQ", 2011 }
                });

            migrationBuilder.InsertData(
                table: "Movie_Actors",
                columns: new[] { "ActorId", "MediaId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 5, 3 },
                    { 6, 4 },
                    { 3, 5 },
                    { 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "movie_Genres",
                columns: new[] { "GenreId", "MediaId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 6, 2 },
                    { 1, 3 },
                    { 9, 4 },
                    { 8, 5 },
                    { 4, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_medias_DirectorId",
                table: "medias",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_medias_MediaTypeId",
                table: "medias",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_Actors_ActorId",
                table: "Movie_Actors",
                column: "ActorId");

            migrationBuilder.CreateIndex(
                name: "IX_movie_Genres_GenreId",
                table: "movie_Genres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_movieWatchlists_WatchlistId",
                table: "movieWatchlists",
                column: "WatchlistId");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_UserId",
                table: "reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_watchlists_UserId",
                table: "watchlists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movie_Actors");

            migrationBuilder.DropTable(
                name: "movie_Genres");

            migrationBuilder.DropTable(
                name: "movieWatchlists");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.DropTable(
                name: "actors");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "watchlists");

            migrationBuilder.DropTable(
                name: "medias");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "MediaType");

            migrationBuilder.DropTable(
                name: "directors");
        }
    }
}
