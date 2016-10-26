using System.Security.Permissions;
using System.Security.Policy;
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

    public class Game
    {
    }

    public class Player
    {
        public void Join(Game game)
        {
           
        }

        public bool InGame = true;
    }
}