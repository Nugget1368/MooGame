namespace MooGame
{
	public class ConsoleUI : IUI
	{
		public string EnterName()
		{
			Console.WriteLine("Enter your user name:\n");
			string name = Console.ReadLine();
			while (name == "" || name == null)
			{
				Console.WriteLine("Enter your user name:\n");
				name = Console.ReadLine();
			}
			return name;
		}

		public void Result(string goal, IPlayerData playerData, Logic logic)
		{
			while(logic.CheckResult(goal, playerData.Guess) != "BBBB,")
			{
				Console.WriteLine(logic.CheckResult(goal, playerData.Guess) + "\n");
				Console.WriteLine("Try again:");
				playerData.IncreaseNumGuesses();
				playerData.SetGuess(PlayerInput());
				Console.WriteLine(playerData.Guess + "\n");
			}
		}

		public string PlayerInput()
		{
			string input = "";
			while (input == "" || input == null)
			{
				input = Input();
			}
			return input;
		}
		private string Input()
		{
			string input = Console.ReadLine();
			return input;
		}

		public void HighScore(List<IPlayerData> data, Logic logic)
		{
			Console.WriteLine("Player   games	average");
			foreach (PlayerData p in data)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, logic.Average(p.GuessTotal, p.NGames)));
			}
		}

		public bool GameOver(IPlayerData playerData) //Man vill visa playerScore mm. så för in hela playern i GameOver
		{
			Console.WriteLine("Correct, it took " + playerData.GuessTotal + " guesses\nContinue?");
			if (PlayerInput().Substring(0, 1) == "n")
			{
				return false;
			}
			return true;
		}
	}
}