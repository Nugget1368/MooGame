using MooGame.Player;
using MooGame.UI;

namespace MooGame.Controllers
{
	public interface IPlayerController
	{
		double PlayerScore(IPlayer player);
		void SetGuess(IPlayer player, string guess);
		void SetName(IPlayer player, string name);
	}
}