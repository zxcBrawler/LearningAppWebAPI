
using LearningAppWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LearningAppWebAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<UserCourse> User_Course { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<MultipleChoiceExercise> Multiple_Choice_Exercises { get; set; }
        public DbSet<TrueFalseExercise> True_False_Exercises { get; set; }
        public DbSet<TextAnswerExercise> Text_Answer_Exercises { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<TypeExercise> Type_Exercise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.User)
            .HasForeignKey(u => u.Role_Id);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.Role_Name)
                .IsUnique();

            modelBuilder.Entity<Lesson>()
                .HasIndex(l => l.UID)
                .IsUnique();

            modelBuilder.Entity<Lesson>()
               .HasOne(u => u.Course)
               .WithMany(r => r.Lesson)
               .HasForeignKey(u => u.Course_Id);

            modelBuilder.Entity<User>()
                 .HasMany(u => u.Courses)
                 .WithMany(c => c.Users)
                 .UsingEntity<UserCourse>(
                     j => j
                         .HasOne(uc => uc.Course)
                         .WithMany()
                         .HasForeignKey(uc => uc.CourseId),
                     j => j
                         .HasOne(uc => uc.User)
                         .WithMany()
                         .HasForeignKey(uc => uc.UserId),
                     j =>
                     {
                         j.HasKey(uc => new { uc.UserId, uc.CourseId });
                     });

            modelBuilder.Entity<MultipleChoiceExercise>(entity =>
            {
                entity.HasKey(uc => uc.Exercise_Id);
                entity.HasMany(e => e.Options)
                     .WithOne(o => o.MultipleChoiceExercise)
                     .HasForeignKey(o => o.MultipleChoiceExerciseId)
                     .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.MultipleChoiceExercise)
                    .HasForeignKey<MultipleChoiceExercise>(mce => mce.Exercise_Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<TrueFalseExercise>(entity =>
            {
                entity.HasKey(uc => uc.Exercise_Id);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.TrueFalseExercise)
                    .HasForeignKey<TrueFalseExercise>(mce => mce.Exercise_Id);

            });

            modelBuilder.Entity<TextAnswerExercise>(entity =>
            {
                entity.HasKey(uc => uc.Exercise_Id);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.TextAnswerExercise)
                    .HasForeignKey<TextAnswerExercise>(mce => mce.Exercise_Id)
                    .OnDelete(DeleteBehavior.Cascade);
            });




            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.TypeExercise)
                .WithMany(te => te.Exercises)
                .HasForeignKey(e => e.Type_Exercise_Id);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Lesson)
                .WithMany(l => l.Exercises)
                .HasForeignKey(e => e.Lesson_Id);


        }
    }
}
