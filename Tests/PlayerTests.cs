using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class PlayerTests
   {
      [Test]
      public void Player_CanEnterGame()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);

         Assert.True(player.IsInGame);
      }

      [Test]
      public void Player_CanLeaveGame()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);
         player.Leave();

         Assert.False(player.IsInGame);
      }

      [Test]
      public void Player_CantLeaveGame_IfNotInGame_InvalidOperationException()
      {
         var player = new Player();
         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }

      [Test]
      public void Player_CantLeaveGameTwice_InvalidOperationException()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);
         player.Leave();

         Assert.Catch<InvalidOperationException>(() => player.Leave());
      }

      [Test]
      public void Player_CantJoinGameTwice_InvalidOperationException()
      {
         var player = new Player();
         var game = new Game();

         player.Join(game);

         Assert.Catch<InvalidOperationException>(() => player.Join(game));
      }

      [Test]
      public void Player_CantJoinNullGame_ArgumentNullException()
      {
         var player = new Player();

         Assert.Catch<ArgumentNullException>(() => player.Join(null));
      }

      [Test]
      public void Player_CanBy10Chips()
      {
         var player = new Player();

         player.BuyChips(10.chips());

         Assert.AreEqual(10.chips(), player.Chips);
      }

      [Test]
      public void Player_CantBuyNegativeChips()
      {
         var player = new Player();

         Assert.Catch<ArgumentException>(() => player.BuyChips((-20).chips()));
      }

      [Test]
      public void Player_CantBuyZeroChips()
      {
         var player = new Player();

         Assert.Catch<ArgumentException>(() => player.BuyChips(0.chips()));
      }

      [Test]
      public void Player_CanBet()
      {
         var player = new Player();
         player.BuyChips(1.chips());

         player.Bet(player.Chips, 2.score());

         Assert.True(player.HasAnyBet());
      }

      [Test]
      public void Player_CantBetMoreThanHave()
      {
         var player = new Player();
         player.BuyChips(1.chips());

         Assert.Catch<InvalidOperationException>(() => player.Bet(2.chips(), 2.score()));
      }

      [Test]
      public void Player_CanBetOnTwoScores()
      {
         var player = new Player();
         player.BuyChips(5.chips());

         player.Bet(1.chips(), 2.score());
         player.Bet(3.chips(), 5.score());

         Assert.AreEqual(5.chips() - (1.chips() + 3.chips()), player.Chips);
      }
   }
}