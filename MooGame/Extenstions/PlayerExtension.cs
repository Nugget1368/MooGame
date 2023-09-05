using MooGame.Controllers;
using MooGame.Factories;
using MooGame.Player;
using MooGame.UI;

namespace MooGame.Extenstions;
public static class PlayerExtension
{
    public static void SetName(this IPlayer player, string name)
    {
        IPlayerController controller = PlayerController.Instance;
        controller.SetName(player, name);
    }

    public static void SetGuess(this IPlayer player, string guess)
    {
		IPlayerController controller = PlayerController.Instance;
		controller.SetGuess(player, guess);
    }

    public static double PlayerScore(this IPlayer player)
    {
		IPlayerController controller = PlayerController.Instance;
		return controller.PlayerScore(player);
    }
}
