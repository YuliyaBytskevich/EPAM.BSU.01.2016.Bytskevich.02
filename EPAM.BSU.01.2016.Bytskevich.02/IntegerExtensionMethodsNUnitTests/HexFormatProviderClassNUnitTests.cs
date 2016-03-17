using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using HexFormatProviderForInteger;

namespace HexFormatProviderForIntegerNUnitTests
{
    [TestFixture]
    public class HexFormatProviderClassNUnitTests
    {
        [TestCase(0, Result = "0x0")]
        [TestCase(12345, Result = "0x3039")]
        [TestCase(999999999, Result = "0x3B9AC9FF")]
        [TestCase(-123456789, Result = "0xF8A432EB")]
        [TestCase(int.MaxValue, Result = "0x7FFFFFFF")]
        [TestCase(int.MinValue, Result = "0x80000000")]
        [TestCase(47.2, ExpectedException = typeof(ArgumentException))]
        public string ToHexString_FromNumber(int number)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider provider = new HexFormatProvider();
            return string.Format(provider, "{0:h}", number);
        }

        [TestCase(47, "{0:X}", Result = "2F")]
        [TestCase(.473, "{0:P}", Result = "47.30 %")]
        [TestCase(.473, "{0:P0}", Result = "47 %")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.73, "{0:C}", Result = "¤4.73")]
        [TestCase(4.7321, "{0:F2}", Result = "4.73")]
        public string ToStandartFormats_FromNumbers(object number, string format)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            IFormatProvider fp = new HexFormatProvider();
            return string.Format(fp, format, number);
        }


    }
}
