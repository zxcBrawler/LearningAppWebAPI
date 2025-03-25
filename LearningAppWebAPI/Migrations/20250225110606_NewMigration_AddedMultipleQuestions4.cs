using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigration_AddedMultipleQuestions4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultipleChoiceExercises_Exercises_Exercise_Id",
                table: "MultipleChoiceExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_MultipleChoiceExercises_MultipleChoiceExerciseId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_TextAnswerExercises_Exercises_Exercise_Id",
                table: "TextAnswerExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_TrueFalseExercises_Exercises_Exercise_Id",
                table: "TrueFalseExercises");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_Course_CourseId",
                table: "UserCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_UserCourse_User_UserId",
                table: "UserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCourse",
                table: "UserCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TrueFalseExercises",
                table: "TrueFalseExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TextAnswerExercises",
                table: "TextAnswerExercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultipleChoiceExercises",
                table: "MultipleChoiceExercises");

            migrationBuilder.RenameTable(
                name: "UserCourse",
                newName: "User_Course");

            migrationBuilder.RenameTable(
                name: "TrueFalseExercises",
                newName: "True_False_Exercises");

            migrationBuilder.RenameTable(
                name: "TextAnswerExercises",
                newName: "Text_Answer_Exercises");

            migrationBuilder.RenameTable(
                name: "MultipleChoiceExercises",
                newName: "Multiple_Choice_Exercises");

            migrationBuilder.RenameIndex(
                name: "IX_UserCourse_CourseId",
                table: "User_Course",
                newName: "IX_User_Course_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Course",
                table: "User_Course",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_True_False_Exercises",
                table: "True_False_Exercises",
                column: "Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Text_Answer_Exercises",
                table: "Text_Answer_Exercises",
                column: "Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Multiple_Choice_Exercises",
                table: "Multiple_Choice_Exercises",
                column: "Exercise_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Multiple_Choice_Exercises_Exercises_Exercise_Id",
                table: "Multiple_Choice_Exercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Multiple_Choice_Exercises_MultipleChoiceExerciseId",
                table: "Options",
                column: "MultipleChoiceExerciseId",
                principalTable: "Multiple_Choice_Exercises",
                principalColumn: "Exercise_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Text_Answer_Exercises_Exercises_Exercise_Id",
                table: "Text_Answer_Exercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_True_False_Exercises_Exercises_Exercise_Id",
                table: "True_False_Exercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Course_Course_CourseId",
                table: "User_Course",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Course_User_UserId",
                table: "User_Course",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Multiple_Choice_Exercises_Exercises_Exercise_Id",
                table: "Multiple_Choice_Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Multiple_Choice_Exercises_MultipleChoiceExerciseId",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Text_Answer_Exercises_Exercises_Exercise_Id",
                table: "Text_Answer_Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_True_False_Exercises_Exercises_Exercise_Id",
                table: "True_False_Exercises");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_Course_CourseId",
                table: "User_Course");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Course_User_UserId",
                table: "User_Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Course",
                table: "User_Course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_True_False_Exercises",
                table: "True_False_Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Text_Answer_Exercises",
                table: "Text_Answer_Exercises");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Multiple_Choice_Exercises",
                table: "Multiple_Choice_Exercises");

            migrationBuilder.RenameTable(
                name: "User_Course",
                newName: "UserCourse");

            migrationBuilder.RenameTable(
                name: "True_False_Exercises",
                newName: "TrueFalseExercises");

            migrationBuilder.RenameTable(
                name: "Text_Answer_Exercises",
                newName: "TextAnswerExercises");

            migrationBuilder.RenameTable(
                name: "Multiple_Choice_Exercises",
                newName: "MultipleChoiceExercises");

            migrationBuilder.RenameIndex(
                name: "IX_User_Course_CourseId",
                table: "UserCourse",
                newName: "IX_UserCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCourse",
                table: "UserCourse",
                columns: new[] { "UserId", "CourseId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_TrueFalseExercises",
                table: "TrueFalseExercises",
                column: "Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TextAnswerExercises",
                table: "TextAnswerExercises",
                column: "Exercise_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultipleChoiceExercises",
                table: "MultipleChoiceExercises",
                column: "Exercise_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultipleChoiceExercises_Exercises_Exercise_Id",
                table: "MultipleChoiceExercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Options_MultipleChoiceExercises_MultipleChoiceExerciseId",
                table: "Options",
                column: "MultipleChoiceExerciseId",
                principalTable: "MultipleChoiceExercises",
                principalColumn: "Exercise_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TextAnswerExercises_Exercises_Exercise_Id",
                table: "TextAnswerExercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TrueFalseExercises_Exercises_Exercise_Id",
                table: "TrueFalseExercises",
                column: "Exercise_Id",
                principalTable: "Exercises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_Course_CourseId",
                table: "UserCourse",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserCourse_User_UserId",
                table: "UserCourse",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
