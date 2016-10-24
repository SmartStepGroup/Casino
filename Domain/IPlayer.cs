namespace Domain
{
   public interface IPlayer
   {
      Bet CurrentBet { get; }
      int Chips { get; }
      void BuyChips(int chips);
      void Bet(int chips, int score);
      void Lose();
      void Win(int chips);
      void Join(RollDiceGame game);
      void Leave(RollDiceGame game);
   }
}