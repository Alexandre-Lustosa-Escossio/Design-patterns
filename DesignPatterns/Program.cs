// See https://aka.ms/new-console-template for more information
using DesignPatterns;
using DesignPatterns.Composite;
using DesignPatterns.impl;
using System.Runtime.InteropServices;

#region Strategy
public interface ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input);
}

public class SortAscendingStrategy : ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input)
    {
        return input.OrderBy(x => x);
    }
}

public class SortDescendingStrategy : ISortStrategy
{
    public IOrderedEnumerable<string> Sort(IEnumerable<string> input)
    {
        return input.OrderByDescending(x => x);
    }
}

public class SortableCollection
{
    public ISortStrategy SortStrategy { get; set; }
    public IEnumerable<string> Items { get; private set; }

    public SortableCollection(IEnumerable<string> items)
    {
        Items = items;
    }

    public void Sort()
    {
        if (SortStrategy == null)
        {
            throw new NullReferenceException("Sort strategy not found.");
        }
        Items = SortStrategy.Sort(Items);

    }
}

#endregion

#region Abstract Factory
public interface ICar { }
public interface IBike { }
public class LowGradeCar : ICar { }
public class LowGradeBike : IBike { }
public class HighGradeCar : ICar { }
public class HighGradeBike : IBike { }
public interface IVehicleFactory
{
    ICar CreateCar();
    IBike CreateBike();
}
public class LowGradeVehicleFactory : IVehicleFactory
{
    public IBike CreateBike() => new LowGradeBike();
    public ICar CreateCar() => new LowGradeCar();
}
public class HighGradeVehicleFactory : IVehicleFactory
{
    public IBike CreateBike() => new HighGradeBike();
    public ICar CreateCar() => new HighGradeCar();
}



#endregion

#region Decorator
public interface IComponent
{
    string Operation();
}

public class BaseComponent : IComponent
{
    public string Operation()
    {
        return $"Hello from {nameof(BaseComponent)}";
    }
}

public class DecoratorAComponent : IComponent
{
    private IComponent Component { get; set; }

    public DecoratorAComponent(IComponent component)
    {
        Component = component;
    }

    public string Operation()
    {
        var result = Component.Operation();
        return $"<DecoratorA>{result}</DecoratorA>";
    }
}

public class DecoratorBComponent : IComponent
{
    private IComponent Component { get; set; }

    public DecoratorBComponent(IComponent component)
    {
        Component = component;
    }
    public string Operation()
    {
        var result = Component.Operation();
        return $"<DecoratorB>{result}</DecoratorB>";
    }
}
#endregion

#region Composite

var customerView = Run.It();

foreach (var customer in customerView)
{
    Console.WriteLine(customer.Name);
}

#endregion