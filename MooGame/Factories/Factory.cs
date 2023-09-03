/***************************************************************
 * Factory - Gör det enklare att ändra t.ex UI eller PlayerData
 * utan att behöva göra flera små ändringar på olika ställen
 * i programmet.
 * Vi minskar risken för att råka ha sönder programmet när
 * vi vill ändra något.
 ***********************************************************/
using MooGame.Controllers;
using MooGame.FileHandling;
using MooGame.Logistics;
using MooGame.Player;
using MooGame.UI;

namespace MooGame.Factories;
public static class Factory
{
    public static IPlayerData CreatePlayerData()
    {
        return new PlayerData();
    }

    public static IUI CreateUI()
    {
        return new ConsoleUI();
    }

    public static IFileHandler CreateFileHandler()
    {
        return new FileTxtHandler();
    }

    public static IPlayGame CreateGame()
    {
        return new PlayMooGame();
    }

    public static Logic CreateLogic()
    {
        return new Logic();
    }

    public static IFileController CreateFileController()
    {
        return new TxtFileController();
    }
}
