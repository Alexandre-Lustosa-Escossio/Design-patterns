// See https://aka.ms/new-console-template for more information

public interface ICustomer
{
    int Id { get; set; }
    string Name { get; set; }

    bool Equals(ICustomer? other);
    bool Equals(object? obj);
    int GetHashCode();
}