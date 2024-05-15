namespace delegates;

public class Person
{
    public string FirstName { get; }
    
    public string LastName { get; }

    protected Person()
    {
        Console.Write("Enter first name:");
        FirstName = Console.ReadLine();
        Console.Write("Enter last name:");
        LastName = Console.ReadLine();
    }
}