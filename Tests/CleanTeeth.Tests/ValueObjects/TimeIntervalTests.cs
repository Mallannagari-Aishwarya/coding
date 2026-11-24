using System;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cleanTeeth.Tests.ValueObjects
{
    [TestClass]
    public class TimeintervalTests
    {
        [TestMethod]
        public void Constructor_StartIsAfterEnd_Throws()
        {
            
                //new TimeInterval(DateTime.UtcNow,DateTime.UtcNow.AddDays(-1));
                var start = DateTime.UtcNow;
                var end = DateTime.UtcNow.AddDays(-1);

                Assert.ThrowsExactly<BusinessRuleException>(() => new TimeInterval(start, end));

        }
        [TestMethod]
        public void constructor_ValidTimeInterval_NoException()
        {
            new TimeInterval(DateTime.UtcNow,DateTime.UtcNow.AddHours(1));
        }
    }
}