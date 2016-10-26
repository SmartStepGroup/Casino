using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    class GameCan
    {
        [Test]
        public void PlayerJoinGame_NowOnePlayerInGame()
        {
            var player = new Player();
            var game = new RollDiceGame();

            player.Join(game);

            Assert.AreEqual(1, game.PlayerCount);
        }

        [Test]
        public void LeaveGame_InGame_NoLeftPlayer()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            player.LeaveGame();

            Assert.IsNull(game.Player);
        }

        [Test]
        public void SixPlayersJoinGame_NoOneInGame_SixPlayersInGame()
        {
            var game = new RollDiceGame();
            
            for (int i = 0; i < 6; i++)
            {
                new Player().Join(game);
            }

            Assert.AreEqual(6, game.PlayerCount);
        }

        [Test]
        public void SeventhPlayerJoinGame_SixPlayersInGame_ThrowsException()
        {
            var game = new RollDiceGame();
            for (int i = 0; i < 6; i++)
            {
                new Player().Join(game);
            }

            Assert.Catch<InvalidOperationException>(() =>
            {
                var player7 = new Player();
                player7.Join(game);
            });
        }
    }
}

// Я, как игра, не позволяю войти более чем 6 игрокам
// Я, как казино, принимаю только ставки, кратные 5