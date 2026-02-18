using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parakeet.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<string>(type: "character varying(26)", maxLength: 26, nullable: false),
                    homeserver = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: false),
                    username = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    usernameLower = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_homeserver",
                table: "user",
                column: "homeserver");

            migrationBuilder.CreateIndex(
                name: "IX_user_id_homeserver",
                table: "user",
                columns: new[] { "id", "homeserver" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_usernameLower_homeserver",
                table: "user",
                columns: new[] { "usernameLower", "homeserver" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
