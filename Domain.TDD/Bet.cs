namespace Domain.TDD
{
    public class Bet
    {
        public Bet(int chips, int score)
        {
            Chips = chips;
            Score = score;
        }

        public int Chips { get; private set; }

        public int Score { get; private set; }
    }
}