using ZooWeb.Data.Models;
using ZooWeb.Data.Repositories;
using ZooWeb.Service.Cloud;
using ZooWeb.Service.Comment;
using ZooWeb.Service.Community;
using ZooWeb.Service.Tag;
using ZooWeb.Service.Thread;
using ZooWeb.Service.User;
using ZooWeb.Web.Data;
using ZooWeb.Web.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        // Add services to the container.
        var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        builder.Services.AddDbContext<ZooWebDbContext>(options =>
            options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();

        // Application Repositories
        builder.Services.AddTransient<ZooWebCommunityRepository>();
        builder.Services.AddTransient<ZooWebTagRepository>();
        builder.Services.AddTransient<ZooWebThreadRepository>();
        builder.Services.AddTransient<CommentRepository>();

        // Application Services
        builder.Services.AddTransient<IZooWebCommunityService, ZooWebCommunityService>();
        builder.Services.AddTransient<IZooWebTagService, ZooWebTagService>();
        builder.Services.AddTransient<IZooWebThreadService, ZooWebThreadService>();
        builder.Services.AddTransient<ICommentService, CommentService>();
        builder.Services.AddTransient<IUserContextService, UserContextService>();
        builder.Services.AddTransient<ICloudinaryService, CloudinaryService>();

        builder.Services
            .AddDefaultIdentity<ZooWebUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ZooWebDbContext>();

        builder.Services.AddControllersWithViews();
    }

    public static void ConfigureApp(WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseMigrationsEndPoint();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseDatabaseSeed();

        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthorization();

        app.MapStaticAssets();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();

        app.MapRazorPages()
           .WithStaticAssets();
    }

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        ConfigureServices(builder);
        
        var app = builder.Build();
        ConfigureApp(app);

        app.Run();
    }
}