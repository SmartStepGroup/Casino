using Domain;
using Moq;

namespace Tests.DSL
{
   public class DSLPlayer : IDSLPlayer
   {
      public DSLPlayer()
      {
         PlayerStub = new Mock<IPlayer>();
      }

      public Mock<IPlayer> PlayerStub { get; private set; }
   }
}