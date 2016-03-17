using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using WorkingWithCustomerClass;
using System.Diagnostics;
using System.Globalization;

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
                yield return new TestCaseData(null, null).Returns("Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData("NRP", null).Returns("Darth Vader, 123,456,789.00, +1 (111) 111-1111");
                yield return new TestCaseData("NR", null).Returns("Darth Vader, 123,456,789.00");
                yield return new TestCaseData("NP", null).Returns("Darth Vader, +1 (111) 111-1111");
                yield return new TestCaseData("PR", null).Returns("+1 (111) 111-1111, 123,456,789.00");
                yield return new TestCaseData("N", null).Returns("Darth Vader");
                yield return new TestCaseData("P", null).Returns("+1 (111) 111-1111");
                yield return new TestCaseData("R", null).Returns("123,456,789.00");
                yield return new TestCaseData(null, new CustomerFormatter()).Returns("DARTH VADER, 123456789,00, +1 (111) 111 11 11");
                yield return new TestCaseData("NRP", new CustomerFormatter()).Returns("DARTH VADER, 123456789,00, +1 (111) 111 11 11");
                yield return new TestCaseData("NR", new CustomerFormatter()).Returns("DARTH VADER, 123456789,00");
                yield return new TestCaseData("NP", new CustomerFormatter()).Returns("DARTH VADER, +1 (111) 111 11 11");
                yield return new TestCaseData("PR", new CustomerFormatter()).Returns("+1 (111) 111 11 11, 123456789,00");
                yield return new TestCaseData("N", new CustomerFormatter()).Returns("DARTH VADER");
                yield return new TestCaseData("P", new CustomerFormatter()).Returns("+1 (111) 111 11 11");
                yield return new TestCaseData("R", new CustomerFormatter()).Returns("123456789,00");
            }
        }
        [Test, TestCaseSource(nameof(TestMethodCalls))]
        public string ToString_StringOfCertainFormat(string format, IFormatProvider provider )
        {
            Customer current = new Customer("Darth Vader", "+1 (111) 111-1111", 123456789);
            return current.ToString(format, provider);
        }
    }

}
