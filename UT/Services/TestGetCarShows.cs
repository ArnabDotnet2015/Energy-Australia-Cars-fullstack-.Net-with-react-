using Moq;
using NUnit.Framework;
using Domains.Enums;
using Domains.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UT.Services
{
    public class TestGetCarShows: CarShowServicetestConfig
    {
        [SetUp]
        public void Setup()
        {
            base.SetUp();
        }

        /// <summary>Returns the empty when no data returned from API asynchronous.</summary>
        /// <returns></returns>
        [Test]
        public async Task ReturnEmptyWhenNoDataReturnedFromApiAsync()
        {
            MockCarshowFacede.Setup(p => p.GetAllResponseAsync(It.IsAny<EntityTypes>()))
                .ReturnsAsync(() => new List<CarShow>());
            var result = await SystemUnderTest.GetCarShows();

            Assert.AreEqual(0, result.Count);
        }

        /// <summary>Returns the non empty when some data returned from API asynchronous.</summary>
        /// <returns></returns>
        [Test]
        public async Task ReturnNonEmptyWhenSomeDataReturnedFromApiAsync()
        {
            MockCarshowFacede.Setup(p => p.GetAllResponseAsync(It.IsAny<EntityTypes>()))
                .ReturnsAsync(() => TestCarShows);
            var result = await SystemUnderTest.GetCarShows();

            Assert.Greater(result.Count, 0);
        }
    }
}
