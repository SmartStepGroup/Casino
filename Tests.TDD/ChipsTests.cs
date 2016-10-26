using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
   [TestFixture]
   [TestClass]
   public class ChipsTests
   {
      [Test]
      [TestMethod]
      public void OneChipsLessTwoChip()
      {
         Chips one = (Chips)1;
         Chips two = (Chips)2;

         Assert.IsTrue(one < two);
      }

      [Test]
      [TestMethod]
      public void CreateInvalidChips()
      {
         Assert.Catch<ArgumentOutOfRangeException>(delegate
         {
            var v = (Chips) (-6);
         });
      }

      [Test]
      [TestMethod]
      public void CreateValidChips()
      {
         var chips = (Chips) 6;

         Assert.AreEqual((Chips) 6, chips);
      }
   }
}