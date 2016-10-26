using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerCan
    {
        [Test]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void JoinGame_GameExist_PlayerInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            Assert.True(player.IsInGame);
        }

        [Test]
        public void LeaveGame_NotInGame_Exception()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => { player.LeaveGame(); });
        }

        [Test]
        public void LeaveGame_InGame_NotInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void LeaveGameTwice_InGame_Exception()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();

            Assert.Catch<InvalidOperationException>(() => { player.LeaveGame(); });
        }
    }
}

//Я, как игрок, могу войти в игру
//Я, как игрок, могу выйти из игры
//Я, как игрок, не могу выйти из игры, если я в нее не входил
//Я, как игрок, могу играть только в одну игру одновременно
//Я, как игра, не позволяю войти более чем 6 игрокам