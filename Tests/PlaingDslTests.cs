using System;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests.DSL;

namespace Tests
{
    [TestClass]
    public class PlaingDslTests
    {
        [TestMethod]
        public void GamePlay_PlayerWithLuckyBet10_Win60Chips()
        {
            const int chips = 10;
            const int luckyScore = 2;

            RollDiceGame game =
                Create
                    .Game()
                    .WithDiceThatAlwaysRolls(luckyScore);

            Player player =
                Create
                    .Player()
                    .WithChips(chips)
                    .In(game);

            player.Bet(chips, luckyScore);


            game.Play();


            Assert.AreEqual(6*chips, player.Chips);
        }
    }
}
