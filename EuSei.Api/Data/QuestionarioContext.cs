using EuSei.Api.Data.Entities;
using EuSei.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EuSei.Api.Data
{
    public class QuestionarioContext : DbContext
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        public QuestionarioContext(DbContextOptions<QuestionarioContext> options, IPasswordHasher<User> passwordHasher):base(options)
        {
            _passwordHasher = passwordHasher;
        }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Opcao> Opcaos { get; set; }
        public DbSet<Pergunta> Perguntas { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentQuestionario> StudentQuestionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var AdminUser = new User()
            {
                Id = 1,
                Nmae = "Aristides",
                Phone = "21988575367",
                Email = "arfioretti@gmail.com",
                Role = nameof(UserRole.Admin),
                IsAproved = true
            };
            AdminUser.PasswordHash = _passwordHasher.HashPassword(AdminUser, "123456");

            modelBuilder.Entity<User>().HasData(AdminUser);
        }
    }
}
