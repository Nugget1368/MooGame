using MooGame.Controllers;
using MooGame.Factories;
using MooGame.Player;

namespace MooGame.FileHandling
{
    /* ****************************************************************************************
	 * Gör ett uinterface där Filehandlern är anpassad för flera olika spel med andra filnamn, 
	 * andra krav på Append. Andra sätt att skriva sparfilen?
	 ****************************************************************************/
    public class FileTxtHandler : IFileHandler
    {
		IFileController fileController = Factory.CreateFileController();
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
            results.Sort((p1, p2) => p1.PlayerScore(p1.GuessTotal, p1.NGames).CompareTo(p2.PlayerScore(p2.GuessTotal, p2.NGames)));
            return results;
        }		
	}
}