using MooGame.Player;

namespace MooGame.UI
{
    public interface IUI
    {
        string EnterName();
        bool GameOver(IPlayerData data);
        void HighScore(List<IPlayerData> data);
        string PlayerInput();
        bool Result(string checkResult);
    }
}