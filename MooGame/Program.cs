using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{

			IUI ui = new ConsoleUI();
			IPlayerData playerData = new PlayerData();
			Logic logic = new Logic();
			IFileHandler fileHandler = new FileTxtHandler();
			
			bool playOn = true;
			playerData.SetName(ui.EnterName());

			while (playOn)
			{
				string goal = logic.makeGoal();
				playerData.ResetGuessTotal();

				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");

				playerData.SetGuess(ui.PlayerInput());
				ui.Result(goal, playerData, logic);

				fileHandler.SaveResult($"{playerData.Name + "#&#" + playerData.GuessTotal}", "result.txt");
				ui.HighScore(fileHandler.showTopList("result.txt"), logic);

				playOn = ui.GameOver(playerData);
			}
		}
	}
}