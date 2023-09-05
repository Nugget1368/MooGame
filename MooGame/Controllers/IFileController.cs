using MooGame.Player;

namespace MooGame.Controllers
{
    public interface IFileController
    {
        List<IPlayer> GetAllPlayers(StreamReader input);
		IPlayer GetSinglePlayer(StreamReader input, int id);
		void SavePlayer(string filename, string savedText);
	}
}