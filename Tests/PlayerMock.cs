using Domain;

namespace Tests
{
   public class PlayerMock : IPlayer
   {
      private readonly IPlayer _player;

      public PlayerMock(IPlayer player)
      {
         _player = player;
      }

      public bool IsLoseCalled { get; set; }

      public bool IsWinCalled { get; set; }

      public Bet CurrentBet
      {
         get { return _player.CurrentBet; }
      }

      public int Chips
      {
         get { return _player.Chips; }
      }

      public void BuyChips(int chips)
      {
         _player.BuyChips(chips);
      }

      public void Bet(int chips, int score)
      {
         _player.Bet(chips, score);
      }

      public void Lose()
      {
         IsLoseCalled = true;

         _player.Lose();
      }

      public void Win(int chips)
      {
         _player.Win(chips);

         IsWinCalled = true;
      }

      public void Join(RollDiceGame game)
      {
         _player.Join(game);
      }

      public void Leave(RollDiceGame game)
      {
         _player.Leave(game);
      }
   }
}