using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DziennikSportowca.EntityFramework.Migrations
{
    public partial class tExerciseAndSchDictionary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "schDictionaries");

            migrationBuilder.EnsureSchema(
                name: "schExercise");

            migrationBuilder.CreateTable(
                name: "tDictionaries",
                schema: "schDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDictionaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tDictionaryItems",
                schema: "schDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    DictionaryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDictionaryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tDictionaryItems_tDictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalSchema: "schDictionaries",
                        principalTable: "tDictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tDictionaryItemName",
                schema: "schDictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Culture = table.Column<string>(nullable: true),
                    DictionaryItemId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tDictionaryItemName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tDictionaryItemName_tDictionaryItems_DictionaryItemId",
                        column: x => x.DictionaryItemId,
                        principalSchema: "schDictionaries",
                        principalTable: "tDictionaryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tExercise",
                schema: "schExercise",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ActivityTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tExercise_tDictionaryItems_ActivityTypeId",
                        column: x => x.ActivityTypeId,
                        principalSchema: "schDictionaries",
                        principalTable: "tDictionaryItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tDictionaryItemName_DictionaryItemId",
                schema: "schDictionaries",
                table: "tDictionaryItemName",
                column: "DictionaryItemId");

            migrationBuilder.CreateIndex(
                name: "IX_tDictionaryItems_DictionaryId",
                schema: "schDictionaries",
                table: "tDictionaryItems",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_tExercise_ActivityTypeId",
                schema: "schExercise",
                table: "tExercise",
                column: "ActivityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tDictionaryItemName",
                schema: "schDictionaries");

            migrationBuilder.DropTable(
                name: "tExercise",
                schema: "schExercise");

            migrationBuilder.DropTable(
                name: "tDictionaryItems",
                schema: "schDictionaries");

            migrationBuilder.DropTable(
                name: "tDictionaries",
                schema: "schDictionaries");
        }
    }
}
