using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DomainCentricDemo.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DenKemInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Authors",
                newName: "FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Authors",
                newName: "Description");
        }
    }
}
