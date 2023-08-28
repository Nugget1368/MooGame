using System;
using System.IO;
using System.Collections.Generic;

namespace MooGame
{
	class MainClass
	{
		
		public static void Main(string[] args)
		{

			bool playOn = true;
			UI ui = new UI();
			PlayerData playerData = new PlayerData();
			Logic logic = new Logic();
			FileTxtHandler fileHandler = new FileTxtHandler();
			playerData.SetName(ui);

			while (playOn)
			{
				string goal = logic.makeGoal();
				playerData.SetGuessTotal(1);

				Console.WriteLine("New game:\n");
				//comment out or remove next line to play real games!
				Console.WriteLine("For practice, number is: " + goal + "\n");
				
				playerData.SetGuess();
				logic.CheckResult(goal, playerData);

				fileHandler.SaveResult($"{playerData.GetName() + "#&#" + playerData.GetGuessTotal()}", "result.txt");
				fileHandler.showTopList();
				/*Bryt ut, Game Over Logic*/
				playOn = ui.GameOver(playerData);
				/***************/
			}
		}
	}
}