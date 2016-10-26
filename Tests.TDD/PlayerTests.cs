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
        public void Leave_PlayerNotInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.Leave());
        }

        [Test, TestMethod]
        public void Join_PlayerInGame_ThrowsInvalidOperationException()
        {
            Player player = new Player();
            Game game = new Game();
            player.Join(game);

            Assert.Catch<InvalidOperationException>(() => player.Join(game));
        }


    }
}
