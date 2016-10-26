using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
    [TestFixture, TestClass]
    public class PlayerTests
    {
        [Test, TestMethod]
        public void Join_NewPlayer_InGame()
        {
            Player player = new Player();
            Game game = new Game();

            player.Join(game);

            Assert.IsTrue(player.IsInGame);
        }

        [Test, TestMethod]
        public void Leave_NewPlayer_NotInGame()
        {
            Player player = new Player();
            Game game = new Game();
            player.Join(game);

            player.Leave();

            Assert.IsFalse(player.IsInGame);
        }

        [Test, TestMethod]
        public void Leave_PlayerIsNotInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.Leave());
        }

        [Test, TestMethod]
        public void Join_PlayerIsInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();
            Game game = new Game();
            player.Join(game);

            Assert.Catch<InvalidOperationException>(() => player.Join(game));
        }

        [Test, TestMethod]
        public void JoinAnother_6PlayersInGame_ThrowsInvaliOperationException()
        {
            Game game = new Game();
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);

            Assert.Catch<InvalidOperationException>(() => new Player().Join(game));
        }

        [Test, TestMethod]
        public void BuyChips_PlayerAndCasino_PlayerHasChips()
        {
            Player player = new Player();
            Casino casino = new Casino();

            player.BuyChips(casino, chips: 6);

            Assert.AreEqual(6, player.Chips);
        }

        [Test, TestMethod]
        public void BuyNegativeAmountOfChips_PlayerAndCasino_ThrowsArgumentOutOfRangeException()
        {
            Player player = new Player();
            Casino casino = new Casino();

            Assert.Catch<ArgumentOutOfRangeException>(() => player.BuyChips(casino, chips: -1));
        }
    }
}
