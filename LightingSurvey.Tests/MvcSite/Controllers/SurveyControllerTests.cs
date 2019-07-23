using LightingSurvey.Common.Services;
using LightingSurvey.Data.Models;
using LightingSurvey.Data.Repositories;
using LightingSurvey.MvcSite.Controllers;
using LightingSurvey.MvcSite.Services;
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
        [Fact]
        public async Task TestStartCreatesNewResponseWhenNoCurrentResponse()
        {
            // Arrange
            var now = new DateTime(2019, 7, 1);
            var clientStorage = Substitute.For<IClientSideStorageService>();
            var dateTime = Substitute.For<IDateTimeService>();
            var repo = Substitute.For<ISurveyResponseRepository>();
            repo.Create().Returns(SurveyResponse.CreateNew(now));
            var controller = new SurveyController(clientStorage, dateTime, repo);

            // Act
            var result = await controller.Start();

            // Assert
            Assert.IsType<RedirectToActionResult>(result);
            await repo.Received().Create();
        }
    }
}
