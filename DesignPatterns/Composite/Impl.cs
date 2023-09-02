using DesignPatterns.Composite;
using DesignPatterns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.impl
{


    public interface IHasCustomers
    {
        IEnumerable<ICustomer> GetView();
    };

    public class Advisor : IHasCustomers, IAdvisor
    {
        public Advisor(int id, List<ICustomer> customers, List<IAdvisor> mirrors)
        {
            Id = id;
            Customers = customers;
            Mirrors = mirrors;
        }
        public int Id { get; set; }
        public IEnumerable<ICustomer> Customers { get; set; }

        public IEnumerable<IAdvisor>? Mirrors { get; set; }
        public IEnumerable<ICustomer> GetView()
        {
            var teste = Customers.Union(Mirrors?.SelectMany(x => x.GetView())!);
            return teste;
        }
    }
    public class Customer : IEquatable<ICustomer>, ICustomer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }


        public bool Equals(ICustomer? other)
        {
            return other is ICustomer customer &&
                   Id.Equals(customer.Id) &&
                   Name == customer.Name;
        }
        public override bool Equals(object? obj) => Equals(obj as Customer);

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name);
        }
    }

    public class Office : IHasCustomers, IOffice
    {
        private readonly int Id;
        private List<IHasCustomers> Advisors;
        private List<Customer> Customers;
        public Office(int id, List<IHasCustomers> advisors)
        {
            Id = id;
            Advisors = advisors;
        }

        public IEnumerable<ICustomer> GetView()
        {
            return Customers
                .Union(Advisors
                        .SelectMany(x => x.GetView())
                        .Distinct());
        }

    }
    public static class Run
    {
        public static IEnumerable<ICustomer> It()
        {
            Advisor advisorA = new(1,
                CompositeData.AdvisorACustomers(),
                Enumerable.Empty<IAdvisor>().ToList());

            Advisor advisorB = new(2,
                CompositeData.AdvisorBCustomers(),
                new List<IAdvisor>() { advisorA });

            Office office = new(1,
                new List<IHasCustomers>() { advisorA, advisorB });

            return office.GetView();
        }
    }

}
