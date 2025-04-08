﻿// <auto-generated />
using System;
using LearningAppWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LearningAppWebAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("LearningAppWebAPI.Models.BlacklistedAccessToken", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_token");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expiry_date");

                    b.Property<string>("Jti")
                        .IsRequired()
                        .HasMaxLength(450)
                        .HasColumnType("varchar(450)")
                        .HasColumnName("jti");

                    b.HasKey("Id");

                    b.HasIndex("ExpiryDate");

                    b.HasIndex("Jti")
                        .IsUnique();

                    b.ToTable("blacklisted_access_token");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Course", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_course");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("course_description");

                    b.Property<string>("CourseLanguageLevel")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("course_language_level");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("course_name");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("CreatedAt"));

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_archived");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("UpdatedAt"));

                    b.HasKey("Id");

                    b.ToTable("course");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Dictionary", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_dictionary");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DictionaryName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("dictionary_name");

                    b.Property<string>("ImageUrl")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("image_url");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("dictionary");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.DictionaryWord", b =>
                {
                    b.Property<int>("DictionaryId")
                        .HasColumnType("int")
                        .HasColumnName("dictionary_id");

                    b.Property<int>("WordId")
                        .HasColumnType("int")
                        .HasColumnName("word_id");

                    b.HasKey("DictionaryId", "WordId");

                    b.HasIndex("WordId");

                    b.ToTable("dictionary_words");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Exercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_exercise");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    b.Property<int>("LessonId")
                        .HasColumnType("int")
                        .HasColumnName("lesson_id");

                    b.Property<string>("QuestionDescription")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("question_description");

                    b.Property<string>("QuestionName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("question_name");

                    b.Property<int>("TypeExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("type_exercise_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    b.Property<int>("XpReward")
                        .HasColumnType("int")
                        .HasColumnName("xp_reward");

                    b.HasKey("Id");

                    b.HasIndex("LessonId");

                    b.HasIndex("TypeExerciseId");

                    b.ToTable("exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_lesson");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<long?>("CourseId")
                        .HasColumnType("bigint")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("created_at");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("CreatedAt"));

                    b.Property<string>("LessonDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson_description");

                    b.Property<string>("LessonName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("lesson_name");

                    b.Property<string>("Uid")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("uid");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("updated_at");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("UpdatedAt"));

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("Uid")
                        .IsUnique();

                    b.ToTable("lesson");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("exercise_id");

                    b.Property<int>("CorrectAnswerIndex")
                        .HasColumnType("int")
                        .HasColumnName("correct_answer_index");

                    b.HasKey("ExerciseId");

                    b.ToTable("multiple_choice_exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Option", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_option");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("MultipleChoiceExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("multiple_choice_exercise_id");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("text");

                    b.HasKey("Id");

                    b.HasIndex("MultipleChoiceExerciseId");

                    b.ToTable("option");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_token");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("expiry_date");

                    b.Property<string>("HashedToken")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("hashed_token");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_revoked");

                    b.Property<DateTime?>("RevokedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("revoked_at");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("refresh_token");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_role");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("RoleName")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("role_name");

                    b.HasKey("Id");

                    b.HasIndex("RoleName")
                        .IsUnique();

                    b.ToTable("role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = 0
                        },
                        new
                        {
                            Id = 2,
                            RoleName = 1
                        },
                        new
                        {
                            Id = 3,
                            RoleName = 2
                        });
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TextAnswerExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("exercise_id");

                    b.Property<bool>("CaseSensitive")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("case_sensitive");

                    b.Property<string>("ExpectedAnswer")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("expected_answer");

                    b.Property<string>("Hint")
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("hint");

                    b.HasKey("ExerciseId");

                    b.ToTable("text_answer_exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TrueFalseExercise", b =>
                {
                    b.Property<int>("ExerciseId")
                        .HasColumnType("int")
                        .HasColumnName("exercise_id");

                    b.Property<bool>("AnswerValue")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("answer_value");

                    b.HasKey("ExerciseId");

                    b.ToTable("true_false_exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TypeExercise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_type_exercise");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExerciseTypeDescription")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("exercise_type_description");

                    b.Property<int>("ExerciseTypeName")
                        .HasMaxLength(50)
                        .HasColumnType("int")
                        .HasColumnName("exercise_type_name");

                    b.HasKey("Id");

                    b.ToTable("type_exercise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ExerciseTypeDescription = "Text",
                            ExerciseTypeName = 0
                        },
                        new
                        {
                            Id = 2,
                            ExerciseTypeDescription = "MultipleChoice",
                            ExerciseTypeName = 1
                        },
                        new
                        {
                            Id = 3,
                            ExerciseTypeDescription = "TrueFalse",
                            ExerciseTypeName = 2
                        });
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id_user");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CurrentStreak")
                        .HasColumnType("int")
                        .HasColumnName("current_streak");

                    b.Property<int>("CurrentXp")
                        .HasColumnType("int")
                        .HasColumnName("current_xp");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(125)
                        .HasColumnType("varchar(125)")
                        .HasColumnName("email");

                    b.Property<bool>("IsRegistrationConfirmed")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_registration_confirmed");

                    b.Property<int>("Level")
                        .HasColumnType("int")
                        .HasColumnName("level");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("password_hash");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("profile_picture");

                    b.Property<DateTime>("RegistrationDate")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime(6)")
                        .HasColumnName("registration_date");

                    MySqlPropertyBuilderExtensions.UseMySqlComputedColumn(b.Property<DateTime>("RegistrationDate"));

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("username");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("user");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.UserCourse", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<long>("CourseId")
                        .HasColumnType("bigint")
                        .HasColumnName("course_id");

                    b.Property<float>("CourseProgress")
                        .HasColumnType("float")
                        .HasColumnName("course_progress");

                    b.Property<bool>("IsFinished")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("is_finished");

                    b.HasKey("UserId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("user_course");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Word", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_word");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("LanguageLevel")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("language_level");

                    b.Property<string>("PartOfSpeech")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("part_of_speech");

                    b.Property<string>("UsageExamples")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("usage_examples");

                    b.Property<string>("WordDefinition")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)")
                        .HasColumnName("word_definition");

                    b.Property<string>("WordPronunciation")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("word_pronunciation");

                    b.Property<string>("WordValue")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("word_value");

                    b.HasKey("Id");

                    b.HasIndex("WordValue")
                        .IsUnique();

                    b.ToTable("word");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            LanguageLevel = "C1",
                            PartOfSpeech = "Noun",
                            UsageExamples = "Her perseverance in the face of adversity was inspiring.",
                            WordDefinition = "steadfastness in doing something despite difficulty",
                            WordPronunciation = "pər-sə-ˈvir-ən(t)s",
                            WordValue = "perseverance"
                        },
                        new
                        {
                            Id = 2,
                            LanguageLevel = "B2",
                            PartOfSpeech = "Adjective",
                            UsageExamples = "The ephemeral nature of cherry blossoms makes them special.",
                            WordDefinition = "lasting for a very short time",
                            WordPronunciation = "i-ˈfem-rəl",
                            WordValue = "ephemeral"
                        },
                        new
                        {
                            Id = 3,
                            LanguageLevel = "A1",
                            PartOfSpeech = "Verb,Noun",
                            UsageExamples = "I run every morning.|The program runs smoothly.|He runs a successful business.",
                            WordDefinition = "move at a speed faster than walking",
                            WordPronunciation = "rən",
                            WordValue = "run"
                        },
                        new
                        {
                            Id = 4,
                            LanguageLevel = "A2",
                            PartOfSpeech = "Adjective,Adverb,Verb",
                            UsageExamples = "She's a fast runner.|The clock is running fast.|He fasted for three days.",
                            WordDefinition = "moving or capable of moving at high speed",
                            WordPronunciation = "fäst",
                            WordValue = "fast"
                        },
                        new
                        {
                            Id = 5,
                            LanguageLevel = "C2",
                            PartOfSpeech = "Noun",
                            UsageExamples = "Their meeting was pure serendipity.",
                            WordDefinition = "the occurrence of events by chance in a happy way",
                            WordPronunciation = "ser-ən-ˈdi-pə-tē",
                            WordValue = "serendipity"
                        });
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Dictionary", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.User", "User")
                        .WithMany("Dictionaries")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.DictionaryWord", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Dictionary", "Dictionary")
                        .WithMany()
                        .HasForeignKey("DictionaryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningAppWebAPI.Models.Word", "Word")
                        .WithMany()
                        .HasForeignKey("WordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dictionary");

                    b.Navigation("Word");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Exercise", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Lesson", "Lesson")
                        .WithMany("Exercises")
                        .HasForeignKey("LessonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningAppWebAPI.Models.TypeExercise", "TypeExercise")
                        .WithMany("Exercises")
                        .HasForeignKey("TypeExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lesson");

                    b.Navigation("TypeExercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Lesson", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Course", "Course")
                        .WithMany("Lesson")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Exercise", "Exercise")
                        .WithOne("MultipleChoiceExercise")
                        .HasForeignKey("LearningAppWebAPI.Models.MultipleChoiceExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Option", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.MultipleChoiceExercise", "MultipleChoiceExercise")
                        .WithMany("Options")
                        .HasForeignKey("MultipleChoiceExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MultipleChoiceExercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.RefreshToken", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TextAnswerExercise", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Exercise", "Exercise")
                        .WithOne("TextAnswerExercise")
                        .HasForeignKey("LearningAppWebAPI.Models.TextAnswerExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TrueFalseExercise", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Exercise", "Exercise")
                        .WithOne("TrueFalseExercise")
                        .HasForeignKey("LearningAppWebAPI.Models.TrueFalseExercise", "ExerciseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.User", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Role", "Role")
                        .WithMany("User")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.UserCourse", b =>
                {
                    b.HasOne("LearningAppWebAPI.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LearningAppWebAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Course", b =>
                {
                    b.Navigation("Lesson");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Exercise", b =>
                {
                    b.Navigation("MultipleChoiceExercise");

                    b.Navigation("TextAnswerExercise");

                    b.Navigation("TrueFalseExercise");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Lesson", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.MultipleChoiceExercise", b =>
                {
                    b.Navigation("Options");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.Role", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.TypeExercise", b =>
                {
                    b.Navigation("Exercises");
                });

            modelBuilder.Entity("LearningAppWebAPI.Models.User", b =>
                {
                    b.Navigation("Dictionaries");

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
