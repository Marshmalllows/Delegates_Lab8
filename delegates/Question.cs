namespace delegates;

public class Question
{
    public string Contents { get; set; }

    public List<Answer> Answers = new List<Answer>();

    public Question()
    {
        Console.Write("Enter question contents:");
        Contents = Console.ReadLine();
        Console.Write("How many answers you want to add:");
        var parsed = false;
        var amountOfAnswers = 0;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out amountOfAnswers))
            {
                Console.Write("Invalid input.Try again:");
            }
            else if (amountOfAnswers <= 1)
            {
                Console.Write("Invalid value.Try again:");
            }
            else
            {
                parsed = true;
            }
        } while (!parsed);
        Console.Write("1.Generate answers\n" +
                      "2.Write answers\n");
        var chosen = false;
        do
        {
            var choice = Console.ReadKey(intercept: true);
            switch (choice.Key)
            {
                case ConsoleKey.D1:
                    chosen = true;
                    var random = new Random();
                    const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                    for (var i = 0; i < amountOfAnswers; i++)
                    {
                        var answer = "";
                        var size = random.Next(5, 20);
                        for (var j = 0; j < size; j++)
                        {
                            answer += letters[random.Next(letters.Length)];
                        }
                        Answers.Add(new Answer(answer));
                    }
                    Console.WriteLine();
                    break;
                case ConsoleKey.D2:
                    chosen = true;
                    for (var i = 0; i < amountOfAnswers; i++)
                    {
                        Console.Write($"Enter answer No{i + 1}:");
                        Answers.Add(new Answer(Console.ReadLine()));
                    }
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!chosen);

        for (var i = 0; i < Answers.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{Answers[i].Content}");
        }
        Console.Write("Select right answer:");
        parsed = false;
        var rightAnswer = 0;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out rightAnswer))
            {
                Console.Write("Invalid input.Try again:");
            }
            else if (rightAnswer > amountOfAnswers || rightAnswer <= 0)
            {
                Console.Write("Invalid value.Try again:");
            }
            else
            {
                parsed = true;
            }
        } while (!parsed);
        
        Answers[rightAnswer - 1].IsTrue = true;
        Console.Clear();
    }

    public static void Delete(Question question, Teacher teacher)
    {
        question.Answers.Clear();
        teacher.Questions.Remove(question);
    }
}