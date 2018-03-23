using System;
using System.Text.RegularExpressions;

namespace NETMP.Module2.GetFirstSymbol
{
    public class ConsoleDialogManager
    {
        private readonly Regex _answerRegex;

        public ConsoleDialogManager()
        {
            _answerRegex = new Regex("^(y|n)?$", RegexOptions.Compiled);
        }

        public void DisplayStartMessage()
        {
            Console.WriteLine($"{Environment.NewLine}Please, input text line:{Environment.NewLine}");
        }

        public void DisplayFirstSymbol(string inputted)
        {
            Console.WriteLine($"{Environment.NewLine}The first symbol of the inputted string: {inputted[0]}{Environment.NewLine}");
        }

        public string GetInputtedString()
        {
            var inputted = Console.ReadLine();

            while (string.IsNullOrEmpty(inputted))
            {
                Console.WriteLine($"You have not inputted a text line. Please, try again:{Environment.NewLine}");
                inputted = Console.ReadLine();
            }

            return inputted.Trim();
        }

        public bool GetContinueTestingDecision()
        {
            Console.WriteLine($"Would you like to go on testing? (y/n){Environment.NewLine}");

            var input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || !_answerRegex.IsMatch(input))
            {
                Console.WriteLine($"{Environment.NewLine}Please, input 'y' or 'n' value.{Environment.NewLine}");
                input = Console.ReadLine()?.Trim();
            }

            return input == "y";
        }
    }
}
