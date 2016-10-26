using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
   [TestFixture]
   [TestClass]
   public class CasinoTests
   {
      [Test]
      [TestMethod]
      public void Bet_DivisibleBy5ChipsBetRequest_BetHasBeenCreated()
      {
         var casino = new Casino();
         var betRequest = new BetRequest((Chips) 10, (Score) 1);

         var bet = casino.Bet(betRequest);

         Assert.AreEqual((Chips) 10, bet.Chips);
         Assert.AreEqual((Score) 1, bet.Score);
      }

      [Test]
      [TestMethod]
      public void Bet_DivisibleBy5ChipsBetRequest_ThrowsArgumentException()
      {
         var casino = new Casino();
         var betRequest = new BetRequest((Chips) 7, (Score) 1);

         Assert.Catch<ArgumentException>(() => casino.Bet(betRequest));
      }
   }
}