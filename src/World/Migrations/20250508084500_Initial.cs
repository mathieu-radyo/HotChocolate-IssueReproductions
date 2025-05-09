using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace World.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Iso3 = table.Column<string>(type: "TEXT", nullable: false),
                    NumericCode = table.Column<string>(type: "TEXT", nullable: true),
                    Iso2 = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneCode = table.Column<string>(type: "TEXT", nullable: true),
                    Capital = table.Column<string>(type: "TEXT", nullable: true),
                    Currency = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencyName = table.Column<string>(type: "TEXT", nullable: true),
                    CurrencySymbol = table.Column<string>(type: "TEXT", nullable: true),
                    Tld = table.Column<string>(type: "TEXT", nullable: true),
                    Native = table.Column<string>(type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Emoji = table.Column<string>(type: "TEXT", nullable: true),
                    EmojiU = table.Column<string>(type: "TEXT", nullable: true),
                    WikiDataId = table.Column<string>(type: "TEXT", nullable: true),
                    IsMonarchy = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeclarationOfIndependence = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    WikiDataId = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    FipsCode = table.Column<string>(type: "TEXT", nullable: true),
                    Iso2 = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    WikiDataId = table.Column<string>(type: "TEXT", nullable: true),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                    table.ForeignKey(
                        name: "FK_State_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubRegion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    WikiDataId = table.Column<string>(type: "TEXT", nullable: true),
                    RegionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubRegion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubRegion_Region_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Region",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    WikiDataId = table.Column<string>(type: "TEXT", nullable: true),
                    StateId = table.Column<int>(type: "INTEGER", nullable: false),
                    CountryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_City_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Capital", "CreatedDate", "Currency", "CurrencyName", "CurrencySymbol", "DeclarationOfIndependence", "Emoji", "EmojiU", "IsMonarchy", "Iso2", "Iso3", "Latitude", "Longitude", "Name", "Nationality", "Native", "NumericCode", "PhoneCode", "Tld", "WikiDataId" },
                values: new object[,]
                {
                    { 1, "Brussels", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1830, 10, 4), "🇧🇪", "U+1F1E7 U+1F1EA", true, "BE", "BEL", 50.850299999999997, 4.3517000000000001, "Belgium", "Belgian", "België", "056", "32", ".be", "Q31" },
                    { 2, "Paris", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1789, 7, 14), "🇫🇷", "U+1F1EB U+1F1F7", false, "FR", "FRA", 48.8566, 2.3521999999999998, "France", "French", "France", "250", "33", ".fr", "Q142" },
                    { 3, "Washington", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "USD", "US Dollar", "$", new DateOnly(1776, 7, 4), "🇺🇸", "U+1F1FA U+1F1F8", false, "US", "USA", 38.895099999999999, -77.0364, "United States", "American", "United States", "840", "1", ".us", "Q30" },
                    { 4, "Berlin", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1990, 10, 3), "🇩🇪", "U+1F1E9 U+1F1EA", false, "DE", "DEU", 52.520000000000003, 13.404999999999999, "Germany", "German", "Deutschland", "276", "49", ".de", "Q183" },
                    { 5, "Madrid", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1492, 1, 2), "🇪🇸", "U+1F1EA U+1F1F8", true, "ES", "ESP", 40.416800000000002, -3.7038000000000002, "Spain", "Spanish", "España", "724", "34", ".es", "Q29" },
                    { 6, "Rome", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1861, 3, 17), "🇮🇹", "U+1F1EE U+1F1F9", false, "IT", "ITA", 41.902799999999999, 12.4964, "Italy", "Italian", "Italia", "380", "39", ".it", "Q38" },
                    { 7, "Tokyo", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "JPY", "Yen", "¥", new DateOnly(660, 2, 11), "🇯🇵", "U+1F1EF U+1F1F5", true, "JP", "JPN", 35.676200000000001, 139.65029999999999, "Japan", "Japanese", "日本", "392", "81", ".jp", "Q17" },
                    { 8, "Canberra", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "AUD", "Australian Dollar", "$", new DateOnly(1901, 1, 1), "🇦🇺", "U+1F1E6 U+1F1FA", true, "AU", "AUS", -35.280900000000003, 149.13, "Australia", "Australian", "Australia", "036", "61", ".au", "Q408" },
                    { 9, "Brasília", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "BRL", "Brazilian Real", "R$", new DateOnly(1822, 9, 7), "🇧🇷", "U+1F1E7 U+1F1F7", false, "BR", "BRA", -15.826700000000001, -47.921799999999998, "Brazil", "Brazilian", "Brasil", "076", "55", ".br", "Q155" },
                    { 10, "London", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "GBP", "Pound Sterling", "£", new DateOnly(1707, 5, 1), "🇬🇧", "U+1F1EC U+1F1E7", true, "GB", "GBR", 51.507199999999997, -0.12759999999999999, "United Kingdom", "British", "United Kingdom", "826", "44", ".uk", "Q145" },
                    { 11, "Ottawa", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CAD", "Canadian Dollar", "$", new DateOnly(1867, 7, 1), "🇨🇦", "U+1F1E8 U+1F1E6", true, "CA", "CAN", 45.421500000000002, -75.697199999999995, "Canada", "Canadian", "Canada", "124", "1", ".ca", "Q16" },
                    { 12, "Pretoria", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ZAR", "South African Rand", "R", new DateOnly(1961, 5, 31), "🇿🇦", "U+1F1FF U+1F1E6", false, "ZA", "ZAF", -25.746099999999998, 28.188099999999999, "South Africa", "South African", "South Africa", "710", "27", ".za", "Q258" },
                    { 13, "New Delhi", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "INR", "Indian Rupee", "₹", new DateOnly(1947, 8, 15), "🇮🇳", "U+1F1EE U+1F1F3", false, "IN", "IND", 28.613900000000001, 77.209000000000003, "India", "Indian", "भारत", "356", "91", ".in", "Q668" },
                    { 14, "Stockholm", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "SEK", "Swedish Krona", "kr", new DateOnly(1523, 6, 6), "🇸🇪", "U+1F1F8 U+1F1EA", true, "SE", "SWE", 59.329300000000003, 18.0686, "Sweden", "Swedish", "Sverige", "752", "46", ".se", "Q34" },
                    { 15, "Oslo", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "NOK", "Norwegian Krone", "kr", new DateOnly(1905, 6, 7), "🇳🇴", "U+1F1F3 U+1F1F4", true, "NO", "NOR", 59.913899999999998, 10.7522, "Norway", "Norwegian", "Norge", "578", "47", ".no", "Q20" },
                    { 16, "Bern", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CHF", "Swiss Franc", "Fr", new DateOnly(1291, 8, 1), "🇨🇭", "U+1F1E8 U+1F1ED", false, "CH", "CHE", 46.948099999999997, 7.4474, "Switzerland", "Swiss", "Schweiz", "756", "41", ".ch", "Q39" },
                    { 17, "Amsterdam", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1581, 7, 26), "🇳🇱", "U+1F1F3 U+1F1F1", true, "NL", "NLD", 52.367600000000003, 4.9040999999999997, "Netherlands", "Dutch", "Nederland", "528", "31", ".nl", "Q55" },
                    { 18, "Lisbon", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "EUR", "Euro", "€", new DateOnly(1143, 10, 5), "🇵🇹", "U+1F1F5 U+1F1F9", false, "PT", "PRT", 38.716900000000003, -9.1399000000000008, "Portugal", "Portuguese", "Portugal", "620", "351", ".pt", "Q45" },
                    { 19, "Mexico City", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "MXN", "Mexican Peso", "$", new DateOnly(1810, 9, 16), "🇲🇽", "U+1F1F2 U+1F1FD", false, "MX", "MEX", 19.432600000000001, -99.133200000000002, "Mexico", "Mexican", "México", "484", "52", ".mx", "Q96" },
                    { 20, "Beijing", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "CNY", "Renminbi", "¥", new DateOnly(1949, 10, 1), "🇨🇳", "U+1F1E8 U+1F1F3", false, "CN", "CHN", 39.904200000000003, 116.4074, "China", "Chinese", "中国", "156", "86", ".cn", "Q148" },
                    { 21, "Moscow", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "RUB", "Russian Ruble", "₽", new DateOnly(1991, 12, 25), "🇷🇺", "U+1F1F7 U+1F1FA", false, "RU", "RUS", 55.755800000000001, 37.6173, "Russia", "Russian", "Россия", "643", "7", ".ru", "Q159" },
                    { 22, "Buenos Aires", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "ARS", "Argentine Peso", "$", new DateOnly(1816, 7, 9), "🇦🇷", "U+1F1E6 U+1F1F7", false, "AR", "ARG", -34.603700000000003, -58.381599999999999, "Argentina", "Argentinian", "Argentina", "032", "54", ".ar", "Q414" },
                    { 23, "Seoul", new DateTime(2012, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "KRW", "South Korean Won", "₩", new DateOnly(1948, 8, 15), "🇰🇷", "U+1F1F0 U+1F1F7", false, "KR", "KOR", 37.566499999999998, 126.97799999999999, "South Korea", "South Korean", "대한민국", "410", "82", ".kr", "Q884" }
                });

            migrationBuilder.InsertData(
                table: "Region",
                columns: new[] { "Id", "Name", "WikiDataId" },
                values: new object[,]
                {
                    { 1, "Europe", "Q46" },
                    { 2, "North America", "Q49" },
                    { 3, "Asia", "Q48" },
                    { 4, "Oceania", "Q538" },
                    { 5, "South America", "Q18" },
                    { 6, "Africa", "Q15" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "CountryId", "FipsCode", "Iso2", "Latitude", "Longitude", "Name", "WikiDataId" },
                values: new object[,]
                {
                    { 1, 1, null, null, 0.0, 0.0, "Brussels-Capital", null },
                    { 2, 2, null, null, 0.0, 0.0, "Île-de-France", null },
                    { 3, 3, null, null, 0.0, 0.0, "California", null },
                    { 4, 4, null, null, 0.0, 0.0, "Berlin", null },
                    { 5, 5, null, null, 0.0, 0.0, "Community of Madrid", null },
                    { 6, 6, null, null, 0.0, 0.0, "Lazio", null },
                    { 7, 7, null, null, 0.0, 0.0, "Tokyo Metropolis", null },
                    { 8, 8, null, null, 0.0, 0.0, "New South Wales", null },
                    { 9, 9, null, null, 0.0, 0.0, "São Paulo", null },
                    { 10, 10, null, null, 0.0, 0.0, "Greater London", null },
                    { 11, 11, null, null, 0.0, 0.0, "Ontario", null },
                    { 12, 12, null, null, 0.0, 0.0, "Western Cape", null },
                    { 13, 13, null, null, 0.0, 0.0, "Delhi", null }
                });

            migrationBuilder.InsertData(
                table: "SubRegion",
                columns: new[] { "Id", "Name", "RegionId", "WikiDataId" },
                values: new object[,]
                {
                    { new Guid("47ce3e8b-61bc-4806-9499-01594ba19f1e"), "South America", 5, "Q18" },
                    { new Guid("601bd8dc-4908-4cee-8844-73792e32fd5e"), "Australia and New Zealand", 4, "Q538" },
                    { new Guid("bf3514e8-3509-43cc-80b6-b966a43e74ca"), "Southern Asia", 3, "Q46169" },
                    { new Guid("cdeb1ec2-d13b-4359-9592-e36809ce3104"), "Southern Africa", 6, "Q824" },
                    { new Guid("cf0da940-7235-4b1d-a8e8-9f5bf827a033"), "Eastern Asia", 3, "Q4628" },
                    { new Guid("d92a1d17-ea43-4337-b443-741e74d9f2c1"), "Western Europe", 1, "Q27574" },
                    { new Guid("ee99e4a6-df46-40ac-a4ed-72bf3b44fbba"), "Northern America", 2, "Q49" }
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "Id", "CountryId", "CreatedOn", "Latitude", "Longitude", "Name", "StateId", "WikiDataId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.850299999999997, 4.3517000000000001, "Brussels", 1, null },
                    { 2, 1, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.2194, 4.4024999999999999, "Antwerp", 1, null },
                    { 3, 2, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.8566, 2.3521999999999998, "Paris", 2, null },
                    { 4, 2, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.764000000000003, 4.8357000000000001, "Lyon", 2, null },
                    { 5, 3, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.052199999999999, -118.2437, "Los Angeles", 3, null },
                    { 6, 3, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 37.774900000000002, -122.4194, "San Francisco", 3, null },
                    { 7, 4, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.520000000000003, 13.404999999999999, "Berlin", 4, null },
                    { 8, 5, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.416800000000002, -3.7038000000000002, "Madrid", 5, null },
                    { 9, 6, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.902799999999999, 12.4964, "Rome", 6, null },
                    { 10, 7, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.689500000000002, 139.6917, "Tokyo", 7, null },
                    { 11, 8, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -33.8688, 151.20930000000001, "Sydney", 8, null },
                    { 12, 9, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -23.5505, -46.633299999999998, "São Paulo", 9, null },
                    { 13, 10, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.507199999999997, -0.12759999999999999, "London", 10, null },
                    { 14, 11, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.651000000000003, -79.346999999999994, "Toronto", 11, null },
                    { 15, 12, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -33.924900000000001, 18.424099999999999, "Cape Town", 12, null },
                    { 16, 13, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 28.613900000000001, 77.209000000000003, "New Delhi", 13, null },
                    { 17, 1, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 51.054299999999998, 3.7174, "Ghent", 1, null },
                    { 18, 2, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.7102, 7.2619999999999996, "Nice", 2, null },
                    { 19, 3, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 32.715699999999998, -117.1611, "San Diego", 3, null },
                    { 20, 4, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 53.551099999999998, 9.9937000000000005, "Hamburg", 4, null },
                    { 21, 5, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 41.385100000000001, 2.1734, "Barcelona", 5, null },
                    { 22, 6, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 45.464199999999998, 9.1899999999999995, "Milan", 6, null },
                    { 23, 7, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 34.6937, 135.50229999999999, "Osaka", 7, null },
                    { 24, 8, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -37.813600000000001, 144.9631, "Melbourne", 8, null },
                    { 25, 9, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -22.9068, -43.172899999999998, "Rio de Janeiro", 9, null },
                    { 26, 10, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 52.486199999999997, -1.8904000000000001, "Birmingham", 10, null },
                    { 27, 11, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 49.282699999999998, -123.1207, "Vancouver", 11, null },
                    { 28, 12, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), -29.858699999999999, 31.021799999999999, "Durban", 12, null },
                    { 29, 13, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 19.076000000000001, 72.877700000000004, "Mumbai", 13, null },
                    { 30, 1, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 50.632599999999996, 5.5796999999999999, "Liège", 1, null },
                    { 31, 2, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 43.604700000000001, 1.4441999999999999, "Toulouse", 2, null },
                    { 32, 3, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 38.581600000000002, -121.4944, "Sacramento", 3, null },
                    { 33, 4, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 48.135100000000001, 11.582000000000001, "Munich", 4, null },
                    { 34, 5, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 39.469900000000003, -0.37630000000000002, "Valencia", 5, null },
                    { 35, 6, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 40.851799999999997, 14.2681, "Naples", 6, null },
                    { 36, 7, new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 35.011600000000001, 135.7681, "Kyoto", 7, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_StateId",
                table: "City",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_State_CountryId",
                table: "State",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubRegion_RegionId",
                table: "SubRegion",
                column: "RegionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "SubRegion");

            migrationBuilder.DropTable(
                name: "State");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
