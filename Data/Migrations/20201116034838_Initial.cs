using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AddressBook.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressPerson",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true),
                    ImageData = table.Column<byte[]>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    AddressOne = table.Column<string>(nullable: true),
                    AddressTwo = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    PhoneNumber = table.Column<int>(nullable: false),
                    Created = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressPerson", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressPerson");
        }
    }
}
