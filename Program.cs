using IMDB.Models;
using IMDB.MyContext;
using IMDB.Repository;
using IMDB.Services;
using IMDB.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace IMDB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("connection");
            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<Applicationcontext>(option =>
            {
                option.UseSqlServer(connection);
            });

            builder.Services.AddScoped<IMedia<AnimeViewModel>, AnimeService>();
            builder.Services.AddTransient<IMedia<MediaType>, MediaTypeSerice>();
            builder.Services.AddScoped<IMedia<MovieViewModel>, MovieService>();
            builder.Services.AddTransient<IActor<Actor>, ActorRepo>();
            builder.Services.AddTransient<IMedia<ActorViewModel>, ActorService>();
            builder.Services.AddTransient<IMedia<Genre>, GenreService>();
            builder.Services.AddTransient<IMedia<Director>, ReplacmentDirectorService>();
            builder.Services.AddTransient<IMedia<DirectorViewModel>, DirectorService>();
            builder.Services.AddTransient<IMedia<Movie_ActorViewModel>, MovieActorService>();
            builder.Services.AddTransient<IMedia<TotalMovieViewModel>, TotalMoviesService>();
            builder.Services.AddTransient<IActor<Media>, MovieDetailsRepo>();
            builder.Services.AddTransient<IActor<Media>, MovieDetailsRepo>();
            builder.Services.AddTransient<IActor<Director>, Directorrepo>();
            builder.Services.AddTransient<IActor<Media>, AnimeRepo>(); 

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
