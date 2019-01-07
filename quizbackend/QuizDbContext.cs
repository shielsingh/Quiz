using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using quizbackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace quizbackend
{
    public class QuizDbContext : IdentityDbContext<IdentityUser>
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) {}

        public DbSet<Question> Questions { get; set; }
        public DbSet<Quiz> Quizzes { get; set; }
    }
}
