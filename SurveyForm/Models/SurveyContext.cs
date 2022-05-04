using Microsoft.EntityFrameworkCore;

namespace SurveyForm.Models
{
    public class SurveyContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }

        public DbSet<Survey> Surveys { get; set; }

        public DbSet<Answer> Answers { get; set; }
        
        public SurveyContext(DbContextOptions<SurveyContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}