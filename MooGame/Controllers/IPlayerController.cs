using MooGame.Player;
using MooGame.UI;

namespace MooGame.Controllers
{
	public interface IPlayerController
	{
		double PlayerScore(IPlayerData player);
		void SetGuess(IPlayerData player, string guess);
		void SetName(IPlayerData player, string name);
	}
}