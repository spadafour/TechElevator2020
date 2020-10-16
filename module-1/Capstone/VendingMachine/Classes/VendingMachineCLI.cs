using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using VendingMachine.Exceptions;

namespace VendingMachine.Classes
{
    /// <summary>
    /// This class will handle the interaction with the user. Good idea to separate
    /// this out so if we need to go to a different platform, we don't mess with our 
    /// core business logic
    /// </summary>
    public class VendingMachineCLI
    {
        /// <summary>
        /// Set up some constants for the menu selections to make the code easier to read
        /// </summary>
        private const string Option_DisplayPurchaseMenu = "2";
        private const string Option_DisplayVendingMachine = "1";
        private const string Option_InsertMoney = "1";
        private const string Option_MakeSelection = "2";
        private const string Option_Quit = "3";
        private const string Option_ReturnChange = "1";
        private const string Option_ReturnToPreviousMenu = "3";
        /// <summary>
        /// Store the vending machine object. Read only so once loaded we don't overwrite it
        /// </summary>
        private VirtualVendingMachine vm { get; }
        /// <summary>
        /// Constructor to get things going and have access to the vending machine
        /// </summary>
        /// <param name="vvm"></param>
        public VendingMachineCLI(VirtualVendingMachine vvm)
        {
            vm = vvm;
        }
        /// <summary>
        /// The first method executed. This controls the flow of the program
        /// </summary>
        public void Run()
        {
            //Put the title on the screen
            PrintTitle();
            do
            {
                // A blank line, then the first menu
                Console.WriteLine();
                DisplayMainMenu();
                // This this loop until I exit manually
            } while (true);

        }
        /// <summary>
        /// Helper method to put the title on the screen
        /// </summary>
        private void PrintTitle()
        {
            Console.WriteLine("Welcome to VVM");
        }
        /// <summary>
        /// The first menu
        /// </summary>
        private void DisplayMainMenu()
        {
            // Display the three possibilities
            Console.WriteLine("(1) Display Vending Machine Items");
            Console.WriteLine("(2) Purchase");
            Console.WriteLine("(3) Exit");
            // Read from the user, and trim off the spaces
            string input = Console.ReadLine().Trim();
            // Based on user input, take the appropriate action
            switch (input)
            {
                // Display the inventory
                case Option_DisplayVendingMachine:
                    DisplayInventory();
                    break;
                // Display the purchase menu
                case Option_DisplayPurchaseMenu:
                    DisplayPurchaseMenu();
                    break;
                // Close the application
                case Option_Quit:
                    Console.WriteLine("Thank you for your purchases.");
                    // Call the vending machine to calculate change
                    Console.WriteLine(vm.ReturnChange());
                    // Wait two seconds
                    Thread.Sleep(2000);
                    // Manuall close the program
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// This displays the current inventory to the screen
        /// </summary>
        private void DisplayInventory()
        {
            // Loop through the inventory dictionary
            foreach (KeyValuePair<string, Queue<VendingMachineItem>> kvp in vm.inventory)
            {
                // if the queue is empty, we are sold out.
                if (kvp.Value.Count == 0)
                {
                    // Create the sold out item for display
                    SoldOutItem soldOutItem = new SoldOutItem();
                    // Disply the sold out item
                    Console.WriteLine($"{kvp.Key.PadRight(4)} | {soldOutItem.itemName.PadRight(25)} | {soldOutItem.price:C2} | {soldOutItem.itemName.PadRight(5)}");
                }
                else
                {
                    // Display the first item in the queue using Peek()
                    Console.WriteLine($"{kvp.Key.PadRight(4)} | {kvp.Value.Peek().itemName.PadRight(25)} | {kvp.Value.Peek().price:C2} | {kvp.Value.Count}");
                }
            }
        }
        /// <summary>
        /// Display the purchase menu to the screen
        /// </summary>
        private void DisplayPurchaseMenu()
        {
            string input = "";
            do
            {
                // Clear the screen so it looks nicer.
                Console.Clear();
                // Write the options to the screen
                Console.WriteLine("(1) Feed Money");
                Console.WriteLine("(2) Select Product");
                Console.WriteLine("(3) Finish Transaction");
                // Show them their current balance formatted for local currency
                Console.WriteLine($"Current Money Provided: {vm.CurrentBalance:C2}");
                // Read from the user, and trim off the spaces
                input = Console.ReadLine().Trim();
                // Based on user input, take the appropriate action
                switch (input)
                {
                    // The want to add money, call the FeedMoney method in the virtual machine
                    case Option_InsertMoney:
                        // Need to prompt for how much, use AskForMoney helper method
                        vm.FeedMoney(AskForMoney());
                        break;
                    // Make a selection for purchase
                    case Option_MakeSelection:
                        MakeSelection();
                        break;
                    // Nothing to do if they selected quit
                    case Option_Quit:
                        
                        break;
                    default:
                        break;
                }
            // As long as they don't select Finish Transaction (3), loop this menu
            } while (input != "3");
        }
        /// <summary>
        /// Helper method to prompt the user for money
        /// </summary>
        /// <returns>An integer of money. No coins accepted</returns>
        private int AskForMoney()
        {
            // Set to the moneyToLoad to an invalid number
            int moneyToLoad = -1;
            do
            {
                // Prompt the user to add money.
                Console.WriteLine($"Insert money in whole dollar amounts:");
                // Read from the user, and trim off the spaces
                string input = Console.ReadLine().Trim();
                try
                {
                    // If we can parse the value, set it to moneyToLoad
                    moneyToLoad = int.Parse(input);
                }
                catch (Exception e)
                {
                    // If we can't parse, tell them why
                    Console.WriteLine($"Please only use numbers in your dollar amounts.");
                }
            // As long as moneyToLoad is -1, keep asking to load money
            } while (moneyToLoad < 0);
            // Have the method give back the money they loaded
            return moneyToLoad;
        }
        /// <summary>
        /// Helper method to choose a product to purchase
        /// </summary>
        private void MakeSelection()
        {
            string selection = "";
            do
            {
                // Show them the current inventory
                DisplayInventory();
                // Prompt them to make a selection
                Console.WriteLine($"Please Make a Selection.");
                Console.WriteLine($"Type Q to return to Main Menu.");
                // Read from the user, and trim off the spaces
                selection = Console.ReadLine().Trim();
                // Make sure they aren't wanting to quit
                if (!selection.ToLower().StartsWith("q"))
                {
                    // Clear the screen for better UX
                    Console.Clear();
                    try
                    {
                        // Call the purchase menu on the vending machine and capture the purchased item. Trim to remove spaces
                        VendingMachineItem vmi = vm.Purchase(selection.ToUpper());
                        // Tell the user what they purchases
                        Console.WriteLine($"You purchased {vmi.itemName} for {vmi.price:C2}");
                        // Listen to the user eat their purchase
                        Console.WriteLine(vmi.Consume());
                    }
                    catch (VendingMachineException e)
                    {
                        // Any errors, write them to the screen
                        Console.WriteLine(e.Message);
                    }

                }
            // Make sure they aren't wanting to quit
            } while (!selection.ToLower().StartsWith("q"));

        }
    }
}
