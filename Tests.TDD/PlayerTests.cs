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
        public void Join_Player_InGame()
        {
            Player player = new Player();

            Game game = new Game();

            player.Join(game);

            Assert.IsTrue(player.IsInGame);
        }
    }
}
