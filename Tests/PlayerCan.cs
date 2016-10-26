using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerCan
    {
        [Test]
        public void JoinGame()
        {
            var player = new Player();
            var game = new RollDiceGame();

            player.Join(game);

            Assert.True(player.IsInGame);
        }

        [Test]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }
    }
}