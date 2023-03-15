using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartShare.Infrastructure.Migrations;

/// <inheritdoc />
public partial class madeUsersBlobNotRequired : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "UserName",
            table: "Users",
            newName: "Username");

        migrationBuilder.AlterColumn<byte[]>(
            name: "Blob",
            table: "Users",
            type: "varbinary(max)",
            nullable: true,
            oldClrType: typeof(byte[]),
            oldType: "varbinary(max)");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.RenameColumn(
            name: "Username",
            table: "Users",
            newName: "UserName");

        migrationBuilder.AlterColumn<byte[]>(
            name: "Blob",
            table: "Users",
            type: "varbinary(max)",
            nullable: false,
            defaultValue: new byte[0],
            oldClrType: typeof(byte[]),
            oldType: "varbinary(max)",
            oldNullable: true);
    }
}
