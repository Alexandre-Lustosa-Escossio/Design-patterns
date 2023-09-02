using impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class CompositeData
    {
        public static List<ICustomer> AdvisorACustomers()
        {
            return new List<ICustomer>()
            {
                new Customer(1,"A"),
                new Customer(2,"B"),
            };
        }

        public static List<ICustomer> AdvisorBCustomers()
        {
            return new List<ICustomer>()
            {
                new Customer(3, "C"),
                new Customer(4, "D"),
                new Customer(1, "A"),
            };
        }
    }
}
