using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using LooterHero.Models;

namespace LooterHero
{
    class UI
    {
        public Player Player { get; set; } = new Player();
        private readonly ItemSmith Blacksmith = new ItemSmith();

        public bool Run()
        {
            try
            {
                Console.WriteLine("Welcome to LooterHero");
                Console.WriteLine("Controls: [q] = Quit   [any_other_key] = Craft New Sword");
                bool keepRunning = true;
                while (keepRunning)
                {
                    keepRunning = PlayGame();
                }
                Console.WriteLine("Thanks for playing!");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        private bool PlayGame()
        {
            Sword newSword = Blacksmith.CraftSword(Player.Level);
            Player.LevelUp();
            Console.Write($"Sword Crafted - Level: {newSword.Level}  Attack: {newSword.Attack}\n");
            char userResponse = Console.ReadKey().KeyChar;
            switch (userResponse)
            {
                case 'q':
                    return false;
                default:
                    return true;
            }

        }
    }
}
