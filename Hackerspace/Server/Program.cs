using Hackerspace.Server.Data;
using Hackerspace.Server.Hubs;
using Hackerspace.Server.Interfaces;
using Hackerspace.Server.Mocks;
using Hackerspace.Server.Repos;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;

namespace Hackerspace
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Inject data objects
            //var folder = Environment.SpecialFolder.LocalApplicationData;
            //var path = Environment.GetFolderPath(folder);
            //DbPath = System.IO.Path.Join(path, connectionString);
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlite("Data Source = Hackerspace.db"));
            builder.Services.AddTransient<IPostsRepo ,PostsRepo>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            // Inject data objects
            builder.Services.AddTransient<IPostsRepo, PostsRepo>();

            //Add SignalR
            builder.Services.AddSignalR();
            builder.Services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {"application/octet-stream"});
            });

            var app = builder.Build();

            //For SignalR
            app.UseResponseCompression();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();

            //For SignalR
            app.MapHub<ChatHub>("/chathub");

            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}