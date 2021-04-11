using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using netcore_mvc.Data;
using Services;
using Common.DTO;
using System.Threading.Tasks;
using WebUI.Controllers;
using Xunit;

namespace Tests
{
    public class SettingControllerTest
    {
        private DbContextOptions<ApplicationDbContext> ContextOptions { get; }

        public SettingControllerTest()
        {
            ContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                                       .UseInMemoryDatabase("TestDatabase")
                                       .Options;
            SeedAsync().Wait();
        }

        private async Task SeedAsync()
        {
            await using var context = new ApplicationDbContext(ContextOptions);

            if (await context.Settings.AnyAsync() == false)
            {
                await context.Settings.AddAsync(new Data.Models.Setting
                {
                    Id = 1,
                    Key = "someKey",
                    Value = "someValue"
                });
            }

            await context.SaveChangesAsync();
        }

        [Fact(DisplayName = "Index Action Should Return An IEnumerable")]
        public void IndexActionShouldReturnAnIEnumerable()
        {
            // ARRANGE
            using var context = new ApplicationDbContext(ContextOptions);
            var mockService = new SettingService(new GenericRepository<Setting>(context), new Mock<ILogger<SettingService>>().Object);
            var mockController = new SettingController(mockService);

            // ACT
            var taskResult = (ViewResult)mockController.Index().Result;

            // ASSERT
            Assert.NotNull(taskResult);
            Assert.NotNull(taskResult.Model);
            Assert.True(string.IsNullOrEmpty(taskResult.ViewName) || taskResult.ViewName == "Index");
        }

        [Fact(DisplayName = "Successfully Create Action Should Return Redirect To Action")]
        public void SuccessfullyCreateActionShouldReturnRedirectToAction()
        {
            // ARRANGE
            SettingDto fakeSetting = new()
            {
                Key = "fakeKey",
                Value = "fakeValue"
            };

            using var context = new ApplicationDbContext(ContextOptions);
            var mockService = new SettingService(new GenericRepository<Setting>(context), new Mock<ILogger<SettingService>>().Object);
            var mockController = new SettingController(mockService);

            // ACT
            var taskResult = (RedirectToActionResult)mockController.Create(fakeSetting).Result;

            // ASSERT

            Assert.Equal("Index", taskResult.ActionName);
        }

        [Fact(DisplayName = "Duplicated Key on  Create Action Should Return Bad Request")]
        public void DuplicatedKeyonCreateActionShouldReturnBadRequest()
        {
            // ARRANGE
            SettingDto duplicatedSetting = new()
            {
                Key = "someKey",
                Value = "someValue"
            };

            using var context = new ApplicationDbContext(ContextOptions);
            var mockService = new SettingService(new GenericRepository<Setting>(context), new Mock<ILogger<SettingService>>().Object);
            var mockController = new SettingController(mockService);

            // ACT
            var taskResult = (ViewResult)mockController.Create(duplicatedSetting).Result;

            // ASSERT

            Assert.True(taskResult.ViewData.ModelState.ErrorCount > 0);
            Assert.True(taskResult.ViewData.ModelState.ContainsKey("400"));
        }
    }
}
