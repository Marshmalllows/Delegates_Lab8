namespace delegates;

public class Student : Person
{
    public int LearningYear { get; }

    public List<Test> CompletedTests = new List<Test>();

    public List<int> Statistics = new List<int>();
    
    public Student() : base()
    {
        Console.Write("Enter learning year:");
        var parsed = false;
        var input = 0;
        do
        {
            if (int.TryParse(Console.ReadLine(), out input) || input <= 0)
            {
                parsed = true;
                LearningYear = input;
            }
            else
            {
                Console.Write("Invalid input.Enter again:");
            }
        } while (!parsed);
    }

    public void TestSearch()
    {
        var isDone = false;

        do
        {
            Console.WriteLine("Search by:\n" +
                              "1.Test name\n" +
                              "2.Teacher first name\n" +
                              "3.Teacher last name\n" +
                              "4.Teacher lesson\n" +
                              "Esc.Back");
            var searchMethod = Console.ReadKey(intercept: true);
            var testExist = false;
            switch (searchMethod.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Enter test name:");
                    var testName = Console.ReadLine();
                    for (var i = 0; i < DataBase.Teachers.Count; i++)
                    {
                        for (var j = 0; j < DataBase.Teachers[i].Tests.Count; j++)
                        {
                            if (DataBase.Teachers[i].Tests[j].Name == testName)
                            {
                                Console.WriteLine($"{i + 1}.{j + 1}.Test:{DataBase.Teachers[i].Tests[j].Name}\n" +
                                                  $"Teacher:{DataBase.Teachers[i].FirstName} {DataBase.Teachers[i].LastName}\n" +
                                                  $"Lesson:{DataBase.Teachers[i].Lesson}\n" +
                                                  $"Questions:{DataBase.Teachers[i].Tests[j].Questions.Count}");
                                testExist = true;
                            }
                        }
                    }

                    if (!testExist)
                    {
                        Console.Clear();
                        Console.WriteLine("Test is not found");
                        break;
                    }
                    Console.Write("\nEnter test code to do (x.y):");
                    var codeName = Console.ReadLine();
                    var codesName = codeName.Split(".");
                    Quiz(DataBase.Teachers[int.Parse(codesName[0]) - 1].Tests[int.Parse(codesName[1]) - 1]);
                    break;
                case ConsoleKey.D2:
                    Console.Write("Enter teacher`s first name:");
                    var teacherFirstName = Console.ReadLine();
                    for (var i = 0; i < DataBase.Teachers.Count; i++)
                    {
                        if (DataBase.Teachers[i].FirstName == teacherFirstName)
                        {
                            for (var j = 0; j < DataBase.Teachers[i].Tests.Count; j++)
                            {
                                Console.WriteLine($"{i + 1}.{j + 1}.Test:{DataBase.Teachers[i].Tests[j].Name}\n" +
                                                  $"Teacher:{DataBase.Teachers[i].FirstName} {DataBase.Teachers[i].LastName}\n" +
                                                  $"Lesson:{DataBase.Teachers[i].Lesson}\n" +
                                                  $"Questions:{DataBase.Teachers[i].Tests[j].Questions.Count}");
                                testExist = true;
                            }
                        }
                    }

                    if (!testExist)
                    {
                        Console.Clear();
                        Console.WriteLine("Test is not found");
                        break;
                    }
                    Console.Write("\nEnter test code to do (x.y):");
                    var codeFirstName = Console.ReadLine();
                    var codesFirstName = codeFirstName.Split(".");
                    Quiz(DataBase.Teachers[int.Parse(codesFirstName[0]) - 1].Tests[int.Parse(codesFirstName[1]) - 1]);
                    break;
                case ConsoleKey.D3:
                    Console.Write("Enter teacher`s last name:");
                    var teacherLastName = Console.ReadLine();
                    for (var i = 0; i < DataBase.Teachers.Count; i++)
                    {
                        if (DataBase.Teachers[i].LastName == teacherLastName)
                        {
                            for (var j = 0; j < DataBase.Teachers[i].Tests.Count; j++)
                            {
                                Console.WriteLine($"{i + 1}.{j + 1}.Test:{DataBase.Teachers[i].Tests[j].Name}\n" +
                                                  $"Teacher:{DataBase.Teachers[i].FirstName} {DataBase.Teachers[i].LastName}\n" +
                                                  $"Lesson:{DataBase.Teachers[i].Lesson}\n" +
                                                  $"Questions:{DataBase.Teachers[i].Tests[j].Questions.Count}");
                                testExist = true;
                            }
                        }
                    }

                    if (!testExist)
                    {
                        Console.Clear();
                        Console.WriteLine("Test is not found");
                        break;
                    }
                    Console.Write("\nEnter test code to do (x.y):");
                    var codeLastName = Console.ReadLine();
                    var codesLastName = codeLastName.Split(".");
                    Quiz(DataBase.Teachers[int.Parse(codesLastName[0]) - 1].Tests[int.Parse(codesLastName[1]) - 1]);
                    break;
                case ConsoleKey.D4:
                    Console.Write("Enter teacher`s lesson:");
                    var teacherLesson = Console.ReadLine();
                    for (var i = 0; i < DataBase.Teachers.Count; i++)
                    {
                        if (DataBase.Teachers[i].Lesson == teacherLesson)
                        {
                            for (var j = 0; j < DataBase.Teachers[i].Tests.Count; j++)
                            {
                                Console.WriteLine($"{i + 1}.{j + 1}.Test:{DataBase.Teachers[i].Tests[j].Name}\n" +
                                                  $"Teacher:{DataBase.Teachers[i].FirstName} {DataBase.Teachers[i].LastName}\n" +
                                                  $"Lesson:{DataBase.Teachers[i].Lesson}\n" +
                                                  $"Questions:{DataBase.Teachers[i].Tests[j].Questions.Count}");
                                testExist = true;
                            }
                        }
                    }

                    if (!testExist)
                    {
                        Console.Clear();
                        Console.WriteLine("Test is not found");
                        break;
                    }
                    Console.Write("\nEnter test code to do (x.y):");
                    var codeLesson = Console.ReadLine();
                    var codesLesson = codeLesson.Split(".");
                    Quiz(DataBase.Teachers[int.Parse(codesLesson[0]) - 1].Tests[int.Parse(codesLesson[1]) - 1]);
                    break;
                case ConsoleKey.Escape:
                    isDone = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isDone);
    }

    private void Quiz(Test test)
    {
        Console.Clear();
        CompletedTests.Add(test);
        var statPlace = CompletedTests.Count - 1;
        var corrects = 0;
        
        Console.WriteLine($"Welcome to {test.Name} test!");
        Console.WriteLine($"You have {test.QuestionTime} seconds for each question!\n" +
                          $"Enter '0' to exit!\n");

        for (var i = 0; i < test.Questions.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{test.Questions[i].Contents}");
            for (var j = 0; j < test.Questions[i].Answers.Count; j++)
            {
                Console.WriteLine($"  {j + 1}.{test.Questions[i].Answers[j].Content}");
            }

            var remainingTime = test.QuestionTime;
            var timer = new Timer(_ =>
            {
                remainingTime--;
                Console.Write($"\rTime: {remainingTime} seconds. Answer:");
                if (remainingTime == 0)
                {
                    Console.WriteLine("\nTime is up!");
                    ((Timer)_).Dispose();
                }
            }, null, 1000, 1000);

            var answer = int.Parse(Console.ReadLine());
            timer.Dispose();

            if (answer == 0)
            {
                Statistics.Add((corrects / test.Questions.Count) * 100);
                return;
            }
            
            if (test.Questions[i].Answers[answer - 1].IsTrue)
            {
                Console.WriteLine("Correct!\n");
                corrects++;
            }
            else
            {
                Console.WriteLine("Wrong!\n");
            }

        }

        Console.Clear();
        Statistics.Add(100 * corrects / test.Questions.Count);
        Console.WriteLine($"Test is done! You got {Statistics[statPlace]}%");
        Console.ReadKey(intercept: true);
    }
}