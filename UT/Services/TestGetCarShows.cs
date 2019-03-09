using AutoFixture;
using Domains.Enums;
using Domains.ViewModels;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
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

        [Test]
        public async Task ReturnEmptyWhenNoDataReturnedFromApiAsync()
        {
            mockCarshowFacede.Setup(p => p.GetAllResponseAsync(It.IsAny<EntityTypes>()))
                .ReturnsAsync(() => new List<CarShow>());
            var result = await SystemUnderTest.GetCarShows();

            Assert.AreEqual(0, result.Count);
        }

        [Test]
        public async Task ReturnNonEmptyWhenSomeDataReturnedFromApiAsync()
        {
            mockCarshowFacede.Setup(p => p.GetAllResponseAsync(It.IsAny<EntityTypes>()))
                .ReturnsAsync(() => TestCarShows);
            var result = await SystemUnderTest.GetCarShows();

            Assert.Greater(result.Count, 0);
        }
    }
}
