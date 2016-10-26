using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
    [TestFixture, TestClass]
    public class BetTests
    {
        [Test, TestMethod]
        public void CreateBet()
        {
            Bet bet = new Bet((Chips)1, (Score)2);

            Assert.AreEqual((Chips)1, bet.Chips);
            Assert.AreEqual((Score)2, bet.Score);
        }
    }
}