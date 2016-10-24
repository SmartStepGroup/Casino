using System;
using Domain;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests
{
   [Binding]
   public class PlayerSteps
   {
      [Given(@"Player has (.*) chip")]
      public void GivenPlayerHasChip(int chipCount)
      {
         Player player = new Player();
         player.BuyChips(chipCount);

         ScenarioContext.Current[nameof(Player)] = player;
      }

      [When(@"Make bet with (.*) chip")]
      public void WhenMakeBetWithChip(int chipCount)
      {
         Player player = (Player) ScenarioContext.Current[nameof(Player)];

         player.Bet(chips: chipCount, score: default(int));
      }

      [Then(@"Player's current bet has (.*) chip")]
      public void ThenPlayerSCurrentBetHasChip(int chipCount)
      {
         Player player = (Player)ScenarioContext.Current[nameof(Player)];

         Assert.IsNotNull(player.CurrentBet);
         Assert.AreEqual(chipCount, player.CurrentBet.Chips);
      }
   }
}
