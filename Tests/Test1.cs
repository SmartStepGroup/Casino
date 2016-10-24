using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Default_CreatePlayer_0Chips()
        {
            var player = new Player();

            Assert.AreEqual(0, player.Chips);
        }

        [Test]
        public void BuyChips_1_Have1()
        {
            var player = new Player();
            player.BuyChips(1);

            Assert.AreEqual(1, player.Chips);
        }

        [Test]
        public void BuyChips_minus1_ExceptionArgument()
        {
            var player = new Player();


            var exception = Assert.Catch<ArgumentException>(() => { player.BuyChips(-1); });
            Assert.AreEqual("Are you cheating?", exception.Message);
        }
    }
}