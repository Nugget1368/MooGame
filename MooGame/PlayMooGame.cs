using MooGame.Extenstions;
using MooGame.Factories;
using MooGame.FileHandling;
using MooGame.Logistics;
using MooGame.Player;
using MooGame.UI;

namespace MooGame;

/***********************************************************************************************************
 * Vi för in UI och FileHanlder i parametern för att det är sådant som vi högst troligen kan vilja byta ut
 * till t.ex ett annat form av UI (WPF-Forms) eller en annan FileHandler (JSON)
 *********************************************************************************************************/
class PlayMooGame : IPlayGame
{
	IFileHandler FileHandler;
	IUI Ui;
	IPlayerData PlayerData;
	MooGameLogic logic;
	public PlayMooGame()
	{
		this.FileHandler = Factory.CreateFileHandler();
		this.Ui = Factory.CreateUI();
		this.PlayerData = Factory.CreatePlayerData();
		this.logic = Factory.CreateLogic();
	}

	public void StartGame(bool playOn)
	{
		string saveFile = "result.txt";
		PlayerData.SetName(Ui.EnterName());

		while (playOn)
		{
			string goal = logic.makeGoal();
			PlayerData.ResetGuessTotal();

			Console.WriteLine("New game:\n");
			//comment out or remove next line to play real games!
			Console.WriteLine("For practice, number is: " + goal + "\n");

			PlayerData.SetGuess(Ui.PlayerInput());
			while (Ui.Result(logic.CheckResult(goal, PlayerData.Guess)) != true)
			{
				PlayerData.SetGuess(Ui.PlayerInput());
			}

			string textSave = $"{PlayerData.Name + "#&#" + PlayerData.GuessTotal}";
			FileHandler.SaveResult(textSave, saveFile);
			Ui.HighScore(FileHandler.showTopList(saveFile));

			playOn = Ui.GameOver(PlayerData);
		}
	}
}
