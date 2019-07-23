using LightingSurvey.Common.Services;
using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.Controllers;
using LightingSurvey.MvcSite.Services;
using LightingSurvey.MvcSite.ViewModels.Survey;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LightingSurvey.Tests.MvcSite.Controllers
{
    public class SurveyControllerTests
    {
        private const string ExcellentName = "Richard Garside";
        private readonly DateTime FakeNow = new DateTime(2019, 7, 1);

        [Fact]
        public async Task TestStartCreatesNewResponseWhenNoCurrentResponseThenRedirects()
        {
            // Arrange
            var clientStorage = Substitute.For<IClientSideStorageService>();
            var dateTime = Substitute.For<IDateTimeService>();
            var repo = Substitute.For<ISurveyResponseRepository>();
            repo.Create().Returns(SurveyResponse.CreateNew(FakeNow));
            var controller = new SurveyController(clientStorage, dateTime, repo);

            // Act
            var result = await controller.Start();

            // Assert
            await repo.Received().Create();
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public async Task TestStartDoesNotCreatesNewResponseWhenCurrentResponseFoundThenRedirects()
        {
            // Arrange
            var clientStorage = Substitute.For<IClientSideStorageService>();
            var dateTime = Substitute.For<IDateTimeService>();
            var repo = Substitute.For<ISurveyResponseRepository>();
            repo.Create().Returns(SurveyResponse.CreateNew(FakeNow));
            repo.Find(Arg.Any<string>()).Returns(SurveyResponse.CreateNew(FakeNow.AddDays(-1)));

            var controller = new SurveyController(clientStorage, dateTime, repo);

            // Act
            var result = await controller.Start();

            // Assert
            await repo.DidNotReceive().Create();
            Assert.IsType<RedirectToActionResult>(result);
        }

        [Fact]
        public void TestQuestion1ShowsCurrentName()
        {
            // Arrange
            var response = SurveyResponse.CreateNew(FakeNow);
            response.Respondent.Name = ExcellentName;
            var clientStorage = Substitute.For<IClientSideStorageService>();
            var dateTime = Substitute.For<IDateTimeService>();
            var repo = Substitute.For<ISurveyResponseRepository>();

            var controller = new SurveyController(clientStorage, dateTime, repo)
            {
                CurrentResponse = response
            };

            // Act
            var result = controller.Question1();

            // Assert
            Assert.IsType<ViewResult>(result);
            var viewResult = result as ViewResult;
            Assert.IsType<QuestionPageViewModel<string>>(viewResult.Model);
            var model = viewResult.Model as QuestionPageViewModel<string>;
            Assert.Equal(ExcellentName, model.Question.Answer);
        }

        [Fact]
        public async Task TestQuestion1SavesCurrentName()
        {
            // Arrange
            var response = SurveyResponse.CreateNew(FakeNow);
            response.Respondent.Name = "Wrong name";
            var clientStorage = Substitute.For<IClientSideStorageService>();
            var dateTime = Substitute.For<IDateTimeService>();
            var repo = Substitute.For<ISurveyResponseRepository>();

            var controller = new SurveyController(clientStorage, dateTime, repo)
            {
                CurrentResponse = response
            };

            var questionAnswer = new NameQuestionViewModel
            {
                Answer = ExcellentName
            };

            // Act
            var result = await controller.Question1(questionAnswer);

            // Assert
            await repo.Received().SaveChanges();
            Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal(ExcellentName, controller.CurrentResponse.Respondent.Name);
        }
    }
}
