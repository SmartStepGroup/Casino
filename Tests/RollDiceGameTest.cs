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
            var player = CreatePlayer.BuyChips(1).BetChips(1).ForScore(6);
            CreateGame.Join(player).WaitWinResult(6).CheckResult();
            
            Assert.AreEqual(1*6, player.Chips);
        }
    }

    public static class CreateGame
    {
        static readonly RollDiceGame _game;
        static Mock<IDice> _dice;

        static CreateGame()
        {
            _game = new RollDiceGame();
        }

        public static RollDiceGame Join(Player player)
        {
            _game.Player = player;
            return _game;
        }

        public static RollDiceGame WaitWinResult(this RollDiceGame game, int v)
        {
            _dice = new Mock<IDice>();
            _dice.Setup(_ => _.Roll()).Returns(v);
            
            return _game;
        }

        public static void CheckResult(this RollDiceGame game)
        {
            _game.Play(_dice.Object);
        }
    }

    public static class CreatePlayer
    {
        static readonly Player _player;
        static int _chips;
        static int _score;

        static CreatePlayer()
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
}