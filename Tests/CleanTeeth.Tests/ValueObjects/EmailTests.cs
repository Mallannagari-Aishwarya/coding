using System;
using CleanTeeth.Domain.ValueObjects;
using CleanTeeth.Domain.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace cleanTeeth.Tests.ValueObjects
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            try
            {
                new Email(null!);

                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Constructor_EmailWithoutAt_Throws()
        {
            try
            {
                new Email("johndoedomain.com");

                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Constructor_ValidEmail_NoExceptions()
        {
            new Email("fillipe@example.com");
        }
    }
}