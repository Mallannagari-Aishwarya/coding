using System;
using CleanTeeth.Domain.Exceptions;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.ValueObjects;
namespace cleanTeeth.Tests.Entities
{
    [TestClass]
    public class PatientTests
    {
        
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            var email = new Email("felipe@example.com");
            try{
                new Patient(null!, email);
                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            try{
                new Patient("Felipe", email: null!);
                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Constructor_ValidPatient_NoExceptions()
        {
            var email = new Email("felipe@example.com");
            new Patient("Felipe", email);
        }
    }
}