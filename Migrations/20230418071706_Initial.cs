using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attendee",
                columns: table => new
                {
                    Attendee_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Attendee_name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Attendee_email = table.Column<string>(type: "TEXT", nullable: true),
                    Attendee_contact = table.Column<int>(type: "INTEGER", nullable: false),
                    Facebook_id = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Linkedin_id = table.Column<string>(type: "TEXT", nullable: true),
                    git = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendee", x => x.Attendee_id);
                });

            migrationBuilder.CreateTable(
                name: "Session",
                columns: table => new
                {
                    Session_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Session_date = table.Column<int>(type: "INTEGER", nullable: false),
                    Topic = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Speaker_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Session", x => x.Session_id);
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Speaker_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Speaker_name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    Facebook_id = table.Column<string>(type: "TEXT", maxLength: 4000, nullable: true),
                    Linkedin_id = table.Column<string>(type: "TEXT", nullable: true),
                    git = table.Column<string>(type: "TEXT", nullable: true),
                    twitter = table.Column<string>(type: "TEXT", nullable: true),
                    bio = table.Column<string>(type: "TEXT", nullable: true),
                    About_Experience = table.Column<string>(type: "TEXT", nullable: true),
                    Interest = table.Column<string>(type: "TEXT", nullable: true),
                    WebSite = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Speaker_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendee");

            migrationBuilder.DropTable(
                name: "Session");

            migrationBuilder.DropTable(
                name: "Speakers");
        }
    }
}
