using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using IntegerExtensionMethods;

namespace IntegerExtensionMethodsNUnitTests
{
    [TestFixture]
    public class ExtensionsForFormattedOutputClassNUnitTests
    {
        [TestCase(0, Result = "0")]
        [TestCase(12345, Result = "3039")]
        [TestCase(999999999, Result = "3B9AC9FF")]
        [TestCase(-123456789, Result = "FFFFFFFFF8A432EB")]
        [TestCase(Int64.MaxValue, Result = "7FFFFFFFFFFFFFFF")]
        [TestCase(Int64.MinValue, Result = "8000000000000000")]
        public string ToHexFormatString_FromNumber(Int64 number)
        {
            return number.ToHexFormatString();
        }
    }
}
