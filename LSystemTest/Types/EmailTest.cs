using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LSystem.Types;

namespace LSystemTest.Types
{
    [TestClass]
    public class EmailTest
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            Email email1 = new Email();
            Email email2 = new Email();

            Assert.AreEqual(email1, email2);
            Assert.IsTrue(email1 == email2);
            Assert.IsFalse(email1 != email2);
        }

        [TestMethod]
        public void ConstructorEqualAddresses()
        {
            Email email1 = new Email("email@valid.com");
            Email email2 = new Email("email@valid.com");

            Assert.AreEqual(email1, email2);
            Assert.IsTrue(email1 == email2);
            Assert.IsFalse(email1 != email2);
        }

        [TestMethod]
        public void ConstructorDifferentAddresses()
        {
            Email email1 = new Email("firstemail@valid.com");
            Email email2 = new Email("secondemail@valid.com");

            Assert.AreNotEqual(email1, email2);
            Assert.IsFalse(email1 == email2);
            Assert.IsTrue(email1 != email2);
        }

        [TestMethod]
        public void InvalidAddress()
        {
            Email email = new Email("invalid@.com");
            Assert.IsFalse(email.IsValid);
        }

        [TestMethod]
        public void ValidAddress()
        {
            Email email = new Email("   valid@valid.com   ");
            Assert.IsTrue(email.IsValid);
        }

        [TestMethod]
        public void NullAddress()
        {            
            Assert.ThrowsException<ArgumentException>(() => 
                {
                    Email email = new Email(null);
                }, 
                "Email address cannot be set to null");
        }

        [TestMethod]
        public void ToStringTest()
        {
            Email email = new Email("valid@email.com");
            Assert.IsTrue(email.ToString() == "valid@email.com");
        }
    }
}
