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
    /// The new migration class
    /// </summary>
    [DbContext(typeof(AppDbContext))]
    [Migration("20250225094700_NewMigration1")]
    partial class NewMigration1
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

            modelBuilder.Entity("LearningAppAPI.Models.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

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

                    b.HasIndex("CourseId");

                    b.HasIndex("UID")
                        .IsUnique();

                    b.ToTable("Lesson");
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

            modelBuilder.Entity("LearningAppAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

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

            modelBuilder.Entity("LearningAppAPI.Models.Lesson", b =>
                {
                    b.HasOne("LearningAppAPI.Models.Course", "Course")
                        .WithMany("Lessons")
                        .HasForeignKey("CourseId");

                    b.Navigation("Course");
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

            modelBuilder.Entity("LearningAppAPI.Models.Course", b =>
                {
                    b.Navigation("Lessons");
                });

            modelBuilder.Entity("LearningAppAPI.Models.Role", b =>
                {
                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
