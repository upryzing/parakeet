using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Parakeet.Core.Attachments.Tables;
using Parakeet.Core.Spaces.Tables;
using Parakeet.Core.Users.Tables;

#nullable disable

namespace Parakeet.Core.Database.Migrations
{
    /// <inheritdoc />
    public partial class baseMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "character varying(105)", maxLength: 105, nullable: false),
                    deletion = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_accounts", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "invites",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    type = table.Column<byte>(type: "smallint", nullable: false),
                    remainingUses = table.Column<int>(type: "integer", nullable: false),
                    claimedBy = table.Column<Guid>(type: "uuid", nullable: true),
                    valid = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invites", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sessions",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    userID = table.Column<Guid>(type: "uuid", nullable: false),
                    token = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false),
                    name = table.Column<string>(type: "character varying(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sessions", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "spaces",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    owner = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    description = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: true),
                    nsfw = table.Column<bool>(type: "boolean", nullable: false),
                    roles = table.Column<Dictionary<string, Role>>(type: "jsonb", nullable: false),
                    default_permissions = table.Column<long>(type: "bigint", nullable: false),
                    icon = table.Column<Attachment>(type: "jsonb", nullable: true),
                    banner = table.Column<Attachment>(type: "jsonb", nullable: true),
                    channels = table.Column<List<string>>(type: "text[]", nullable: false),
                    categories = table.Column<List<Category>>(type: "jsonb", nullable: true),
                    system_messages = table.Column<SystemMessageChannels>(type: "jsonb", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_spaces", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    username = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: false),
                    discriminator = table.Column<string>(type: "character varying(4)", maxLength: 4, nullable: false),
                    display_name = table.Column<string>(type: "character varying(160)", maxLength: 160, nullable: true),
                    pronouns = table.Column<List<string>>(type: "text[]", nullable: true),
                    avatar_id = table.Column<Guid>(type: "uuid", nullable: true),
                    relations = table.Column<List<Relationship>>(type: "jsonb", nullable: true),
                    badges = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<UserStatus>(type: "jsonb", nullable: true),
                    profile = table.Column<UserProfile>(type: "jsonb", nullable: true),
                    suspended_until = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    flags = table.Column<int>(type: "integer", nullable: false),
                    bot = table.Column<BotInformation>(type: "jsonb", nullable: true),
                    privileged = table.Column<bool>(type: "boolean", nullable: false),
                    last_acknowledged_policy_change = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_deletion",
                table: "accounts",
                column: "deletion");

            migrationBuilder.CreateIndex(
                name: "IX_accounts_email",
                table: "accounts",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_id",
                table: "accounts",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_accounts_password",
                table: "accounts",
                column: "password");

            migrationBuilder.CreateIndex(
                name: "IX_invites_claimedBy",
                table: "invites",
                column: "claimedBy");

            migrationBuilder.CreateIndex(
                name: "IX_invites_id",
                table: "invites",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_invites_type",
                table: "invites",
                column: "type");

            migrationBuilder.CreateIndex(
                name: "IX_invites_valid",
                table: "invites",
                column: "valid");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_id",
                table: "sessions",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_sessions_token",
                table: "sessions",
                column: "token");

            migrationBuilder.CreateIndex(
                name: "IX_sessions_userID",
                table: "sessions",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_spaces_id",
                table: "spaces",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_spaces_owner",
                table: "spaces",
                column: "owner");

            migrationBuilder.CreateIndex(
                name: "IX_users_id",
                table: "users",
                column: "id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_username",
                table: "users",
                column: "username",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "invites");

            migrationBuilder.DropTable(
                name: "sessions");

            migrationBuilder.DropTable(
                name: "spaces");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
