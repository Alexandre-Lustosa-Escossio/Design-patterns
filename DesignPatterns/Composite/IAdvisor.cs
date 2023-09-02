// See https://aka.ms/new-console-template for more information

public interface IAdvisor
{
    IEnumerable<ICustomer> Customers { get; set; }
    int Id { get; set; }
    IEnumerable<IAdvisor>? Mirrors { get; set; }

    IEnumerable<ICustomer> GetView();
}