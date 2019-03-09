using AutoFixture;
using AutoFixture.AutoMoq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace UT
{
    [ExcludeFromCodeCoverage]
    public abstract class BaseTest
    {
        protected Fixture baseFixture;

        protected virtual void SetUp()
        {
            baseFixture = new Fixture();
            baseFixture.Customize(new AutoMoqCustomization());

            baseFixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => baseFixture.Behaviors.Remove(b));
            baseFixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}
