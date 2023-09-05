namespace MooGame.Player;

public class MooPlayer : IPlayer
{
    public string Name { get; set; }
    public int NumOfGames { get; private set; } = 1;
    public int NumOfGuesses { get; private set; }
    public string Guess { get; private set; }

    public MooPlayer(string name, int guesses)
    {
        Name = name;
		NumOfGames = 1;
		NumOfGuesses = guesses;
    }
	public MooPlayer()
	{
		NumOfGames = 1;
	}

	public void ResetGuessTotal()
    {
		NumOfGuesses = 0;
    }

    public void Update(int guesses)
    {
        NumOfGuesses += guesses;
        NumOfGames++;
    }
    public void SetGuess(string guess)
    {
        NumOfGuesses++;
        Guess = guess;
    }
    public override bool Equals(object p)
    {
        return Name.Equals(((MooPlayer)p).Name);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}