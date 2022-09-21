using Microsoft.EntityFrameworkCore;
using Npgsql;
using WeatherProcessor.Database;
using WeatherProcessor.ProgramSettings;
using WeatherProcessor.Services.ExcelFileService;
using WeatherProcessor.Services.ShowWeatherService;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.local.json");
builder.SetSerilog();
builder.Services.AddControllersWithViews();
builder.Services
    .AddEntityFrameworkNpgsql()
    .AddDbContext<DatabaseContext>(db => db
        .UseNpgsql(builder.Configuration.GetConnectionString("Postgres")));

builder.Services.AddScoped<IExcelFileService, ExcelFileService>();
builder.Services.AddScoped<IShowWeatherService, ShowWeatherService>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
    context.Database.Migrate();

    var npgsqlConnection = context.Database.GetDbConnection() as NpgsqlConnection;
    npgsqlConnection?.Open();
    npgsqlConnection?.ReloadTypes();
    npgsqlConnection?.Close();
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
