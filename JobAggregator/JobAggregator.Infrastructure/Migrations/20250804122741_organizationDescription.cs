﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobAggregator.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class organizationDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Organizations",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Organizations");
        }
    }
}
