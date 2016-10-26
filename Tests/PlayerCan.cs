using System;
using System.Linq;
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

            Assert.AreEqual(1, player.CurrentChips);
        }

        [Test]
        public void PlayerBetOneChip_CreateBetWithOneChip()
        {
            var player = new Player();
            player.BuyChips(1);

            player.Bet(1, 1);

            Assert.AreEqual(1, player.Bets.Last().Chips);
        }

        [Test]
        public void PlayerBetForScoreOne_CreateBetWithScoreOne()
        {
            var player = new Player();
            player.BuyChips(1);

            player.Bet(1, 1);

            Assert.AreNotEqual(-1, player.Bets.FindIndex(x => x.Score == 1));
        }

        [Test]
        public void PlayerBets_PlayerWinsSixTimesBet()
        {
            var player = new Player();
            var game = new RollDiceGame();
            player.Join(game);
            player.BuyChips(1);
            player.Bet(1, 1);

            game.Play();

            Assert.AreEqual(1*6, player.CurrentChips);
        }

        [Test]
        public void PlayerBetsMoreThanHave_ThrowsException()
        {
            var player = new Player();
            player.BuyChips(1);

            Assert.Catch<InvalidOperationException>(() => { player.Bet(2, 1); });
        }

        [Test]
        public void PlayerCanBetTwice()
        {
            var player = new Player();
            player.BuyChips(2);

            player.Bet(1, 1);
            player.Bet(1, 2);

            Assert.AreEqual(2, player.Bets.Count);
        }

        [Test]
        public void PlayerCannotBetForScoreSeven()
        {
            var player = new Player();
            player.BuyChips(2);

            Assert.Catch<InvalidOperationException>(() => { player.Bet(1, 7); });
        }
    }
}

//Я, как игрок, могу войти в игру
//Я, как игрок, могу выйти из игры
//Я, как игрок, не могу выйти из игры, если я в нее не входил
//Я, как игрок, могу играть только в одну игру одновременно

//Я, как игрок, могу купить фишки у казино, чтобы делать ставки
//Я, как игрок, могу сделать ставку в игре в кости, чтобы выиграть
// Я, как игрок, могу поставить только на числа 1 - 6
//Я, как игрок, не могу поставить фишек больше, чем я купил
//Я, как игрок, могу сделать несколько ставок на разные числа, чтобы повысить вероятность выигрыша

