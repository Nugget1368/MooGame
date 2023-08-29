using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{

			IUI<IPlayerData> ui = new ConsoleUI<IPlayerData>();
			IFileHandler<IPlayerData> fileHandler = new FileTxtHandler<IPlayerData>();
			IPlayerData playerData = new PlayerData("", 0);
			Logic logic = new Logic();
			
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
				while (ui.Result(logic.CheckResult(goal, playerData.Guess)) != true)
				{
					playerData.SetGuess(ui.PlayerInput());
				}

				fileHandler.SaveResult($"{playerData.Name + "#&#" + playerData.GuessTotal}", "result.txt");
				ui.HighScore(fileHandler.showTopList("result.txt"));

				playOn = ui.GameOver(playerData);
			}
		}
	}
}