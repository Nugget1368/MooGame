using System.Collections;

namespace MooGame
{
	public class PlayerData : IPlayerData
	//-> Extrahera ett interface?
	{
		public string Name { get; set; }
		public int NGames { get; private set; } = 1;
		/* Gör om till Property? */
		//public double PlayerScore { get; private set; }
		//Se om du kan göra dessa Private sen
		public int GuessTotal { get; private set; }
		public string Guess { get; private set; }

		/***********************/

		public PlayerData(string name, int guesses)
		{
			this.Name = name;
			NGames = 1;
			GuessTotal = guesses;
		}
		public void SetName(string name)
		{
			this.Name = name;
		}

		public void ResetGuessTotal()
		{
			this.GuessTotal = 0;
		}

		public void Update(int guesses)
		{
			GuessTotal += guesses;
			NGames++;
		}
		public void SetGuess(string guess)
		{
			GuessTotal++;
			this.Guess = guess;
		}
		public double PlayerScore(int totalGuesses, int numOfGames)
		{
			return (double)totalGuesses / numOfGames;
		}
		public override bool Equals(Object p)
		{
			//???????
			return Name.Equals(((PlayerData)p).Name);
		}

		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}
	}
}