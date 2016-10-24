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

         int score = 1;

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

         RollDiceGame game = new RollDiceGame(new DiceStub(score));
         game.Player = (IPlayer)ScenarioContext.Current[nameof(IPlayer)];

         game.Play();
      }

      [Then(@"Player win in (.*) times more, than previous has")]
      public void ThenPlayerWinInTimesMoreThanPreviousHas(int times)
      {
         PlayerMock player = (PlayerMock) ScenarioContext.Current[nameof(IPlayer)];
         int chipsCount = (int)ScenarioContext.Current[nameof(chipsCount)];

         Assert.IsTrue(player.IsWinCalled);
         Assert.AreEqual(chipsCount*times, player.Chips);
      }
   }
}