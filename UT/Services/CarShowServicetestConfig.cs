using AutoFixture;
using Contracts;
using Domains.ViewModels;
using Moq;
using NUnit.Framework;
using Services;
using System.Collections.Generic;
using UT;

namespace UT.Services
{
    public class CarShowServicetestConfig : BaseTest
    {
        protected List<CarShow> TestCarShows { get; set; }
        protected Mock<IHelperFacade<CarShow>> mockCarshowFacede { get; set; }
        protected CarShowService SystemUnderTest { get; set; }

        [SetUp]
        public void Setup()
        {
            base.SetUp();
            TestCarShows = new List<CarShow>();
            TestCarShows.AddRange(baseFixture.CreateMany<CarShow>(3));
            mockCarshowFacede = new Mock<IHelperFacade<CarShow>>();
            SystemUnderTest = new CarShowService(mockCarshowFacede.Object);
        }
    }
}