using IMDB.Configurations;
using IMDB.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace IMDB.MyContext
{
    public class Applicationcontext:DbContext
    {
        public Applicationcontext() { }

        public Applicationcontext(DbContextOptions options):base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // passing configurations classes 

            modelBuilder.ApplyConfiguration(new MediaConfigurations());

            // set Composite PK to some entoties 
            /*
             [movie actor]
            [movie genre]
            [movie watchlist]
            
             
             */
            modelBuilder.Entity<Media>()
        .HasOne(m => m.MediaType)
        .WithMany(mt => mt.Media)
        .HasForeignKey(m => m.MediaTypeId);

            modelBuilder.Entity<Media_Actors>()
                .HasKey(s => new { s.MediaId , s.ActorId });

            modelBuilder.Entity<Media_Genre>()
                .HasKey(s => new { s.MediaId, s.GenreId });
            modelBuilder.Entity<MediaWatchlist>()
                .HasKey(s => new { s.MediaId, s.WatchlistId });
            modelBuilder.Entity<Review>()
                .HasKey(s => new { s.MediaId, s.UserId });

            modelBuilder.Entity<MediaWatchlist>()
              .HasOne(mw => mw.Watchlist)
              .WithMany(w => w.mediaWatchlists)
              .HasForeignKey(mw => mw.WatchlistId);


            modelBuilder.Entity<Review>()
             .HasOne(r => r.User)
             .WithMany(u => u.reviews)
             .HasForeignKey(r => r.UserId);

            modelBuilder.Entity<Watchlist>()
          .HasOne(w => w.User)
          .WithMany(u => u.watchlists)
          .HasForeignKey(w => w.UserId);


            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<MediaType>().HasData(
    new MediaType { MediaTypeId = 1, Name = "Movie" },
    new MediaType { MediaTypeId = 2, Name = "Anime" },
    new MediaType { MediaTypeId = 3, Name = "Series" }
);

            modelBuilder.Entity<Genre>().HasData(
                new Genre { Genre_ID = 1, Name = "Action" },
                new Genre { Genre_ID = 2, Name = "Adventure" },
                new Genre { Genre_ID = 3, Name = "Drama" },
                new Genre { Genre_ID = 4, Name = "Fantasy" },
                new Genre { Genre_ID = 5, Name = "Sci-Fi" },
                new Genre { Genre_ID = 6, Name = "Thriller" },
                new Genre { Genre_ID = 7, Name = "Mystery" },
                new Genre { Genre_ID = 8, Name = "Crime" },
                new Genre { Genre_ID = 9, Name = "Romance" },
                new Genre { Genre_ID = 10, Name = "Animation" }
            );

            modelBuilder.Entity<Director>().HasData(
                new Director
                {
                    Director_ID = 1,
                    Name = "Christopher Nolan",
                    BIO = "Renowned for his complex storytelling and innovative cinematography.",
                    birthdate = new DateOnly(1970, 7, 30),
                    nationality = "British-American",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/d/d1/Christopher_Nolan_Cannes_2018.jpg/800px-Christopher_Nolan_Cannes_2018.jpg"
                },
                new Director
                {
                    Director_ID = 2,
                    Name = "Quentin Tarantino",
                    BIO = "Known for his nonlinear storytelling and stylized violence.",
                    birthdate = new DateOnly(1963, 3, 27),
                    nationality = "American",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/03/Quentin_Tarantino_by_Gage_Skidmore.jpg/800px-Quentin_Tarantino_by_Gage_Skidmore.jpg"
                },
                new Director
                {
                    Director_ID = 3,
                    Name = "Hayao Miyazaki",
                    BIO = "Legendary Japanese animator and co-founder of Studio Ghibli.",
                    birthdate = new DateOnly(1941, 1, 5),
                    nationality = "Japanese",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/a0/Hayao_Miyazaki_cropped_1_Hayao_Miyazaki_201211.jpg/800px-Hayao_Miyazaki_cropped_1_Hayao_Miyazaki_201211.jpg"
                },
                new Director
                {
                    Director_ID = 4,
                    Name = "Shinichiro Watanabe",
                    BIO = "Famous for Cowboy Bebop and Samurai Champloo.",
                    birthdate = new DateOnly(1965, 5, 24),
                    nationality = "Japanese",
                    image = "https://upload.wikimedia.org/wikipedia/commons/thumb/7/76/Shinichiro_Watanabe_at_Anime_Expo_2016.jpg/800px-Shinichiro_Watanabe_at_Anime_Expo_2016.jpg"
                }
                
               
            );


            modelBuilder.Entity<Media>().HasData(
    // 🎬 Movies
    new Media
    {
        MediaId = 1,
        Title = "Inception",
        Year = 2010,
        Rating = 9,
        Description = "A thief with the ability to enter people's dreams takes on the heist of his life.",
        ReleaseDate = new DateOnly(2010, 07, 16),
        TrailerURL = "https://www.youtube.com/watch?v=YoHD9XEInc0",
        Poster = "https://m.media-amazon.com/images/I/51NBpSY0NHL._AC_.jpg",
        MediaTypeId = 1,
        Duration = 148,
        DirectorId = 1
    },
    new Media
    {
        MediaId = 2,
        Title = "The Dark Knight",
        Year = 2008,
        Rating = 10,
        Description = "Batman faces off against his greatest enemy, the Joker, in a battle for Gotham's soul.",
        ReleaseDate = new DateOnly(2008, 07, 18),
        TrailerURL = "https://www.youtube.com/watch?v=EXeTwQWrcwY",
        Poster = "https://m.media-amazon.com/images/I/51EbJvl8gJL._AC_.jpg",
        MediaTypeId = 1,
        Duration = 152,
        DirectorId = 1
    },

    // 🎌 Anime
    new Media
    {
        MediaId = 3,
        Title = "Attack on Titan",
        Year = 2013,
        Rating = 10,
        Description = "In a world where titans eat humans, a group of soldiers fight for survival.",
        ReleaseDate = new DateOnly(2013, 04, 07),
        TrailerURL = "https://www.youtube.com/watch?v=MGRm4IzK1SQ",
        Poster = "https://m.media-amazon.com/images/I/81ETPpG5dZL._AC_SL1500_.jpg",
        MediaTypeId = 2,
        Episodes = 75,
        Seasons = 4,
        Studio = "Wit Studio"
    },
    new Media
    {
        MediaId = 4,
        Title = "Naruto",
        Year = 2016,
        Rating = 9,
        Description = "Two strangers find themselves mysteriously connected despite never having met.",
        ReleaseDate = new DateOnly(2016, 08, 26),
        TrailerURL = "https://www.youtube.com/watch?v=xU47nhruN-Q",
        Poster = "https://m.media-amazon.com/images/I/91zno84lrzL._AC_SY679_.jpg",
        MediaTypeId = 2,
        Episodes = 1,
        Studio = "CoMix Wave Films"
    },

    // 📺 Series
    new Media
    {
        MediaId = 5,
        Title = "Breaking Bad",
        Year = 2008,
        Rating = 10,
        Description = "A high school chemistry teacher turned drug kingpin struggles to balance his new life.",
        ReleaseDate = new DateOnly(2008, 01, 20),
        TrailerURL = "https://www.youtube.com/watch?v=HhesaQXLuRY",
        Poster = "https://m.media-amazon.com/images/I/81eNnLuUuPL._AC_SL1500_.jpg",
        MediaTypeId = 3,
        Seasons = 5
    },
    new Media
    {
        MediaId = 6,
        Title = "Game of Thrones",
        Year = 2011,
        Rating = 9,
        Description = "Noble families vie for control of the Iron Throne in the land of Westeros.",
        ReleaseDate = new DateOnly(2011, 04, 17),
        TrailerURL = "https://www.youtube.com/watch?v=KPLWWIOCOOQ",
        Poster = "https://m.media-amazon.com/images/I/91YwZl3T52L._AC_SL1500_.jpg",
        MediaTypeId = 3,
        Seasons = 8
    }
);


            modelBuilder.Entity<Actor>().HasData(
                new Actor { Actor_ID = 1, Name = "Leonardo DiCaprio", BIO = "An award-winning American actor known for Inception and Titanic.", nationality = "American", image = "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5f/Leonardo_DiCaprio_2014.jpg/800px-Leonardo_DiCaprio_2014.jpg" },
                new Actor { Actor_ID = 2, Name = "Christian Bale", BIO = "Famous for his role as Batman in The Dark Knight Trilogy.", nationality = "British", image = "https://upload.wikimedia.org/wikipedia/commons/thumb/8/8a/Christian_Bale_2019.jpg/800px-Christian_Bale_2019.jpg" },
                new Actor { Actor_ID = 3, Name = "Bryan Cranston", BIO = "Best known for Breaking Bad.", nationality = "American", image = "https://upload.wikimedia.org/wikipedia/commons/thumb/4/4a/Bryan_Cranston_by_Gage_Skidmore_2.jpg/800px-Bryan_Cranston_by_Gage_Skidmore_2.jpg" },
                new Actor { Actor_ID = 4, Name = "Emilia Clarke", BIO = "Famous for playing Daenerys Targaryen in Game of Thrones.", nationality = "British", image = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/24/Emilia_Clarke_by_Gage_Skidmore.jpg/800px-Emilia_Clarke_by_Gage_Skidmore.jpg" },
                new Actor { Actor_ID = 5, Name = "Yuki Kaji", BIO = "Japanese voice actor known for voicing Eren Yeager in Attack on Titan.", nationality = "Japanese", image = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/39/Yuki_Kaji_Anime_Expo_2018.jpg/800px-Yuki_Kaji_Anime_Expo_2018.jpg" },
                new Actor { Actor_ID = 6, Name = "Haruka Tomatsu", BIO = "Japanese voice actress known for Asuna in Sword Art Online.", nationality = "Japanese", image = "https://upload.wikimedia.org/wikipedia/commons/3/3a/Haruka_Tomatsu_Anime_Expo_2018.jpg" }
            );


            modelBuilder.Entity<Media_Actors>().HasData(
    new Media_Actors { MediaId = 1, ActorId = 1 }, // Leonardo DiCaprio → Inception
    new Media_Actors { MediaId = 2, ActorId = 2 }, // Christian Bale → The Dark Knight
    new Media_Actors { MediaId = 3, ActorId = 5 }, // Yuki Kaji → Attack on Titan
    new Media_Actors { MediaId = 4, ActorId = 6 }, // Haruka Tomatsu → Your Name
    new Media_Actors { MediaId = 5, ActorId = 3 }, // Bryan Cranston → Breaking Bad
    new Media_Actors { MediaId = 6, ActorId = 4 }  // Emilia Clarke → Game of Thrones
);


            modelBuilder.Entity<Media_Genre>().HasData(
                new Media_Genre { MediaId = 1, GenreId = 5 }, // Inception → Sci-Fi
                new Media_Genre { MediaId = 2, GenreId = 6 }, // The Dark Knight → Thriller
                new Media_Genre { MediaId = 3, GenreId = 1 }, // Attack on Titan → Action
                new Media_Genre { MediaId = 4, GenreId = 9 }, // Your Name → Romance
                new Media_Genre { MediaId = 5, GenreId = 8 }, // Breaking Bad → Crime
                new Media_Genre { MediaId = 6, GenreId = 4 }  // Game of Thrones → Fantasy
            );





        }

        public DbSet<Media> medias { get; set; } 
        public DbSet<Actor> actors { get; set; } 
        public DbSet<Director> directors { get; set; } 

        public DbSet<Genre> genres { get; set; }     
        public DbSet<Watchlist> watchlists { get; set; } 
        public DbSet<MediaWatchlist> movieWatchlists { get; set; } 

        public DbSet<Media_Actors> Movie_Actors { get; set; } 
        public DbSet<Media_Genre> movie_Genres { get; set; } 
        public DbSet<Review> reviews { get; set; } 
        public DbSet<User> users { get; set; } 

    }
}
