namespace Domain
{
   public class Player
   {
      public bool IsInGame { get; private set; }

      public void Join(Game game)
      {
         IsInGame = true;
      }
   }
}