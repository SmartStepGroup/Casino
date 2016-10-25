using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RollDiceGameTest
    {
        private RollDiceGame _rollDiceGame;
        private const int _minChips = 1;

        [SetUp]
        public void CreateGameWith1Player_MinChips()
        {
            _rollDiceGame = new RollDiceGame {Player = new Player()};
            _rollDiceGame.Player.BuyChips(_minChips);
        }

        [Test]
        public void Play_Has1ChipAndBetForLuckyScrore_Win()
        {
            _rollDiceGame.Player.Bet(chips: 1, score: 6);

            var dice = new Mock<IDice>();
            dice.Setup(_ => _.Roll()).Returns(6);
            _rollDiceGame.Play(dice.Object);

            const int winFactor = 6;
            Assert.AreEqual(_minChips * winFactor, _rollDiceGame.Player.Chips);
        }

        [Test]
        public void Play_Has1ChipAndBetForUnluckyScrore_Lose()
        {
            _rollDiceGame.Player.Bet(chips: 1, score: 5);

            var dice = new Mock<IDice>();
            dice.Setup(_ => _.Roll()).Returns(6);
            _rollDiceGame.Play(dice.Object);

            Assert.AreEqual(0, _rollDiceGame.Player.Chips);
        }
    }
}