using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSomeNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Statuse",
                table: "Users",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Statuse",
                table: "UserAplications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "Statuse",
                table: "OrganizationAplications",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Messages",
                newName: "Created");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Vacancies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Vacancies",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "Resumes",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Users",
                newName: "Statuse");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "UserAplications",
                newName: "Statuse");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "OrganizationAplications",
                newName: "Statuse");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Messages",
                newName: "DateTime");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Vacancies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Vacancies",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<string>(
                name: "Education",
                table: "Resumes",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
