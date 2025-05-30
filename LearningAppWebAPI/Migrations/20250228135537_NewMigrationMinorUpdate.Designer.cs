// <auto-generated />
using System;
using LearningAppWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    /// <summary>
    /// The new migration minor update class
    /// </summary>
    [DbContext(typeof(AppDbContext))]
    [Migration("20250228135537_NewMigrationMinorUpdate")]
    partial class NewMigrationMinorUpdate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LearningAppAPI.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Course_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Course_Language_Level")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Course_Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)");

                    b.Property<DateTime>("Created_At")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Updated_At")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Lesson_Id")
                        .HasColumnType("int");

                    b.Property<string>("Question_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Question_Text")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Type_Exercise_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("XP_Reward")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Lesson_Id");

                    b.HasIndex("Type_Exercise_Id");

                    b.ToTable("Exercises");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Course_Id")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created_At")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Lesson_Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Lesson_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("UID")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime?>("Updated_At")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("Course_Id");

                    b.HasIndex("UID")
                        .IsUnique();

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("LearningAppAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.Property<int>("Exercise_Id")
                        .HasColumnType("int");

                    b.Property<int>("CorrectAnswerIndex")
                        .HasColumnType("int");

                    b.HasKey("Exercise_Id");

                    b.ToTable("Multiple_Choice_Exercises");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MultipleChoiceExerciseId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceExerciseId");

                    b.ToTable("Options");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Role_Name")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Role_Name")
                        .IsUnique();

                    b.ToTable("Role");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TextAnswerExercise", b =>
                {
                    b.Property<int>("Exercise_Id")
                        .HasColumnType("int");

                    b.Property<bool>("Case_Sensitive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Expected_Answer")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Hint")
                        .HasColumnType("longtext");

                    b.HasKey("Exercise_Id");

                    b.ToTable("Text_Answer_Exercises");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TrueFalseExercise", b =>
                {
                    b.Property<int>("Exercise_Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsTrue")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Exercise_Id");

                    b.ToTable("True_False_Exercises");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TypeExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Exercise_Type_Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Exercise_Type_Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Type_Exercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Current_XP")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("Password_Hash")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Profile_Picture")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("Registration_Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Role_Id")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Role_Id");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("LearningAppAPI.Models.UserCourse", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<float>("Course_Progress")
                        .HasColumnType("float");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("User_Course");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Exercise", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Lesson", "Lesson")
                        .WithMany("Exercises")
                        .HasForeignKey("Lesson_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningAppAPI.Models.TypeExercise", "TypeExercise")
                        .WithMany("Exercises")
                        .HasForeignKey("Type_Exercise_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("TypeExercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Lesson", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Course", "Course")
                        .WithMany("Lesson")
                        .HasForeignKey("Course_Id");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LearningAppAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Exercise", "Exercise")
                        .WithOne("MultipleChoiceExercise")
                        .HasForeignKey("LearningAppAPI.Models.MultipleChoiceExercise", "Exercise_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Option", b =>
                {
                    b.HasOne("LearningAppAPI.Models.MultipleChoiceExercise", "MultipleChoiceExercise")
                        .WithMany("Options")
                        .HasForeignKey("MultipleChoiceExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultipleChoiceExercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TextAnswerExercise", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Exercise", "Exercise")
                        .WithOne("TextAnswerExercise")
                        .HasForeignKey("LearningAppAPI.Models.TextAnswerExercise", "Exercise_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TrueFalseExercise", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Exercise", "Exercise")
                        .WithOne("TrueFalseExercise")
                        .HasForeignKey("LearningAppAPI.Models.TrueFalseExercise", "Exercise_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.User", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("Role_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LearningAppAPI.Models.UserCourse", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningAppAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Course", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Exercise", b =>
                {
                    b.Navigation("MultipleChoiceExercise");

                    b.Navigation("TextAnswerExercise");

                    b.Navigation("TrueFalseExercise");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Lesson", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("LearningAppAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppAPI.Models.TypeExercise", b =>
                {
                    b.Navigation("Exercises");
                });
#pragma warning restore 612, 618
        }
    }
}
