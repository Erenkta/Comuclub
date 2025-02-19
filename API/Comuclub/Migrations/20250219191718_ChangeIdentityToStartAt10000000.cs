using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Comuclub.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIdentityToStartAt10000000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "image",
                table: "Events",
                newName: "Image");

            migrationBuilder.Sql("DBCC CHECKIDENT ('Organizers', RESEED, 9999999);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Clubs', RESEED, 9999999);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Events', RESEED, 9999999);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "Events",
                newName: "image");

            migrationBuilder.Sql("DBCC CHECKIDENT ('Organizers', RESEED, 1);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Clubs', RESEED, 1);");
            migrationBuilder.Sql("DBCC CHECKIDENT ('Events', RESEED, 1);");

        }
    }
}
