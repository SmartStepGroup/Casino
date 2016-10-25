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
            RollDiceGame game =
                Create
                    .Game()
                    .WithDiceThatAlwaysRolls(2);

            Player player =
                Create
                    .Player()
                    .WithChips(10)
                    .In(game);

            player.Bet(chips: 10, score: 2);


            game.Play();

            Assert.AreEqual(6*10, player.Chips);
        }
    }
}
