namespace MooGame.Player
{
    public interface IPlayer
    {
        string Name { get; set; }
        int NumOfGames { get; }
        int NumOfGuesses { get; }
        string Guess { get; }

        bool Equals(object p);
        int GetHashCode();
        void ResetGuessTotal();
        void SetGuess(string guess);
        void Update(int guesses);
    }
}