namespace MooGame
{
	public class UI
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
		public bool GameOver(PlayerData playerData)
		{
			Console.WriteLine("Correct, it took " + playerData.GetGuessTotal() + " guesses\nContinue?");
			/* Bryt ut till UI */
			string answer = Console.ReadLine();
			if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			{
				return false;
			}
			return true;
		}
	}
}