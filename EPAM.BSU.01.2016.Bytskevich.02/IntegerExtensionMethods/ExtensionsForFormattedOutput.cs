using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerExtensionMethods
{
    public static class ExtensionsForFormattedOutput
    {
        //TODO: переписать, когда будет время, с custom formatter
        public static string ToHexFormatString(this Int64 number)
        {
            return String.Format("{0:X}", number);
        }
    }
}
