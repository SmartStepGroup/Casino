using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTest
    {
        private Player _player;

        [SetUp]
        public void RegisterNewPlayer()
        {
            _player = new Player();
        }

        [Test]
        public void Default_CreatePlayer_0Chips()
        {
            Assert.AreEqual(0, _player.Chips);
        }

        [Test]
        public void BuyChips_0_Has0()
        {
            _player.BuyChips(0);

            Assert.AreEqual(0, _player.Chips);
        }

        [Test]
        public void BuyChips_1_Has1()
        {
            _player.BuyChips(1);

            Assert.AreEqual(1, _player.Chips);
        }

        [Test]
        public void BuyChips_minus1_ExceptionArgument()
        {
            var exception = Assert.Catch<ArgumentException>(() => { _player.BuyChips(-1); });
            Assert.AreEqual("Are you cheating?", exception.Message);
        }

        [Test]
        public void Lose_Void_Null()
        {
            _player.Bet(0, 1);
            _player.Lose();

            Assert.IsNull(_player.CurrentBet);
        }

        [Test]
        public void Win_1Chip_1More()
        {
            var chipsBeforeWin = _player.Chips;
            _player.Win(1);

            Assert.AreEqual(chipsBeforeWin + 1, _player.Chips);
        }

        [Test]
        public void Win_1Chip_CurrentBetIsNull()
        {
            _player.Win(1);

            Assert.IsNull(_player.CurrentBet);
        }


        [Test]
        public void Bet_Has1_BetChips2()
        {
            _player.BuyChips(1);

            Assert.Catch<ArgumentException>(() => { _player.Bet(chips: 2, score: 1); });
        }

        [Test]
        public void Bet_BetChips1_HasMinus1()
        {
            _player.BuyChips(1);
            var chipsBeforeBet = _player.Chips;
            _player.Bet(1, 1);

            Assert.AreEqual(chipsBeforeBet - 1, _player.Chips);
        }

        [Test]
        public void Bet_1Chip_CurrentBetIsNotNull()
        {
            _player.BuyChips(1);

            _player.Bet(1, 1);

            Assert.IsNotNull(_player.CurrentBet);
        }

        [Test]
        public void Bet_BetChipsM1_HasMinus1()
        {
            _player.BuyChips(1);

            Assert.Catch<ArgumentException>(() => { _player.Bet(-1, 1); });
        }

        [Test]
        public void Join()
        {
            var game = new RollDiceGame();

            _player.Join(game);

            Assert.IsNotNull(game.Player);
        }

        [Test]
        public void Leave()
        {
            var game = new RollDiceGame();

            _player.Leave(game);

            Assert.IsNull(game.Player);
        }
    }
}