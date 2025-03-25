using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_AddedMultipleQuestions5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_TypeExercise_Type_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TypeExercise",
                table: "TypeExercise");

            migrationBuilder.RenameTable(
                name: "TypeExercise",
                newName: "Type_Exercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Type_Exercise",
                table: "Type_Exercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_Type_Exercise_Type_Exercise_Id",
                table: "Exercises",
                column: "Type_Exercise_Id",
                principalTable: "Type_Exercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_Type_Exercise_Type_Exercise_Id",
                table: "Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Type_Exercise",
                table: "Type_Exercise");

            migrationBuilder.RenameTable(
                name: "Type_Exercise",
                newName: "TypeExercise");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TypeExercise",
                table: "TypeExercise",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_TypeExercise_Type_Exercise_Id",
                table: "Exercises",
                column: "Type_Exercise_Id",
                principalTable: "TypeExercise",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
