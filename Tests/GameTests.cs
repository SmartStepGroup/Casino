using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class GameTests
    {
        [Test]
        public void Join7thPlayer_NotJoined()
        {
            var game = new Game();
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);
            new Player().Join(game);

            var player7 = new Player();

            Assert.IsFalse(player7.Join(game));
        }
    }
}
