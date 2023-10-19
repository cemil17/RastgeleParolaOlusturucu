using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GeneratePassword.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "Ciphers");

            migrationBuilder.RenameColumn(
                name: "GuidID",
                table: "Ciphers",
                newName: "GuidId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "GuidId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers");

            migrationBuilder.RenameColumn(
                name: "GuidId",
                table: "Ciphers",
                newName: "GuidID");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "Ciphers",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ciphers",
                table: "Ciphers",
                column: "ID");
        }
    }
}
