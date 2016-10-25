using System;
using Domain;
using Moq;
using NUnit.Framework;

namespace Tests
{
   [TestFixture]
   public class GameTestWithDsl
   {
      [Test]
      public void Game_RichPlayerBets4_Wins24()
      {
         var player = Create.RichPlayer();
         var game = Create.Game().FinishedWithScore(2);

         player.Bets(4.chips()).OnScore(2).JoinsGame(game);

         player.Wins(4.chips() * 6);
      }
   }

   public static class Extentions
   {
      public static int chips(this int value)
      {
         return value;
      }
   }

   public class PlayerBehaviour
   {
      public Player Player;

      private GameBehaviour _gameBehaviour;

      private RollDiceGame _game;

      public PlayerBehaviour(Player player)
      {
         Player = player;
      }

      public BetBehaviour Bets(int chipsCount)
      {
         return new BetBehaviour(this, chipsCount);
      }

      public void JoinsGame(GameBehaviour gameBehaviour)
      {
         var diceMock = new Mock<IDice>();
         diceMock.Setup(m => m.Get()).Returns(gameBehaviour.GameScore);

         var game = new RollDiceGame(diceMock.Object);

         Player.Join(game);

         _game = game;
      }

      public void Wins(int chips)
      {
         var chipsBeforePlay = Player.Chips;

         _game.Play();

         var chipsAfterGame = Player.Chips;

         var differenceAfterGame = chipsAfterGame - chipsBeforePlay;

         Assert.AreEqual(chips, differenceAfterGame);
      }
   }

   public class GameBehaviour
   {
      public int GameScore;
      public GameBehaviour()
      {
      }

      public GameBehaviour FinishedWithScore(int score)
      {
         GameScore = score;
         return this;
      }
   }

   public class BetBehaviour
   {
      private readonly PlayerBehaviour _player;

      private readonly int _betChips;

      public BetBehaviour(PlayerBehaviour player, int betChips)
      {
         _betChips = betChips;
         _player = player;
      }

      public PlayerBehaviour OnScore(int score)
      {
         _player.Player.Bet(_betChips, score);

         return _player;
      }
   }

   public static class Create
   {
      public static PlayerBehaviour RichPlayer()
      {
         var richPlayer = new Player();
         richPlayer.BuyChips(100000);

         return new PlayerBehaviour(richPlayer);
      }

      public static GameBehaviour Game()
      {
         return new GameBehaviour();
      }
   }
}