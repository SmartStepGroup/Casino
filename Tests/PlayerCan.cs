using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class PlayerCan
    {
        [Test]
        public void ByDefault_NotInGame()
        {
            var player = new Player();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void JoinGame_GameExist_PlayerInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            Assert.True(player.IsInGame);
        }

        [Test]
        public void LeaveGame_NotInGame_Exception()
        {
            var player = new Player();

            Assert.Catch<InvalidOperationException>(() => { player.LeaveGame(); });
        }

        [Test]
        public void LeaveGame_InGame_NotInGame()
        {
            var player = new Player();
            player.Join(new RollDiceGame());

            player.LeaveGame();

            Assert.False(player.IsInGame);
        }

        [Test]
        public void LeaveGameTwiceThrowsException()
        {
            var player = new Player();
            player.Join(new RollDiceGame());
            player.LeaveGame();

            Assert.Catch<InvalidOperationException>(() => { player.LeaveGame(); });
        }

        [Test]
        public void JoinGameTwiceThrowsException()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);

            Assert.Catch<InvalidOperationException>(() => { player.Join(game); });
        }

        [Test]
        public void PlayerBuyChips_HasNoChips_HasOneChip()
        {
            var player = new Player();

            player.BuyChips(1);

            Assert.AreEqual(1, player.Chips);
        }

        [Test]
        public void PlayerBetOneChip_CreateBetWithOneChip()
        {
            var player = new Player();
            player.BuyChips(1);

            player.Bet(1, 1);

            Assert.AreEqual(1, player.CurrentBet.Chips);
        }
    }
}

//Я, как игрок, могу войти в игру
//Я, как игрок, могу выйти из игры
//Я, как игрок, не могу выйти из игры, если я в нее не входил
//Я, как игрок, могу играть только в одну игру одновременно

//Я, как игрок, могу купить фишки у казино, чтобы делать ставки
//Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
//Я, как игрок, не могу поставить фишек больше, чем я купил
//Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша

