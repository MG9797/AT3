using System;
using System.Collections.Generic;
namespace DiceRole
{
    public abstract class Game {
        public List<Die> Dice { get; set; }

        public Game()
        {
            Dice = new List<Die>();
        }

        public abstract int RollAllDice();

        public abstract void AddDie(int sides);
    }
}