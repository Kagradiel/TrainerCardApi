using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainerCardBackEnd.Migrations
{
    /// <inheritdoc />
    public partial class PokeTrainerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Birth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Region = table.Column<short>(type: "smallint", nullable: false),
                    City = table.Column<short>(type: "smallint", nullable: false),
                    Type = table.Column<short>(type: "smallint", nullable: false),
                    Photo = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PokeBoxes",
                columns: table => new
                {
                    BoxId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PokemonsIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrainerId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokeBoxes", x => x.BoxId);
                    table.ForeignKey(
                        name: "FK_PokeBoxes_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PokeBoxes_TrainerId",
                table: "PokeBoxes",
                column: "TrainerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokeBoxes");

            migrationBuilder.DropTable(
                name: "Trainers");
        }
    }
}
