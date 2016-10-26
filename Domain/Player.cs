namespace Domain
{
   public class Player
   {
      public bool IsInGame { get; private set; }

      public void Join(Game game)
      {
         if (game.CountPlayers >= 6)
         {
            return;
         }

         ++game.CountPlayers;
         IsInGame = true;
      }
   }
}