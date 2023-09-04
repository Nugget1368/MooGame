using MooGame.Player;
using MooGame.UI;

namespace MooGame.Controllers
{
	public interface IPlayerController
	{
		double PlayerScore(IPlayerData player);
		void SetGuess(IPlayerData player, IUI ui);
		void SetName(IPlayerData player, IUI ui);
	}
}