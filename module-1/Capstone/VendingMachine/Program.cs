using System;
using VendingMachine.Classes;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            // Keep program.cs minimal. All the work should happen in the classes

            // Instantiate a VirtualVendingMachine object. This will hold the balance for the machine
            // and the methods related to the vending machine
            VirtualVendingMachine vm = new VirtualVendingMachine();

            // Instantiate the VendingMachineCLI (command line interface). This object will be responsible
            // for the interaction with the user.
            VendingMachineCLI vendingMachineCLI = new VendingMachineCLI(vm);

            // Run the main method to start displaying menus to the user.
            vendingMachineCLI.Run();
        }
    }
}