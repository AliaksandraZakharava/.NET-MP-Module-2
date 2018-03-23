using System;

namespace NETMP.Module2.GetFirstSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            var dialogManager = new ConsoleDialogManager();

            var inputted = string.Empty;
            var toContinue = true;

            while (toContinue)
            {
                dialogManager.DisplayStartMessage();

                inputted = dialogManager.GetInputtedString();

                dialogManager.DisplayFirstSymbol(inputted);

                toContinue = dialogManager.GetContinueTestingDecision();
            }
        }
    }
}
