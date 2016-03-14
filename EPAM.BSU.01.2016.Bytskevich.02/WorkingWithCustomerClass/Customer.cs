using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace WorkingWithCustomerClass
{
    public class Customer
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
            if (provider == null)
            {
                if (String.IsNullOrEmpty(format))
                    format = "NRP";
                format = format.ToUpper();
                switch (format)
                {
                    case "NRP":
                        return String.Format("Customer record: {0}, {1}, {2}", Name, Revenue.ToString("N2", new CultureInfo("en-US", false).NumberFormat), ContactPhone);
                    case "NR":
                        return String.Format("Customer record: {0}, {1}", Name, Revenue.ToString("N2", new CultureInfo("en-US", false).NumberFormat));
                    case "NP":
                        return String.Format("Customer record: {0}, {1}", Name, ContactPhone);
                    case "PR":
                        return String.Format("Customer record: {0}, {1}", ContactPhone, Revenue.ToString("N2", new CultureInfo("en-US", false).NumberFormat));
                    case "P":
                        return String.Format("Customer record: {0}", ContactPhone);
                    case "N":
                        return "Customer record: " + Name;
                    case "R":
                        return String.Format("Customer record: {0}", Revenue);
                    default:
                        throw new FormatException(String.Format("The '{0}' format specifier is not supported.", format));
                }
            }
            else
            {
                return String.Format(provider, "{0}, {1}, {2:phone}", Name, Revenue, ContactPhone);
            }
        }

    }
}
