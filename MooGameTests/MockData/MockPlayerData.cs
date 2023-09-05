using MooGame.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGameTests.MockData
{
	internal class MockPlayerData : IPlayer
	{
		public string Name { get; set; }

		public int NumOfGames { get; set; }

		public int NumOfGuesses { get; set; }

		public string Guess { get; set; }

		public MockPlayerData() 
		{
			this.Name = "TestObject";
			NumOfGames = 1;
			NumOfGuesses = 4;
			Guess = "TestGuess";
		}
		public MockPlayerData(string name, int guesses)
		{
			Name = name;
			NumOfGames = 1;
			NumOfGuesses = guesses;
			Guess = "TestGuess";
		}

		public double PlayerScore(int totalGuesses, int numOfGames)
		{
			return (double)totalGuesses / numOfGames;
		}

		public void ResetGuessTotal()
		{
			NumOfGuesses = 0;
		}

		public void SetGuess(string guess)
		{
			NumOfGuesses++;
			this.Guess= guess;
		}

		public void SetName(string name)
		{
			this.Name= name;
		}

		public void Update(int guesses)
		{
			NumOfGuesses += guesses;
			NumOfGames++;
		}
	}
}
