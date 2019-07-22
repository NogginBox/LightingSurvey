using LightingSurvey.Data;
using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace LightingSurvey.Tests.Data.Repositories
{
    public class SurveyResponseRepositoryTests
    {
        [Fact]
        public async Task CreateSetsIdExternalAndAddsToContext()
        {
            // Arrange
            var options = CreateInMemoryDbContextOptions("CreateSetsIdExternalAndAddsToContext");

            // Insert seed data into the database using one instance of the context
            using (var context = new DataContext(options))
            {
                context.Responces.Add(new SurveyResponse { PerceivedBrightnessLevel = 6 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DataContext(options))
            {
                // Arrange repository
                var repository = new SurveyResponseRepository(context);

                // Act
                var newSurveyResponse = await repository.Create();
                await repository.SaveChanges();

                // Assert
                Assert.Equal(2, await context.Responces.CountAsync());
                Assert.NotNull(newSurveyResponse.IdExternal);
            }
        }

        [Fact]
        public async Task FindFindsUsingExternalId()
        {
            // Arrange
            var options = CreateInMemoryDbContextOptions("CreateSetsIdExternalAndAddsToContext");

            // Insert seed data into the database using one instance of the context
            using (var context = new DataContext(options))
            {
                context.Responces.Add(new SurveyResponse { IdExternal = "id1", PerceivedBrightnessLevel = 6 });
                context.Responces.Add(new SurveyResponse { IdExternal = "id2", PerceivedBrightnessLevel = 7 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new DataContext(options))
            {
                // Arrange repository
                var repository = new SurveyResponseRepository(context);

                // Act
                var surveyResponse = await repository.Find("id2");
                await repository.SaveChanges();

                // Assert
                Assert.Equal((ushort?)7, surveyResponse.PerceivedBrightnessLevel);
            }
        }


        private DbContextOptions<DataContext> CreateInMemoryDbContextOptions(string dbDame)
        {
            return new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: dbDame)
                .Options;
        }
    }
}
