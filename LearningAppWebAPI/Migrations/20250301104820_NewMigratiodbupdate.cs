using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigratiodbupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Is_Archived",
                table: "Course",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Is_Archived",
                table: "Course");
        }
    }
}
