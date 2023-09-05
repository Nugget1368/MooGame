using MooGame.Extenstions;
using MooGame.Player;
namespace MooGame.UI;
public class ConsoleUI : IUI
{
    public string EnterName()
    {
        Console.WriteLine("Enter your user name:\n");
        string playerName = Console.ReadLine();
        while (playerName == "" || playerName == null)
        {
            Console.WriteLine("Enter your user name:\n");
			playerName = Console.ReadLine();
        }
        return playerName;
    }

    public bool Result(string checkResult)
    {
        Console.WriteLine(checkResult + "\n");
        if (checkResult != "BBBB,")
        {
            Console.WriteLine("Try again:");
            return false;
        }
        return true;
    }

    public string PlayerInput() //Gör metod-namnert tydligare, ex. CheckPlayeRInput nåt sånt
    {
        string input = "";
        while (input == "" || input == null)
        {
            input = Console.ReadLine();
        }
        return input;
    }
    public void HighScore(List<IPlayer> playerData)
    {
        Console.WriteLine("Player   games	average");
        foreach (var player in playerData)
        {
            Console.WriteLine($"{string.Format("{0,-9}{1,5:D}{2,9:F2}", player.Name, player.NumOfGames, player.PlayerScore())}");
        }
    }

    //Man vill generelt visa playerScore mm. så för in hela playern i GameOver
    //Men egentligen för just detta fall hade det räckt med GuessTotal från IPlayerData
    public bool GameOver(IPlayer playerData)
    {
        Console.WriteLine("Correct, it took " + playerData.NumOfGuesses + " guesses\nContinue?");
        if (PlayerInput().Substring(0, 1) == "n")
        {
            return false;
        }
        return true;
    }
}