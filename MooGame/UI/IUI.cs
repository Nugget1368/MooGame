using MooGame.Player;

namespace MooGame.UI
{
    public interface IUI
    {
        string EnterName();
        bool GameOver(IPlayer data);
        void HighScore(List<IPlayer> data);
        string PlayerInput();
        bool Result(string checkResult);
    }
}