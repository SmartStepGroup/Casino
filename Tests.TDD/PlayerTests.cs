using System;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace Tests.TDD
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Join_NewPlayer_InGame()
        {
            Player player = new Player();
            Game game = new Game();

            player.Join(game);

            Assert.IsTrue(player.IsInGame);
        }

        [Test]
        public void Leave_NewPlayer_NotInGame()
        {
            Player player = new Player();
            Game game = new Game();
            player.Join(game);

            player.Leave();

            Assert.IsFalse(player.IsInGame);
        }

        [Test]
        public void Leave_PlayerIsNotInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.Leave());
        }

        [Test]
        public void Join_PlayerIsInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();
            Game game = new Game();
            player.Join(game);

            Assert.Catch<InvalidOperationException>(() => player.Join(game));
        }

        [Test]
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

        [Test]
        public void BuyChips_PlayerAndCasino_PlayerHasChips()
        {
            Player player = new Player();
            Casino casino = new Casino();

            player.BuyChips(casino, (Chips)6);

            Assert.AreEqual((Chips)6, player.Chips);
        }

        [Test]
        public void Bet_PlayerWithoutBet_PlayerHasBetWithCorrectValues()
        {
            Player player = new Player();

            player.Bet((Chips)1, (Score)2);

            Assert.IsNotNull(player.CurrentBet);
            Assert.AreEqual((Chips)1, player.CurrentBet.Chips);
            Assert.AreEqual((Score)2, player.CurrentBet.Score);
        }
    }
}
