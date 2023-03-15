using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartShare.Infrastructure.Migrations;

/// <inheritdoc />
public partial class InitialCreate : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Apartments",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                NumberOfBeds = table.Column<int>(type: "int", nullable: false),
                Blob = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                DistanceToCenter = table.Column<double>(type: "float", nullable: false),
                OwnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Apartments", x => x.Id);
            });

        migrationBuilder.CreateTable(
            name: "Users",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                UserName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                Blob = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                ApartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey(
                    name: "FK_Users_Apartments_ApartmentId",
                    column: x => x.ApartmentId,
                    principalTable: "Apartments",
                    principalColumn: "Id");
            });

        migrationBuilder.CreateTable(
            name: "Requests",
            columns: table => new
            {
                Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                Status = table.Column<int>(type: "int", nullable: false),
                City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                GuestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Requests", x => x.Id);
                table.ForeignKey(
                    name: "FK_Requests_Users_GuestId",
                    column: x => x.GuestId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
                table.ForeignKey(
                    name: "FK_Requests_Users_HostId",
                    column: x => x.HostId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.NoAction);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Requests_GuestId",
            table: "Requests",
            column: "GuestId");

        migrationBuilder.CreateIndex(
            name: "IX_Requests_HostId",
            table: "Requests",
            column: "HostId");

        migrationBuilder.CreateIndex(
            name: "IX_Users_ApartmentId",
            table: "Users",
            column: "ApartmentId",
            unique: true,
            filter: "[ApartmentId] IS NOT NULL");

        migrationBuilder.CreateIndex(
            name: "IX_Users_Email",
            table: "Users",
            column: "Email",
            unique: true);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "Requests");

        migrationBuilder.DropTable(
            name: "Users");

        migrationBuilder.DropTable(
            name: "Apartments");
    }
}
