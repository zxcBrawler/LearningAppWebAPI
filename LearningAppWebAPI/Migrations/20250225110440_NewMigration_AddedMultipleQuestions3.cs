using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_AddedMultipleQuestions3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Exercises_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Exercises_TextAnswerExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Exercises_TrueFalseExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TextAnswerExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_TrueFalseExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Case_Sensitive",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "CorrectAnswerIndex",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Expected_Answer",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Hint",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "IsTrue",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OptionA",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OptionB",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OptionC",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "OptionD",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TextAnswerExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TrueFalseExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.CreateTable(
                name: "MultipleChoiceExercises",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "int", nullable: false),
                    CorrectAnswerIndex = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleChoiceExercises", x => x.Exercise_Id);
                    table.ForeignKey(
                        name: "FK_MultipleChoiceExercises_Exercises_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TextAnswerExercises",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "int", nullable: false),
                    Expected_Answer = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Case_Sensitive = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Hint = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextAnswerExercises", x => x.Exercise_Id);
                    table.ForeignKey(
                        name: "FK_TextAnswerExercises_Exercises_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TrueFalseExercises",
                columns: table => new
                {
                    Exercise_Id = table.Column<int>(type: "int", nullable: false),
                    IsTrue = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrueFalseExercises", x => x.Exercise_Id);
                    table.ForeignKey(
                        name: "FK_TrueFalseExercises_Exercises_Exercise_Id",
                        column: x => x.Exercise_Id,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MultipleChoiceExerciseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Options_MultipleChoiceExercises_MultipleChoiceExerciseId",
                        column: x => x.MultipleChoiceExerciseId,
                        principalTable: "MultipleChoiceExercises",
                        principalColumn: "Exercise_Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Options_MultipleChoiceExerciseId",
                table: "Options",
                column: "MultipleChoiceExerciseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropTable(
                name: "TextAnswerExercises");

            migrationBuilder.DropTable(
                name: "TrueFalseExercises");

            migrationBuilder.DropTable(
                name: "MultipleChoiceExercises");

            migrationBuilder.AddColumn<bool>(
                name: "Case_Sensitive",
                table: "Exercises",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CorrectAnswerIndex",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Exercises",
                type: "varchar(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Exercise_Id",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expected_Answer",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Hint",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsTrue",
                table: "Exercises",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OptionA",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptionB",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptionC",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "OptionD",
                table: "Exercises",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "TextAnswerExercise_Exercise_Id",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrueFalseExercise_Exercise_Id",
                table: "Exercises",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_Exercise_Id",
                table: "Exercises",
                column: "Exercise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TextAnswerExercise_Exercise_Id",
                table: "Exercises",
                column: "TextAnswerExercise_Exercise_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_TrueFalseExercise_Exercise_Id",
                table: "Exercises",
                column: "TrueFalseExercise_Exercise_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Exercises_Exercise_Id",
                table: "Exercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Exercises_TextAnswerExercise_Exercise_Id",
                table: "Exercises",
                column: "TextAnswerExercise_Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Exercises_TrueFalseExercise_Exercise_Id",
                table: "Exercises",
                column: "TrueFalseExercise_Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
