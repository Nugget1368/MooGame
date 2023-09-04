using MooGame.Factories;
using MooGame.Player;
using MooGame.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MooGame.Controllers
{
	public static class PlayerController
	{
		public static void SetName(this IPlayerData player, IUI ui)
		{
			player.Name = ui.EnterName();
		}

		public static void SetGuess(this IPlayerData player, IUI ui)
		{
			player.SetGuess(ui.PlayerInput());
		}

		public static double PlayerScore(this IPlayerData player)
		{
			return (double)player.GuessTotal / player.NGames;
		}
	}
}
