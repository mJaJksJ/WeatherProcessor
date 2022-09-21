using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WeatherProcessor.Database.Entities.Enums;

#nullable disable

namespace WeatherProcessor.Database.Migrations
{
    public partial class InitMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:month", "january,february,march,april,may,june,july,august,september,october,november,december")
                .Annotation("Npgsql:Enum:weather_type", "hase,continuous_light_snow,snow,ice_needles,rainfall_with_snow,continuous_medium_snow,light_rainfall_snow,light_snow_with_breaks,unchanged_state,cloud_less,light_pozemok,cloud_forming,rain,rainfall,continuous_light_rain,remote_thunderstorm,light_drizzle_with_ice,continuous_heavy_snow,drizzle_with_snow,light_rainfall,thunderstorm,thunder_with_fallout,continuous_medium_rain,light_rain_with_ice,rainfall_snow,hail,light_rain_with_breaks,continuous_light_drizzle,fog_forming_without_sky,ice_rain,drizzle_with_ice,medium_rain_with_breaks,individual_snow_crystals,light_ice_snow_grains,light_rainfall_with_snow,light_rain_with_thunderstorm,for_forming_with_sky,continuous_heavy_rain,drizzle,snow_grains,light_drizzle_with_rain,fog_continuous_without_sky,rain_with_thinderstorm,very_heavy_rainfall,ice_grains,continuous_medium_drizzle,fog,fog_continuous_with_sky,heavy_snow_with_breaks,heavy_rain_drizzle_with_show,none")
                .Annotation("Npgsql:Enum:wind_direction", "north,north_east,east,south_east,south,south_west,west,north_west,calm");

            migrationBuilder.CreateTable(
                name: "weather_report",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<Month>(type: "month", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather_report", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "weather_report_info",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    weather_report_id = table.Column<int>(type: "integer", nullable: false),
                    date_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    temperature = table.Column<double>(type: "double precision", nullable: false),
                    humidity = table.Column<double>(type: "double precision", nullable: false),
                    dew_point = table.Column<double>(type: "double precision", nullable: false),
                    pressure = table.Column<int>(type: "integer", nullable: false),
                    wind_directions = table.Column<WindDirection[]>(type: "wind_direction[]", nullable: true),
                    wind_speed = table.Column<int>(type: "integer", nullable: false),
                    cloud_cover = table.Column<int>(type: "integer", nullable: false),
                    cloud_lower_limit = table.Column<int>(type: "integer", nullable: false),
                    horizontal_visibility = table.Column<double>(type: "double precision", nullable: false),
                    weather_type = table.Column<WeatherType>(type: "weather_type", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weather_report_info", x => x.id);
                    table.ForeignKey(
                        name: "FK_weather_report_info_weather_report_weather_report_id",
                        column: x => x.weather_report_id,
                        principalTable: "weather_report",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_weather_report_info_weather_report_id",
                table: "weather_report_info",
                column: "weather_report_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "weather_report_info");

            migrationBuilder.DropTable(
                name: "weather_report");
        }
    }
}
