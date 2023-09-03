using MooGame.Factories;
using MooGame.FileHandling;
using MooGame.Player;
using MooGame.UI;

namespace MooGame;
class MainClass
{
	public static void Main(string[] args)
	{
		IPlayGame playGame = Factory.CreateGame();

		bool playOn = true;
		playGame.StartGame(playOn);
	}
}