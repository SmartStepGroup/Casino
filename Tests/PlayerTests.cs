using System.Security.Permissions;
using System.Security.Policy;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Join_IsInGame()
        {
            var player = new Player();
            var game = new Game();

            player.Join(game);
                
            Assert.IsTrue(player.InGame);
        }
    }

}