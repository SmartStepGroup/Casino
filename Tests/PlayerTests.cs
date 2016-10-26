using System;
using System.Data;
using System.Security.Permissions;
using System.Security.Policy;
using Domain;
using Moq;
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

        [Test]
        public void ByDefault_IsNotInGame()
        {
            var player = new Player();

            Assert.IsFalse(player.InGame);
        }


        [Test]
        public void GoOut_NotJoin_ThrowsInvalidOperationException()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => player.GoOutFromGame());
        }


        [Test]
        public void GoOut_AfterJoin_IsNotInGame()
        {
            var player = new Player();
            var game = new Game();
            player.Join(game);

            player.GoOutFromGame();

            Assert.IsFalse(player.InGame);
        }

        [Test]
        public void JoinGame2_AlreadyJoinedGame1_ThrowsInvalidOperationException()
        {
            var player = new Player();
            var game1 = new Game();
            var game2 = new Game();
            player.Join(game1);
            
            Assert.Catch<InvalidOperationException>(()=>player.Join(game2));
        }

        [Test]
        public void Buy1Chip_Has1Chip()
        {
            var player = new Player();
            var one_chip = new Chips(1);

            player.BuyChips(one_chip);

            Assert.AreEqual(one_chip, player.Cash);
        }

        [Test]
        public void GamePlay_BetAll_Wins()
        {
            var player = new Mock<Player>();
            var game = new Game();
            player.Object.Join(game);
            player.Object.Bet(player.Object.Cash, new Score(6));

            game.Play();

            player.Verify(x => x.Win(), Times.Once);
        }

        [Test]
        public void BetMoreCash_ThowException()
        {
            var player =new Player();
            player.BuyChips(new Chips(1));

            Assert.Catch<Exception>(()=> player.Bet(new Chips(2), new Score(6)));
        }

        [Test]
        public void Do2Bets_Has2bets()
        {
            var player = new Player();
            player.BuyChips(new Chips(2));
            player.Bet(new Chips(2), new Score(6));

            player.Bet(new Chips(2), new Score(6));

          //  Assert.AreEqual(2, player.Bets.Count);

        }
    }


}



//## Упражнение 2. Ставки
//* Я, как игрок, могу купить фишки у казино, чтобы делать ставки
//* Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
//* Я, как игрок, не могу поставить фишек больше, чем я купил
//* Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша
//* Я, как казино, принимаю только ставки, кратные 5
//* Я, как игрок, могу поставить только на числа 1 - 6