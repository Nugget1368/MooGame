using MooGame.Player;

namespace MooGame.FileHandling
{
    public interface IFileHandler
    {
        void SaveResult(string savedText, string filename);
        List<IPlayer> ShowTopList(string filename);
    }
}