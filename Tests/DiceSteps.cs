using Domain;
using Domain.Fakes;
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

         ShimPlayer playerShim = new ShimPlayer();

         Counter winCounter = new Counter();
         Counter loseCounter = new Counter();

         playerShim.WinInt32 = (i) => { winCounter.Value++; };
         playerShim.Lose = () => { loseCounter.Value++; };

         playerShim.Instance.BuyChips(chipsCount);

         ScenarioContext.Current["player"] = playerShim.Instance;
         ScenarioContext.Current["chipsCount"] = chipsCount;
         ScenarioContext.Current["winCounter"] = winCounter;
         ScenarioContext.Current["loseCounter"] = loseCounter;
      }

      [When(@"на Кубике выпадет тоже число, что и у Игрока в ставке")]
      public void WhenDiceRollToSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current["score"];

         StubIDice diceStub = new StubIDice();
         diceStub.Roll = () => score;

         var game = new RollDiceGame(diceStub);
         game.Player = (IPlayer) ScenarioContext.Current["player"];

         game.Play();
      }

      [Then(@"Игрок выиграет в (.*) раз больше, чем было у него в ставке")]
      public void ThenPlayerWinInTimesMoreThanPreviousHas(int times)
      {
         var player = (Player) ScenarioContext.Current["player"];
         var winCounter = (Counter)ScenarioContext.Current["winCounter"];
         var loseCounter = (Counter)ScenarioContext.Current["loseCounter"];
         int chipsCount = (int) ScenarioContext.Current["chipsCount"];

         Assert.AreEqual(1, winCounter.Value);
         Assert.AreEqual(0, loseCounter.Value);
         Assert.AreEqual(chipsCount*times, player.Chips);
      }

      [When(@"на Кубике выпадет другое число, отличное от числа в ставке Игрока")]
      public void WhenDiceRollToNotSameValueAsPlayerBetSScore()
      {
         int score = (int) ScenarioContext.Current["score"];

         StubIDice diceStub = new StubIDice();
         diceStub.Roll = () => ~score;

         var game = new RollDiceGame(diceStub);
         game.Player = (IPlayer) ScenarioContext.Current["player"];

         game.Play();
      }

      [Then(@"Игрок потеряет ставку и все свои фишки")]
      public void ThenPlayerLoseHisBetAndAllChips()
      {
         var player = (Player) ScenarioContext.Current["player"];
         var winCounter = (Counter)ScenarioContext.Current["winCounter"];
         var loseCounter = (Counter)ScenarioContext.Current["loseCounter"];

         Assert.AreEqual(0, winCounter.Value);
         Assert.AreEqual(1, loseCounter.Value);
         Assert.AreEqual(0, player.Chips);
      }

      class Counter
      {
         public int Value;
      }
   }
}