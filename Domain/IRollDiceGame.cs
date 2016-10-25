namespace Domain
{
    public interface IRollDiceGame
    {
        IPlayer Player { get; set; }
        void Play();
    }
}