using System;
using Domain.TDD;
using NUnit.Framework;

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
        public void Leave_PlayerNotInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.Leave());
        }
    }
}
