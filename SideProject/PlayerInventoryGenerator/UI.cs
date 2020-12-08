using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading;
using LooterHero.Models;

namespace LooterHero
{
    class UI
    {
        public Player Player { get; set; } = new Player();
        private readonly ItemSmith TreasureChest = new ItemSmith();
        private bool GotNewItem { get; set; } = false;

        public bool Run()
        {
            try
            {
                Console.WriteLine("Welcome to LooterHero");
                Console.WriteLine("Press [space] to start");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Controls: [q] = Quit   [any_other_key] = Craft New Sword");
                Console.WriteLine("Current Weapon: None");

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
            char userResponse = GetNewRandomItem();
            if (GotNewItem)
            {
                Console.SetCursorPosition(0, 1);
                Console.WriteLine($"Current Weapon: Lvl {Player.EquippedWeapon.Level} Sword - Atk: {Player.EquippedWeapon.Attack}");
                GotNewItem = false;
            }
            Console.SetCursorPosition(0, 4);
            Console.WriteLine("".PadRight(Console.BufferWidth));

            switch (userResponse)
            {
                case 'q':
                    Console.WriteLine($"\n");
                    return false;
                default:
                    return true;
            }
        }

        private char GetNewRandomItem()
        {
            int maxRand = 5;
            int randomItemRoll = new Random().Next(0, maxRand);
            int junkChanceMax = 3;

            if(randomItemRoll>=0 && randomItemRoll<junkChanceMax)
            {
                Console.SetCursorPosition(0, 3);
                Console.WriteLine($"You found a {TreasureChest.FindJunk()}.".PadRight(Console.BufferWidth));
            }
            else
            {
                Sword newSword = TreasureChest.CraftSword(Player.Level);
                Player.LevelUp();
                Console.SetCursorPosition(0, 3);

                Console.WriteLine($"Sword Crafted - Level: {newSword.Level}  Attack: {newSword.Attack}".PadRight(Console.BufferWidth));
                if (Player.EquippedWeapon == null || Player.EquippedWeapon.Attack < newSword.Attack)
                {
                    Console.WriteLine("Equipping new sword...");
                    Player.EquipWeapon(newSword);
                    GotNewItem = true;
                }
            }

            char continueKey = Console.ReadKey().KeyChar;
            Console.SetCursorPosition(0, 3);
            Console.WriteLine("".PadRight(Console.BufferWidth));
            return continueKey;
        }
    }
}
