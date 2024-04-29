using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JuliaPhotoServer.Migrations
{
    /// <inheritdoc />
    public partial class addDescriptionToPhotoSetType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("Description", "PhotoSetTypes", type: "nvarchar(max)", nullable: true);

            /*migrationBuilder.DropTable(
                name: "PhotoSetTypes");*/
            /*migrationBuilder.CreateTable(
                name: "PhotoSetTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoSetTypes", x => x.Id);
                });*/

            /*migrationBuilder.CreateTable(
                name: "PhotoSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PhotoSetTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhotoSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PhotoSets_PhotoSetTypes_PhotoSetTypeId",
                        column: x => x.PhotoSetTypeId,
                        principalTable: "PhotoSetTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Filename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Alt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoSetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photos_PhotoSets_PhotoSetId",
                        column: x => x.PhotoSetId,
                        principalTable: "PhotoSets",
                        principalColumn: "Id");
                });
            */

            /*migrationBuilder.CreateIndex(
                name: "IX_Photos_PhotoSetId",
                table: "Photos",
                column: "PhotoSetId");*/

            /*migrationBuilder.CreateIndex(
                name: "IX_PhotoSets_PhotoSetTypeId",
                table: "PhotoSets",
                column: "PhotoSetTypeId");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photos");

            migrationBuilder.DropTable(
                name: "PhotoSets");

            migrationBuilder.DropTable(
                name: "PhotoSetTypes");
        }
    }
}
