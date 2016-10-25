using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void Buy_Buy1Chip_Sets1Chip()
        {
            var player = new Player();
            player.BuyChips(1);
			Assert.Equals(1, player.Chips);
        }
    }
}