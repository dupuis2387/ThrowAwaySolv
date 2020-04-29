using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolvTest.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    PlaintextDescription = table.Column<string>(maxLength: 500, nullable: false),
                    HtmlDescription = table.Column<string>(maxLength: 1000, nullable: false),
                    ReleaseDate = table.Column<DateTime>(nullable: false),
                    ArtUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieShowtimes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    MovieShowTime = table.Column<DateTime>(nullable: false),
                    MovieId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieShowtimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieShowtimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ArtUrl", "HtmlDescription", "PlaintextDescription", "ReleaseDate", "Title" },
                values: new object[] { new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), "https://upload.wikimedia.org/wikipedia/en/thumb/c/c1/The_Matrix_Poster.jpg/220px-The_Matrix_Poster.jpg", "<p>Neo (Keanu Reeves) believes that Morpheus (Laurence Fishburne), an elusive figure considered to be the most dangerous man alive, can answer his question -- What is the Matrix? Neo is contacted by Trinity (Carrie-Anne Moss), a beautiful stranger who leads him into an underworld where he meets Morpheus. They fight a brutal battle for their lives against a cadre of viciously intelligent secret agents. It is a truth that could cost Neo something more precious than his life.</p>", "Some judo flying nerds in VR", new DateTime(1999, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Matrix" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ArtUrl", "HtmlDescription", "PlaintextDescription", "ReleaseDate", "Title" },
                values: new object[] { new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), "https://upload.wikimedia.org/wikipedia/en/thumb/5/50/Resident_evil_apocalypse_poster.jpg/220px-Resident_evil_apocalypse_poster.jpg", "<p>A deadly virus from a secret Umbrella Corporation laboratory underneath Raccoon City is exposed to the world. Umbrella seals off the city to contain the virus, creating a ghost town where everyone trapped inside turns into a mutant zombie. Alice (Milla Jovovich), a survivor from Umbrella's secret lab, meets former Umbrella security officer Jill Valentine (Sienna Guillory) and mercenary Carlos Oliviera (Oded Fehr). Together, they search for a scientist (Jared Harris) who might be able to help.</p>", "Zombie flick with souped up chick", new DateTime(2004, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil: Apocalypse" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ArtUrl", "HtmlDescription", "PlaintextDescription", "ReleaseDate", "Title" },
                values: new object[] { new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), "https://upload.wikimedia.org/wikipedia/en/thumb/e/ea/Resident_Evil-_Afterlife.jpg/220px-Resident_Evil-_Afterlife.jpg", "<p>In a world overrun with the walking dead, Alice (Milla Jovovich) continues her battle against Umbrella Corp., rounding up survivors along the way. Joined by an old friend, Alice and her group set out for a rumored safe haven in Los Angeles. Instead of sanctuary, they find the city overrun with zombies, and a trap about to spring.</p>", "Zombie flick with souped up chick and clones", new DateTime(2010, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Resident Evil: Afterlife" });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("436d60ac-2fd7-42f5-a8a2-0322dbbb005a"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2020, 4, 30, 9, 57, 44, 323, DateTimeKind.Local).AddTicks(9420) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("dd6c6c4f-dd33-4a8c-b3b7-e42e990116da"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2020, 5, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("16cd1b84-5c1f-40e3-8544-22bf73095e70"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2020, 4, 30, 14, 57, 44, 343, DateTimeKind.Local).AddTicks(2890) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("65976408-592b-4b4f-881a-87c48da4e2ba"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2020, 5, 4, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("6f705186-13bd-411c-bec7-e88333171e08"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2020, 4, 30, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2880) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("f0a7163d-3cba-47b3-b8a7-b6c9d5db6d42"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2017, 4, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2870) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("866a55ca-322e-40a9-bc3e-9f12cc299faf"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2020, 4, 14, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2860) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("6748df42-bbc6-4d75-a899-73cb0d7c1db6"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2020, 5, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2850) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("822c1c41-c75a-4480-93ae-b20b63de37a0"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2020, 4, 30, 14, 57, 44, 343, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("18b7eb36-d5dc-4259-afbf-2978eada93e1"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2020, 5, 4, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2840) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("b4be23ec-bbac-4eaa-aa36-cad40ce103e8"), new Guid("dbe64947-77e5-4adc-9273-3160843781f1"), new DateTime(2020, 4, 30, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2820) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("77b075b3-5dcb-4042-8589-7aef333c8762"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2017, 4, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2760) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("05b2eba5-671e-47ae-a210-1471a033ab78"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2020, 4, 14, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2740) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("072898fd-81af-4ca7-ac79-7acd168ebf9f"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2020, 5, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2670) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("7b5edc72-20cd-4dfe-a280-d9f711932319"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2020, 4, 30, 14, 57, 44, 343, DateTimeKind.Local).AddTicks(2630) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("005c1cb3-64df-4bfb-a44d-a2fc219e2e08"), new Guid("47c5f2e0-a1a7-44cb-8550-3144dc0dd79e"), new DateTime(2020, 5, 4, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2570) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("41ee978a-6130-487d-8848-8462b11ebc85"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2020, 4, 14, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2900) });

            migrationBuilder.InsertData(
                table: "MovieShowtimes",
                columns: new[] { "Id", "MovieId", "MovieShowTime" },
                values: new object[] { new Guid("cfe661ab-8d71-42e5-8f9c-a331ae4a9a8a"), new Guid("4d12e1fe-8109-4208-ae79-86c6bfb481a5"), new DateTime(2017, 4, 29, 9, 57, 44, 343, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.CreateIndex(
                name: "IX_MovieShowtimes_MovieId",
                table: "MovieShowtimes",
                column: "MovieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieShowtimes");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
