using Domain;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests
{
   [Binding]
   public class DiceSteps
   {
      [Given(@"has bet with all of his chip and some score")]
      public void GivenHasBetWithAllOfHisChipAndSomeScore()
      {
         int chipsCount = (int) ScenarioContext.Current[nameof(chipsCount)];
         var player = (IPlayer) ScenarioContext.Current[nameof(IPlayer)];

         var score = 1;

         player.Bet(chipsCount, score);

         ScenarioContext.Current[nameof(score)] = score;
      }

      [Given(@"Player has some amount of chips")]
      public void GivenPlayerHasSomeAmountOfChips()
      {
         var chipsCount = 1;

         var player = new PlayerMock(new Player());

         player.BuyChips(chipsCount);

         ScenarioContext.Current[nameof(IPlayer)] = player;
         ScenarioContext.Current[nameof(chipsCount)] = chipsCount;
      }

      [When(@"Dice roll to same value as Player bet's score")]
      public void WhenDiceRollToSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current[nameof(score)];

         var game = new RollDiceGame(new DiceStub(score));
         game.Player = (IPlayer) ScenarioContext.Current[nameof(IPlayer)];

         game.Play();
      }

      [Then(@"Player win in (.*) times more, than previous has")]
      public void ThenPlayerWinInTimesMoreThanPreviousHas(int times)
      {
         var player = (PlayerMock) ScenarioContext.Current[nameof(IPlayer)];
         int chipsCount = (int) ScenarioContext.Current[nameof(chipsCount)];

         Assert.IsTrue(player.IsWinCalled);
         Assert.IsFalse(player.IsLoseCalled);
         Assert.AreEqual(chipsCount*times, player.Chips);
      }

      [When(@"Dice roll to not same value as Player bet's score")]
      public void WhenDiceRollToNotSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current[nameof(score)];

         var game = new RollDiceGame(new DiceStub(~score));
         game.Player = (IPlayer) ScenarioContext.Current[nameof(IPlayer)];

         game.Play();
      }

      [Then(@"Player lose his bet and all chips")]
      public void ThenPlayerLoseHisBetAndAllChips()
      {
         var player = (PlayerMock) ScenarioContext.Current[nameof(IPlayer)];
         int chipsCount = (int) ScenarioContext.Current[nameof(chipsCount)];

         Assert.IsFalse(player.IsWinCalled);
         Assert.IsTrue(player.IsLoseCalled);
         Assert.AreEqual(0, player.Chips);
      }
   }
}