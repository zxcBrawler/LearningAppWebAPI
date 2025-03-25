using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_AddedMultipleQuestions2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExerciseType",
                table: "Exercises");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "Discriminator",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TextAnswerExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "TrueFalseExercise_Exercise_Id",
                table: "Exercises");

            migrationBuilder.AddColumn<string>(
                name: "ExerciseType",
                table: "Exercises",
                type: "varchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
