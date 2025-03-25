using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_AddedMultipleQuestions1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_Lesson_Lesson_Id",
                table: "Exercise");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercise_TypeExercise_Type_Exercise_Id",
                table: "Exercise");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise");

            migrationBuilder.RenameTable(
                name: "Exercise",
                newName: "Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_Type_Exercise_Id",
                table: "Exercises",
                newName: "IX_Exercises_Type_Exercise_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Exercise_Lesson_Id",
                table: "Exercises",
                newName: "IX_Exercises_Lesson_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Lesson_Lesson_Id",
                table: "Exercises",
                column: "Lesson_Id",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TypeExercise_Type_Exercise_Id",
                table: "Exercises",
                column: "Type_Exercise_Id",
                principalTable: "TypeExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Lesson_Lesson_Id",
                table: "Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TypeExercise_Type_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Exercises",
                table: "Exercises");

            migrationBuilder.RenameTable(
                name: "Exercises",
                newName: "Exercise");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_Type_Exercise_Id",
                table: "Exercise",
                newName: "IX_Exercise_Type_Exercise_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Exercises_Lesson_Id",
                table: "Exercise",
                newName: "IX_Exercise_Lesson_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Exercise",
                table: "Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_Lesson_Lesson_Id",
                table: "Exercise",
                column: "Lesson_Id",
                principalTable: "Lesson",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exercise_TypeExercise_Type_Exercise_Id",
                table: "Exercise",
                column: "Type_Exercise_Id",
                principalTable: "TypeExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
