using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RollDiceGameTest
    {
        [Test]
        public void Play_Has1ChipAndBetForLuckyScrore_Win()
        {
            var player = NewPlayer.BuyChips(1).BetChips(1).ForScore(6);
            NewGame.WithWinScore(6).Join(player).Play();

            Assert.AreEqual(1*6, player.Chips);
        }

        [Test]
        public void Play_Has1ChipAndBetForLuckyScrore_Lose()
        {
            var player = NewPlayer.BuyChips(1).BetChips(1).ForScore(6);
            NewGame.WithWinScore(1).Join(player).Play();

            Assert.AreEqual(0, player.Chips);
        }
    }

    public static class NewPlayer
    {
        static readonly Player _player;
        static int _chips;
        static int _score;

        static NewPlayer()
        {
            _player = new Player();
        }

        public static Player BuyChips(int v)
        {
            _player.BuyChips(1);
            return _player;
        }

        public static Player BetChips(this Player player, int v)
        {
            _chips = v;
            return _player;
        }

        public static Player ForScore(this Player player, int v)
        {
            _score = v;
            _player.Bet(_chips, _score);
            return _player;
        }
    }

    public static class NewGame
    {
        static readonly RollDiceGame _game;
        static Mock<IDice> _dice;

        static NewGame()
        {
            _game = new RollDiceGame();
        }

        public static RollDiceGame Join(this RollDiceGame game, Player player)
        {
            _game.Player = player;
            return _game;
        }

        public static RollDiceGame WithWinScore(int v)
        {
            _dice = new Mock<IDice>();
            _dice.Setup(_ => _.Roll()).Returns(v);

            return _game;
        }

        public static void Play(this RollDiceGame game)
        {
            _game.Play(_dice.Object);
        }
    }
}