namespace Domain
{
   public class Game
   {
      public int CountPlayers { get; private set; }

      public void JoinPlayer(Player player)
      {
         CountPlayers++;
      }
   }
}