using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Test1
    {
        [Test]
        public void TrueIsTrue()
        {
            var player = new Player();
            player.BuyChips(1);
            Assert.True(true);  
        }
    }
}