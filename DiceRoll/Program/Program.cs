using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace DiceRole
{
    class Program
    {
        static ClGame DiceRoller = new ClGame();
        static void Main()
        {
            string filePath = "./rolls.txt";
            if (File.Exists(filePath))
            {
                string[] arr = File.ReadAllLines(filePath);
                foreach (string s in arr)
                {
                    DiceRoller.results.Add(int.Parse(s));
                }
            }
            while (true)
            {
                int inputNum;
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("================================");
                    Console.WriteLine("1. Add Die");
                    Console.WriteLine("2. Roll a Dice");
                    Console.WriteLine("3. List Rolls");
                    Console.WriteLine("4. Delete All Rolls");
                    Console.WriteLine("5. Roll All Dice");
                    Console.WriteLine("6. Calculate Key Values");
                    Console.WriteLine("7. Save all");
                    Console.WriteLine("8. Exit");
                    Console.WriteLine("Input Number for your desired action:");
                    string input = Console.ReadLine().Trim();
                    if (Int32.TryParse(input, out inputNum) && inputNum > 0 && inputNum < 9)
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Incorrect Input");
                    Console.WriteLine("Hit enter to continue");
                    Console.ReadLine();
                }

                switch (inputNum)
                {
                    case 1:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("Enter the number of sides for the dice");
                            string input = Console.ReadLine().Trim();
                            if (Int32.TryParse(input, out int sides) && inputNum > 0)
                            {
                                DiceRoller.AddDie(sides);
                                break;
                            }
                        }
                        Console.WriteLine("Dice Created");
                        Console.WriteLine("Hit enter to continue");
                        Console.ReadLine();
                        break;
                    case 2:
                        while (true)
                        {
                            Console.Clear();
                            Console.WriteLine("How many sides does this dice have?");
                            string input = Console.ReadLine().Trim();
                            if (Int32.TryParse(input, out int sides) && inputNum > 0)
                            {
                                Die dice = new Die(sides);
                                Console.WriteLine($"Rolling a {sides} sided dice roll was: {dice.roll()}");
                                Console.WriteLine("Hit enter to continue");
                                Console.ReadLine();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Incorrect Input");
                            }
                        }
                        break;
                    case 3:
                        Console.Clear();
                        listAllRolls();
                        Console.WriteLine("Hit enter to continue");
                        Console.ReadLine();
                        break;
                    case 4:
                        Console.Clear();
                        using (StreamWriter writer = new StreamWriter("./rolls.txt", false))
                        {
                            writer.Write("");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        if (DiceRoller.Dice == null)
                        {
                            Console.WriteLine("You must create a die before you can roll it");
                        }
                        else
                        {
                            DiceRoller.RollAllDice();
                            Console.WriteLine("Rolled all dice");
                        }
                        Console.WriteLine("Hit enter to continue");
                        Console.ReadLine();
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine($"Average:  {DiceRoller.GetAverage()}\nTotal: {DiceRoller.GetTotal()}");
                        Console.WriteLine("Hit enter to continue");
                        Console.ReadLine();
                        break;
                    case 7:
                        using (StreamWriter writer = new StreamWriter("./rolls.txt", false))
                        {
                            foreach (int i in DiceRoller.results)
                            {
                                writer.WriteLine(i);
                            }
                        }
                        Console.WriteLine("Saved");
                        Console.WriteLine("Hit enter to continue");
                        Console.ReadLine();
                        break;
                    case 8:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    
        static void listAllRolls()
        {
            while (true)
            {
                Console.Clear();
                foreach (int roll in DiceRoller.results)
                {
                    Console.WriteLine(roll);
                }
            }
        }
    }
}