using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
    [TestFixture, TestClass]
    public class ChipsTests
    {
        [Test, TestMethod]
        public void CreateValidChips()
        {
            Chips chips = (Chips) 6;

            Assert.AreEqual((Chips)6, chips);
        }

        [Test, TestMethod]
        public void CreateInvalidChips()
        {
            Assert.Catch<ArgumentOutOfRangeException>(delegate { var v = (Chips)(-6); });
        }
    }
}