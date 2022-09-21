using Microsoft.EntityFrameworkCore;
using WeatherProcessor.Database;
using WeatherProcessor.ProgramSettings;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json");
builder.SetSerilog();
builder.Services.AddControllersWithViews();
builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<DatabaseContext>(db => db
        .UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    context.Database.Migrate();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=MainPage}/{action=Index}/{id?}");

app.Run();
