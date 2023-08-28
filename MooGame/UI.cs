namespace MooGame
{
	/********************************************************************
	 * Motivation: En del av UI:ns jobb är att presentera spelarstatistik,
	 * därför tänker jag att IPlayerData får implimenteras direkt i UI:ns metoder
	 *****************************************************************************/
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

		public bool Result(string checkResult)
		{
			Console.WriteLine(checkResult + "\n");
			if(checkResult != "BBBB,")
			{
				Console.WriteLine("Try again:");
				return false;
			}
			return true;
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

		public void HighScore(List<IPlayerData> data)
		{
			Console.WriteLine("Player   games	average");
			foreach (PlayerData p in data)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.PlayerScore(p.GuessTotal, p.NGames)));
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