namespace MooGame
{
	public class PlayerData : IPlayerData
	//-> Extrahera ett interface?
	{
		public string Name { get; private set; }
		public int NGames { get; private set; } = 1;
		/* Gör om till Property? */
		public int GuessTotal { get; private set; } = 1;
		public string Guess { get; private set; }

		/***********************/

		//public PlayerData(string name, int guesses)
		//{
		//	this.Name = name;
		//	NGames = 1;
		//	GuessTotal = guesses;
		//}
		//????????????
		public PlayerData()
		{
			
		}
		public void SetGuessTotal(int guessTotal)
		{
			this.GuessTotal= guessTotal;
		}
		public void SetName(string name)
		{
			this.Name = name;
		}
		public void SetName(UI ui)
		{
			string name = ui.EnterName();
			this.Name = name;

		}
		public string GetName()
		{
			return this.Name;
		}
		public void SetGuess(string guess)
		{
			this.Guess = guess;
		}
		public void SetGuess()
		{
			this.Guess = "";
			while (this.Guess == "" || this.Guess == null)
			{
				this.Guess = Console.ReadLine();
			}
		}
		public string GetGuess()
		{
			return this.Guess;
		}

		public int GetGuessTotal()
		{
			return this.GuessTotal;
		}
		//////////////////////////////
		public void Update(int guesses)
		{
			GuessTotal += guesses;
			NGames++;
		}

		public void IncreaseNumGuesses()
		{
			this.GuessTotal += 1;
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