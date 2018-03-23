using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace NETMP.Module2.Parser
{
    public class Parser
    {
        private readonly Regex _digitsRegex;

        public Parser()
        {
            _digitsRegex = new Regex("[0-9]+", RegexOptions.Compiled);
        }

        public int ParseToInt(string value)
        {
            if (!ContainsOnlyDigits(value))
            {
                throw new ArgumentException("Can not parse to int value. Value contains not digit symbols.");
            }

            return ToDigit(value);
        }

        public int? TryParseToInt(string value)
        {
            try
            {
                return ParseToInt(value);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private int ToDigit(string value)
        {
            int result = 0;

            var charArray = value.ToCharArray().Reverse().ToArray();

            for (int i = 0; i < charArray.Length; i++)
            {
                if (i == charArray.Length - 1)
                {
                    if (IsMinusSymbol(charArray[i]))
                    {
                        result = -result;
                        break;
                    }
                }

                result += GetDigitFromChar(charArray[i]) * GetTenInDegree(i);
            }

            return result;
        }

        private bool ContainsOnlyDigits(string value)
        {
            return _digitsRegex.IsMatch(value);
        }

        private bool IsMinusSymbol(char symbol)
        {
            return symbol == 45;
        }

        private int GetDigitFromChar(char digitChar)
        {
            var digitCode = (int)digitChar;

            switch (digitCode)
            {
                case 48: return 0;
                case 49: return 1;
                case 50: return 2;
                case 51: return 3;
                case 52: return 4;
                case 53: return 5;
                case 54: return 6;
                case 55: return 7;
                case 56: return 8;
                case 57: return 9;
            }

            return -1;
        }

        private int GetTenInDegree(int degree)
        {
            var result = 1;

            while (degree > 0)
            {
                result *= 10;
                degree--;
            }

            return result;
        }
    }
}
