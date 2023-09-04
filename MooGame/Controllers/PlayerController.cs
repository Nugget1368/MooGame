﻿using MooGame.Factories;
using MooGame.Player;
using MooGame.UI;

namespace MooGame.Controllers
{
	public class PlayerController : IPlayerController
	{
		//Singleton
		private static IPlayerController instance;
		public static IPlayerController Instance
		{
			get
			{
				if (instance == null)
					instance = ControllerFactory.CreatePlayerController();
				return instance;
			}
		}
		public void SetName(IPlayerData player, string name)
		{
			player.Name = name;
		}

		public void SetGuess(IPlayerData player, string guess)
		{
			player.SetGuess(guess);
		}

		public double PlayerScore(IPlayerData player)
		{
			return (double)player.GuessTotal / player.NGames;
		}
	}
}
