using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mixandmatchv2.Migrations
{
    /// <inheritdoc />
    public partial class changeids : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "jobid",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "jobdescription",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "jobtype",
                table: "Jobs",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "jobname",
                table: "Jobs",
                newName: "description");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "companyid",
                table: "Jobs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "end",
                table: "Jobs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start",
                table: "Jobs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "id",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "companyid",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "end",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Jobs");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Jobs",
                newName: "jobtype");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Jobs",
                newName: "jobname");

            migrationBuilder.AddColumn<Guid>(
                name: "jobid",
                table: "Jobs",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "jobdescription",
                table: "Jobs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Jobs",
                table: "Jobs",
                column: "jobid");
        }
    }
}
