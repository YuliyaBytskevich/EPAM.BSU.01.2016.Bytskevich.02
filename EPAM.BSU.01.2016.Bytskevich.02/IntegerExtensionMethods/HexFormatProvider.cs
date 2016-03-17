using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HexFormatProviderForInteger
{
    public class HexFormatProvider: IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        public string Format(string format, object arg, IFormatProvider provider)
        {
            if (arg == null)
                throw new ArgumentNullException();
            if (string.IsNullOrEmpty(format))
                format = "H";
            format = format.ToUpper();
            switch (format)
            {
                case "H":
                {
                        if (arg.GetType() != typeof(int))
                            throw new ArgumentException();
                        return TurnIntoHexFormatString((int) arg);
                }
                default:
                    return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
        }

        private string TurnIntoHexFormatString(int number)
        {
            char[] equvalents = new char[16] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F'};
            string intermediateResult = "";
            bool numberIsNegative = number < 0;
            number = numberIsNegative ? -(number+1) : number;
            if (number != 0)
            {
                while (number > 1)
                {
                    int rest = number % 16;
                    number /= 16;
                    if (!numberIsNegative)
                        intermediateResult += equvalents[rest];
                    else
                        intermediateResult += equvalents[15 - rest];
                }
                if (numberIsNegative)
                {
                    int startIndex = intermediateResult.Length;
                    for (int i = startIndex; i < 8; i++)
                        intermediateResult += 'F';
                }
                char[] charArray = intermediateResult.ToCharArray();
                Array.Reverse(charArray);
                return ("0x" + new string(charArray));
            }
            return "0x0";
        }
    }




}
