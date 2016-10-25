using Domain;
using Moq;

namespace Tests.DSL
{
   public interface IDSLPlayer
   {
      Mock<IPlayer> PlayerStub { get; }
   }
}