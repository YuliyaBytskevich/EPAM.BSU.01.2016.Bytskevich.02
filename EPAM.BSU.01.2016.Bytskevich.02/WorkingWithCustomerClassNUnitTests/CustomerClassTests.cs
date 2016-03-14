using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WorkingWithCustomerClass;
using System.Diagnostics;

namespace WorkingWithCustomerClassNUnitTests
{
    [TestFixture]
    public class CustomerClassTests
    {
        CustomerFormatter formatter = new CustomerFormatter();
        public IEnumerable<TestCaseData> TestMethodCalls
        {
            get
            {
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), null, null).Returns("Customer record: Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NRP", null).Returns("Customer record: Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NR", null).Returns("Customer record: Darth Vader, 123,456,789.00");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NP", null).Returns("Customer record: Darth Vader, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "PR", null).Returns("Customer record: +1 (111) 111-1111, 123,456,789.00");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "N", null).Returns("Customer record: Darth Vader");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "R", null).Returns("Customer record: 123456789");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "P", null).Returns("Customer record: +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "it doesn't mean",  formatter).Returns(", , +1 (111) 111 11 11");
            }
        }

        [Test, TestCaseSource(nameof(TestMethodCalls))]
        public string ToString_StringOfCertainFormat(Customer current, string format, IFormatProvider provider)
        {
            Debug.WriteLine(current.ToString(format, provider));
            return current.ToString(format, provider);
        }
    }

    public class CustomerFormatter : IFormatProvider, ICustomFormatter
    {
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }
            else
            {
                if (String.IsNullOrEmpty(format))
                    format = "none";
                string customerString = arg.ToString();
                format = format.ToUpper();
                customerString = customerString.Replace(" ", "");
                customerString = customerString.Replace("-", "");
                customerString = customerString.Replace("(", "");
                customerString = customerString.Replace(")", "");
                switch (format)
                {
                    case "PHONE":
                        return customerString.Substring(0, 2) + " (" + customerString.Substring(2, 3) + ") " + customerString.Substring(5, 3) + " " + customerString.Substring(8, 2) + " " + customerString.Substring(10, 2);
                    case "NONE":
                        return "";
                    default:
                        throw new FormatException(
                                  String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
        }
    }

}
