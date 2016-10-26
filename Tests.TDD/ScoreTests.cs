using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
    [TestFixture, TestClass]
    public class ScoreTests
    {
        [Test, TestMethod]
        public void CreateValidScore()
        {
            Score Score = (Score) 6;

            Assert.AreEqual((Score)6, Score);
        }

        [Test, TestMethod]
        public void CreateInvalidScore()
        {
            Assert.Catch<ArgumentOutOfRangeException>(delegate { var v = (Score) (-6); });
        }
    }
}