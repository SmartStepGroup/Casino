using System;
using Domain;
using Domain.TDD;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

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

            player.Leave();

            Assert.IsFalse(player.IsInGame);
        }
    }
}
