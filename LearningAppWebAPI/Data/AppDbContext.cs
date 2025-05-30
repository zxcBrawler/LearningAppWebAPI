
using System.Text.Json;
using LearningAppWebAPI.Models;
using LearningAppWebAPI.Models.Enum;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Alachisoft.NCache.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace LearningAppWebAPI.Data
{
   
    /// <summary>
    /// The app db context class
    /// </summary>
    /// <seealso cref="DbContext"/>
    public class AppDbContext(DbContextOptions<AppDbContext> options, IMemoryCache memoryCache) : DbContext(options)
    {
        /// <summary>
        /// Gets or sets the value of the user
        /// </summary>
        public DbSet<User> User { get; set; }
        /// <summary>
        /// Gets or sets the value of the role
        /// </summary>
        public DbSet<Role> Role { get; set; }
        /// <summary>
        /// Gets or sets the value of the course
        /// </summary>
        public DbSet<Course> Course { get; set; }
        /// <summary>
        /// Gets or sets the value of the lesson
        /// </summary>
        public DbSet<Lesson> Lesson { get; set; }
        /// <summary>
        /// Gets or sets the value of the user course
        /// </summary>
        public DbSet<UserCourse> UserCourse { get; set; }
        /// <summary>
        /// Gets or sets the value of the exercises
        /// </summary>
        public DbSet<Exercise> Exercises { get; set; }
        /// <summary>
        /// Gets or sets the value of the multiple choice exercises
        /// </summary>
        public DbSet<MultipleChoiceExercise> MultipleChoiceExercises { get; set; }
        /// <summary>
        /// Gets or sets the value of the true false exercises
        /// </summary>
        public DbSet<TrueFalseExercise> TrueFalseExercises { get; set; }
        /// <summary>
        /// Gets or sets the value of the text answer exercises
        /// </summary>
        public DbSet<TextAnswerExercise> TextAnswerExercises { get; set; }
        /// <summary>
        /// Gets or sets the value of the options
        /// </summary>
        public DbSet<Option> Options { get; set; }
        /// <summary>
        /// Gets or sets the value of the type exercise
        /// </summary>
        public DbSet<TypeExercise> TypeExercise { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Dictionary> Dictionary { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<DictionaryWord> DictionaryWord { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<Word> Word { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<RefreshToken> RefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DbSet<BlacklistedAccessToken> BlacklistedAccessTokens { get; set; }

        /// <summary>
        /// Ons the model creating using the specified model builder
        /// </summary>
        /// <param name="modelBuilder">The model builder</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlacklistedAccessToken>()
                .HasIndex(t => t.Jti)
                .IsUnique(); 

            modelBuilder.Entity<BlacklistedAccessToken>()
                .HasIndex(t => t.ExpiryDate);  
            modelBuilder.Entity<User>()
            .HasOne(u => u.Role)
            .WithMany(r => r.User)
            .HasForeignKey(u => u.RoleId);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(u => u.RoleName)
                .IsUnique();

            modelBuilder.Entity<Lesson>()
                .HasIndex(l => l.Uid)
                .IsUnique();
            
            modelBuilder.Entity<Word>()
                .HasIndex(u => u.WordValue)
                .IsUnique();
            
            modelBuilder.Entity<Lesson>()
               .HasOne(u => u.Course)
               .WithMany(r => r.Lesson)
               .HasForeignKey(u => u.CourseId);

            modelBuilder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId);
            
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
            
            modelBuilder.Entity<Dictionary>()
                .HasMany(d => d.Words)
                .WithMany(w => w.Dictionaries)
                .UsingEntity<DictionaryWord>(
                    j => j
                        .HasOne(uc => uc.Word)
                        .WithMany()
                        .HasForeignKey(uc => uc.WordId),
                    j => j
                        .HasOne(uc => uc.Dictionary)
                        .WithMany()
                        .HasForeignKey(uc => uc.DictionaryId),
                    j =>
                    {
                        j.HasKey(uc => new { uc.DictionaryId, uc.WordId });
                    });
            
            modelBuilder.Entity<MultipleChoiceExercise>(entity =>
            {
                entity.HasKey(uc => uc.ExerciseId);
                entity.HasMany(e => e.Options)
                     .WithOne(o => o.MultipleChoiceExercise)
                     .HasForeignKey(o => o.MultipleChoiceExerciseId)
                     .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.MultipleChoiceExercise)
                    .HasForeignKey<MultipleChoiceExercise>(mce => mce.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<TrueFalseExercise>(entity =>
            {
                entity.HasKey(uc => uc.ExerciseId);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.TrueFalseExercise)
                    .HasForeignKey<TrueFalseExercise>(mce => mce.ExerciseId);

            });
            
            modelBuilder.Entity<TextAnswerExercise>(entity =>
            {
                entity.HasKey(uc => uc.ExerciseId);
                entity.HasOne(mce => mce.Exercise)
                    .WithOne(e => e.TextAnswerExercise)
                    .HasForeignKey<TextAnswerExercise>(mce => mce.ExerciseId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.TypeExercise)
                .WithMany(te => te.Exercises)
                .HasForeignKey(e => e.TypeExerciseId);

            modelBuilder.Entity<Exercise>()
                .HasOne(e => e.Lesson)
                .WithMany(l => l.Exercises)
                .HasForeignKey(e => e.LessonId);
            
            modelBuilder.Entity<Dictionary>()
                .HasOne(e => e.User)
                .WithMany(l => l.Dictionaries)
                .HasForeignKey(e => e.UserId);
            
            modelBuilder.Entity<Role>()
                .Property(e => e.RoleName)
                .HasConversion<int>();
   
            
            modelBuilder.Entity<Role>().HasData(
                Enum.GetValues<TypeRoleEnum>()
                    .Select(e => new Role()
                    {
                        Id = (int)e + 1,
                        RoleName = e,
                    })
            );
        }
    }
}
