using Domain;
using Moq;

namespace Tests.DSL
{
   public class DSLGame : IDSLGame
   {
      private readonly RollDiceGame _rollDiceGame;

      public DSLGame()
      {
         DiceMock = new Mock<IDice>();
         _rollDiceGame = new RollDiceGame(DiceMock.Object);
      }

      public Mock<IDice> DiceMock { get; private set; }

      public IPlayer Player
      {
         get { return _rollDiceGame.Player; }
         set { _rollDiceGame.Player = value; }
      }

      public void Play()
      {
         _rollDiceGame.Play();
      }
   }
}