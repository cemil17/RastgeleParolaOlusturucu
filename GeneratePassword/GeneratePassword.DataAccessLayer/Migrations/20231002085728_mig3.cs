using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneratePassword.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Guid",
                table: "Ciphers",
                newName: "GuidID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GuidID",
                table: "Ciphers",
                newName: "Guid");
        }
    }
}
