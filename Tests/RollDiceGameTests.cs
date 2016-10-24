using System;
using Domain;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class RollDiceGameTests
   {
      [Test]
      public void WinGame_PlayerBet1Chip_Has6Chips()
      {
         var winScore = 3;
         var betChip = 1;
         var game = new RollDiceGame(new DiceStub(winScore));
         var player = new Player();
         player.BuyChips(betChip);
         player.Bet(betChip, winScore);
         game.Player = player;

         game.Play();

         Assert.AreEqual(betChip*6, player.Chips);
         Assert.IsNull(player.CurrentBet);
      }

      [Test]
      public void LooseGame_PlayerBet1Chip_HasNoChip()
      {
         var winScore = 3;
         var betChip = 1;
         var game = new RollDiceGame(new DiceStub(winScore));
         var player = new Player();
         player.BuyChips(betChip);
         player.Bet(betChip, score: 2);
         game.Player = player;

         game.Play();

         Assert.AreEqual(0, player.Chips);
         Assert.IsNull(player.CurrentBet);
      }

      
      [Test]
      [Category("WTF")]
      public void CannotPlay_PlayerHasNoBet_NullReferenceException()
      {
         var winScore = 3;
         var game = new RollDiceGame(new DiceStub(winScore));
         var player = new Player();
         game.Player = player;

         Assert.Catch<NullReferenceException>(() => game.Play());

         Assert.AreEqual(0, player.Chips);
         Assert.IsNull(player.CurrentBet);
      }
   }
}
