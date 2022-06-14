using System;
namespace DiceRole
{
    public class Die {
        public int sides { get; set; }

        public Die()
        {
            this.sides = 6;
        }
        public Die(int sides)
        {
            this.sides = sides;
        }

        public int roll()
        {
            Console.WriteLine($"Rolling a {this.sides} sided dice");
            Random rnd = new Random();
            return rnd.Next(1, this.sides + 1);
        }
    }
}