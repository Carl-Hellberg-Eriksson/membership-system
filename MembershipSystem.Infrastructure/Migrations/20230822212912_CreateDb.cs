using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MembershipSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    BirthDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressRow1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressRow2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressRow3 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    AddressRow4 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    MembershipExpirationDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
