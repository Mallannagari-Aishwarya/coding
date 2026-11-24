using System;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
namespace cleanTeeth.Tests.Entities
{
    [TestClass]
    public class DentalOfficeTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            try
            {
                new DentalOffice(null!);

                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}