using MooGame.Controllers;
using MooGame.Extenstions;
using MooGame.Factories;
using MooGame.Player;

namespace MooGame.FileHandling;
public class FileTxtHandler : IFileHandler
{
		IFileController fileController = ControllerFactory.CreateFileController();
    public void SaveResult(string savedText, string filename)
    {
        fileController.SavePlayer(savedText, filename);
		}

    public List<IPlayerData> showTopList(string filename)
    {
        StreamReader input = new StreamReader(filename);
        List<IPlayerData> results = fileController.GetAllPlayers(input);
        input.Close();

        return results = SortSaveFile(results);
    }
    private List<IPlayerData> SortSaveFile(List<IPlayerData> results)
    {
        results.Sort((p1, p2) => p1.PlayerScore().CompareTo(p2.PlayerScore()));
        return results;
    }		
	}