using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntegerExtensionMethods
{
    public static class ExtensionsForFormattedOutput
    {
        public static string ToHexFormatString(this Int64 number)
        {
            char[] equvalents = new char[16] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            string intermediateResult = "";
            bool numberIsNegative = number < 0;
            number = numberIsNegative ? -(number+1) : number;
            if (number != 0)
            {
                while (number > 1)
                {
                    Int64 rest = number % 16;
                    number /= 16;
                    if (!numberIsNegative)
                        intermediateResult += equvalents[rest];
                    else
                        intermediateResult += equvalents[15 - rest];
                }
                if (numberIsNegative)
                {
                    int startIndex = intermediateResult.Length;
                    for (int i = startIndex; i < 16; i++)
                        intermediateResult += 'F';
                }
                char[] charArray = intermediateResult.ToCharArray();
                Array.Reverse(charArray);
                return new string(charArray);
            }
            return "0";
        }
    }




}
