namespace delegates;

public class Test
{
    public List<Question> Questions = new List<Question>();
    
    public string Name { get; set; }
    
    public int QuestionTime { get; set; }

    public Test()
    {
        Console.Write("Enter test name:");
        Name = Console.ReadLine();
        Console.Write("Enter question time:");
        var parsed = false;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out var value))
            {
                Console.Write("Invalid input.Try again");
            }
            else if (value <= 0)
            {
                Console.Write("Invalid value.Try again");
            }
            else
            {
                QuestionTime = value;
                parsed = true;
            }
        } while (!parsed);
        Console.Clear();
    }
}