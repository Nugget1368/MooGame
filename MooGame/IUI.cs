namespace MooGame
{
	public interface IUI
	{
		string EnterName();
		bool GameOver(IPlayerData playerData);
		void HighScore(List<IPlayerData> data, Logic logic);
		string PlayerInput();
		void Result(string goal, IPlayerData playerData, Logic logic);
	}
}