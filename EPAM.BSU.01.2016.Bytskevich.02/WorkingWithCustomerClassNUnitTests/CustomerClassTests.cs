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
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), null).Returns("Customer record: Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NRP").Returns("Customer record: Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NR").Returns("Customer record: Darth Vader, 123,456,789.00");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "NP").Returns("Customer record: Darth Vader, +1 (111) 111-1111");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "PR").Returns("Customer record: +1 (111) 111-1111, 123,456,789.00");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "N").Returns("Customer record: Darth Vader");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "R").Returns("Customer record: 123456789");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), "P").Returns("Customer record: +1 (111) 111-1111");
            }
        }

        public IEnumerable<TestCaseData> TestMethodCallsWithCustomFormatter
        {
            get
            {
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), formatter, "none", "none", "phone").Returns("  +1 (111) 111 11 11");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), formatter, "upper", "none", "phone").Returns("DARTH VADER  +1 (111) 111 11 11");
                yield return new TestCaseData(new Customer("Darth Vader", "+1 (111) 111-1111", 123456789), null, null, null, null).Throws(typeof(ArgumentNullException));
            }
        }

        [Test, TestCaseSource(nameof(TestMethodCalls))]
        public string ToString_StringOfCertainFormat(Customer current, string format)
        {
            Debug.WriteLine(current.ToString(format));
            return current.ToString(format);
        }

        [Test, TestCaseSource(nameof(TestMethodCallsWithCustomFormatter))]
        public string ToString_StringOfCertainCustomFormat(Customer current, IFormatProvider provider, string formatForName, string formatForRevenue, string formatForContactPhone)
        {
            Debug.WriteLine(current.ToString(provider, formatForName, formatForRevenue, formatForContactPhone));
            return current.ToString(provider, formatForName, formatForRevenue, formatForContactPhone);
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
                switch (format)
                {
                    case "PHONE":
                    {
                            customerString = customerString.Replace(" ", "");
                            customerString = customerString.Replace("-", "");
                            customerString = customerString.Replace("(", "");
                            customerString = customerString.Replace(")", "");
                            return customerString.Substring(0, 2) + " (" + customerString.Substring(2, 3) + ") " +
                               customerString.Substring(5, 3) + " " + customerString.Substring(8, 2) + " " +
                               customerString.Substring(10, 2);
                    }
                    case "NONE":
                        return "";
                    case "UPPER":
                        return customerString.ToUpper();
                    default:
                        throw new FormatException(String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
        }
    }

}
