// See https://aka.ms/new-console-template for more information

namespace DesignPatterns.Composite
{
    public interface IOffice
    {
        IEnumerable<ICustomer> GetView();
    }
}