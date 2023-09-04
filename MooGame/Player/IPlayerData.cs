﻿namespace MooGame.Player
{
    public interface IPlayerData
    {
        string Name { get; set; }
        int NGames { get; }
        int GuessTotal { get; }
        string Guess { get; }

        bool Equals(object p);
        int GetHashCode();
        void ResetGuessTotal();
        void SetGuess(string guess);
        void Update(int guesses);
    }
}