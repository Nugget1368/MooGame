using MooGame.Controllers;
using MooGame.Factories;
using MooGame.Player;
using MooGame.UI;

namespace MooGame.Extenstions;
public static class PlayerExtension
{
    public static void SetName(this IPlayerData player, IUI ui)
    {
        IPlayerController controller = PlayerController.Instance;
        controller.SetName(player, ui);
    }

    public static void SetGuess(this IPlayerData player, IUI ui)
    {
		IPlayerController controller = PlayerController.Instance;
		controller.SetGuess(player, ui);
    }

    public static double PlayerScore(this IPlayerData player)
    {
		IPlayerController controller = PlayerController.Instance;
		return controller.PlayerScore(player);
    }
}
