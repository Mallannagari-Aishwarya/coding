using System;
using System.Xml.Serialization;
using CleanTeeth.Domain.ValueObjects;
using CleanTeeth.Domain.Entities;
using CleanTeeth.Domain.Exceptions;
namespace CleanTeeth.Tests.Entities
{
    [TestClass]
    public class DentistTests
    {
        [TestMethod]
        public void Constructor_NullName_Throws()
        {
            var email=new Email("fillepe@example.com");
            Assert.ThrowsExactly<BusinessRuleException>(()=>new Dentist(null!,email));
        }

        [TestMethod]
        public void Constructor_NullEmail_Throws()
        {
            try
            {
                new Dentist("Felipe", email: null!);

                Assert.Fail("BusinessRuleException was expected.");
            }
            catch (BusinessRuleException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Constructor_ValidDentist_NoExceptions()
        {
            var email = new Email("felipe@example.com");
            var dentist = new Dentist("Felipe", email);

            /*Assert.AreEqual("Felipe", dentist.Name);
            Assert.AreEqual(email, dentist.Email);
            Assert.AreNotEqual(Guid.Empty, dentist.Id);*/
        }

    }
}