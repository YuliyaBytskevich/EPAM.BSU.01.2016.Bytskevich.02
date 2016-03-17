using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkingWithCustomerClass
{
    public class Customer: IFormattable
    {
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public decimal Revenue { get; set; }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            Name = name;
            ContactPhone = contactPhone;
            Revenue = revenue;
        }

        public override string ToString()
        {
            return ToString("NRP", null); 
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format))
                format = "NRP";
            format = format.ToUpper();
            if (provider == null)
                provider = new CultureInfo("en-US");
            switch (format)
            {
                case "NRP":
                    return String.Format(provider, "{0:N}, {1:N2}, {2:P}", Name, Revenue, ContactPhone);
                case "NR":
                    return String.Format(provider, "{0:N}, {1:N2}", Name, Revenue);
                case "NP":
                    return String.Format(provider, "{0:N}, {1:P}", Name, ContactPhone);
                case "PR":
                    return String.Format(provider, "{0:P}, {1:N2}", ContactPhone, Revenue);
                case "P":
                    return String.Format(provider, "{0:P}", ContactPhone);
                case "N":
                    return String.Format(provider, "{0:N}", Name);
                case "R":
                    return String.Format(provider, "{0:N2}", Revenue);
                default:
                    throw new FormatException(String.Format("The '{0}' format specifier is not supported.", format));
            }
        }
    }
}
