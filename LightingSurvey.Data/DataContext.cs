using LightingSurvey.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace LightingSurvey.Data
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions options) : base(options) { }

        private const string dbUsername = "website";
        private const string dbPassword = "2019-07-21_W*bsite$......";
        private readonly string _connectionString = $"Server=tcp:lightingsurveydb.database.windows.net,1433;Initial Catalog=LightingSurvey2019;Persist Security Info=False;User ID={dbUsername};Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public DbSet<SurveyResponse> Responces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString, options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.OwnsOne(response => response.Dates);
            });

            modelBuilder.Entity<SurveyResponse>(entity =>
            {
                entity.OwnsOne(response => response.Respondent);
            });

            modelBuilder.Entity<SurveyRespondent>(entity =>
            {
                entity.OwnsOne(respondent => respondent.Address);
            });
        }
    }
}