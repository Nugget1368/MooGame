using MooGame.Controllers;

namespace MooGame.Factories;

public static class ControllerFactory
{
	public static IFileController CreateFileController()
	{
		return new TxtFileController();
	}

	public static IPlayerController CreatePlayerController()
	{
		return new PlayerController();
	}
}
