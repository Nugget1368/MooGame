namespace MooGame
{
	/*
	 * Kan vi göra en allmän PlayerInfo??
	 */
	public interface IPlayerData
	{
		public string Name { get; set; }
		public int NGames { get; }
		int GuessTotal { get; }
		string Guess { get; }

		bool Equals(object p);
		int GetHashCode();
		void IncreaseNumGuesses();
		void ResetGuessTotal();
		void SetGuess(string guess);
		void SetGuessTotal(int guesses);
		void SetName(string name);
		void Update(int guesses);
	}
}