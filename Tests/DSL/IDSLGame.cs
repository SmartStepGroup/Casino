using Domain;
using Moq;

namespace Tests.DSL
{
   public interface IDSLGame : IRollDiceGame
   {
       Mock<IDice> DiceMock { get; } 
   }
}