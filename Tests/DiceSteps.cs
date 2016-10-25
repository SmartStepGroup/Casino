using Domain;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace Tests
{
   [Binding]
   public class DiceSteps
   {
      [Given(@"Игрок имеет ставку в размере всех его фишек")]
      public void GivenHasBetWithAllOfHisChipAndSomeScore()
      {
         int chipsCount = (int) ScenarioContext.Current["chipsCount"];
         var player = (IPlayer) ScenarioContext.Current["player"];

         var score = 1;

         player.Bet(chipsCount, score);

         ScenarioContext.Current["score"] = score;
      }

      [Given(@"у Игрока есть некоторое количество фишек")]
      public void GivenPlayerHasSomeAmountOfChips()
      {
         var chipsCount = 1;

         var player = new PlayerMock(new Player());

         player.BuyChips(chipsCount);

         ScenarioContext.Current["player"] = player;
         ScenarioContext.Current["chipsCount"] = chipsCount;
      }

      [When(@"на Кубике выпадет тоже число, что и у Игрока в ставке")]
      public void WhenDiceRollToSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current["score"];

         var game = new RollDiceGame(new DiceStub(score));
         game.Player = (IPlayer) ScenarioContext.Current["player"];

         game.Play();
      }

      [Then(@"Игрок выиграет в (.*) раз больше, чем было у него в ставке")]
      public void ThenPlayerWinInTimesMoreThanPreviousHas(int times)
      {
         var player = (PlayerMock) ScenarioContext.Current["player"];
         int chipsCount = (int) ScenarioContext.Current["chipsCount"];

         Assert.IsTrue(player.IsWinCalled);
         Assert.IsFalse(player.IsLoseCalled);
         Assert.AreEqual(chipsCount*times, player.Chips);
      }

      [When(@"на Кубике выпадет другое число, отличное от числа в ставке Игрока")]
      public void WhenDiceRollToNotSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current["score"];

         var game = new RollDiceGame(new DiceStub(~score));
         game.Player = (IPlayer) ScenarioContext.Current["player"];

         game.Play();
      }

      [Then(@"Игрок потеряет ставку и все свои фишки")]
      public void ThenPlayerLoseHisBetAndAllChips()
      {
         var player = (PlayerMock) ScenarioContext.Current["player"];
         int chipsCount = (int) ScenarioContext.Current["chipsCount"];

         Assert.IsFalse(player.IsWinCalled);
         Assert.IsTrue(player.IsLoseCalled);
         Assert.AreEqual(0, player.Chips);
      }
   }
}