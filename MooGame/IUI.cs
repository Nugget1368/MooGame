namespace MooGame
{
	public interface IUI
	{
		string EnterName();
		bool GameOver(IPlayerData playerData);
		void HighScore(List<IPlayerData> data);
		string PlayerInput();
		bool Result(string checkResult);
	}
}