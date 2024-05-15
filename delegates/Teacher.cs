namespace delegates;

public class Teacher : Person
{
    public string Lesson { get; }

    public List<Question> Questions = new List<Question>();

    public List<Test> Tests = new List<Test>();
    
    public Teacher() : base()
    {
        Console.Write("Enter lesson:");
        Lesson = Console.ReadLine();
    }

    public void ShowStatistics()
    {
        var testDone = false;

        for (var i = 0; i < DataBase.Students.Count; i++)
        {
            for (var j = 0; j < DataBase.Students[i].CompletedTests.Count; j++)
            {
                for (var k = 0; k < Tests.Count; k++)
                {
                    if (DataBase.Students[i].CompletedTests[j] == Tests[k])
                    {
                        Console.WriteLine($"Student:{DataBase.Students[i].FirstName} {DataBase.Students[i].LastName}\n" +
                                          $"Learning year:{DataBase.Students[i].LearningYear}\n" +
                                          $"Test:{Tests[j].Name}\n" +
                                          $"Right answers:{DataBase.Students[i].Statistics[j]}%\n");
                        testDone = true;
                    }
                }
            }
        }

        if (!testDone)
        {
            Console.WriteLine("There are no statistics yet");
        }
        Console.WriteLine("Press any key when done");
        Console.ReadKey(intercept: true);
    }

    private void CreateTest()
    {
        Tests.Add(new Test());
    }

    private void EditTest()
    {
        Console.Write("Enter test number:");
        var parsed = false;
        var testToEdit = 0;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out var value) || value > Tests.Count || value <= 0)
            {
                Console.WriteLine("Invalid input.Try again:");
            }
            else
            {
                parsed = true;
                testToEdit = value;
            }
        } while (!parsed);
        var isDone = false;

        do
        {
            Console.Clear();
            Console.WriteLine("1.Edit test name\n" +
                              "2.Edit question time\n" +
                              "3.Add question\n" +
                              "4.Remove question\n" +
                              "Esc.Back");
            var choiceTestEdit = Console.ReadKey(intercept: true);

            switch (choiceTestEdit.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Enter new test name:");
                    Tests[testToEdit - 1].Name = Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                    Console.Write("Enter new question time:");
                    Tests[testToEdit - 1].QuestionTime = int.Parse(Console.ReadLine());
                    Console.Clear();
                    break;
                case ConsoleKey.D3:
                    if (Questions.Count == 0)
                    {
                        Console.Write("There are no questions to add");
                        break;
                    }

                    var isFree = false;
                    for (var i = 0; i < Questions.Count; i++)
                    {
                        var isUsed = false;
                        for (var j = 0; j < Tests[testToEdit - 1].Questions.Count; j++)
                        {
                            if (Questions[i] == Tests[testToEdit - 1].Questions[j])
                            {
                                isUsed = true;
                            }
                        }

                        if (!isUsed)
                        {
                            Console.WriteLine($"{i + 1}.{Questions[i].Contents}");
                            isFree = true;
                        }
                    }
                    
                    if (!isFree)
                    {
                        Console.Write("There are no questions to add");
                        break;
                    }
                    
                    Console.Write("Enter question number to add:");
                    var questionToAdd = int.Parse(Console.ReadLine());
                    Tests[testToEdit - 1].Questions.Add(Questions[questionToAdd - 1]);
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    if (Tests[testToEdit - 1].Questions.Count == 0)
                    {
                        Console.WriteLine("There are no questions yet");
                        break;
                    }
                    Console.WriteLine($"Test:{Tests[testToEdit - 1].Name}");
                    for (var i = 0; i < Tests[testToEdit - 1].Questions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Tests[testToEdit - 1].Questions[i].Contents}");
                    }
                    Console.WriteLine("\nEnter question number to remove:");
                    var remove = int.Parse(Console.ReadLine());
                    Tests[testToEdit - 1].Questions.RemoveAt(remove - 1);
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    isDone = true;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isDone);
    }

    private void CreateQuestion()
    {
        Questions.Add(new Question());
    }

    private void EditQuestion()
    {
        Console.Write("Enter question number:");
        var parsed = false;
        var questionNumberEdit = 0;
        do
        {
            if (!int.TryParse(Console.ReadLine(), out var value) || value > Questions.Count || value <= 0)
            {
                Console.WriteLine("Invalid input.Try again:");
            }
            else
            {
                parsed = true;
                questionNumberEdit = value;
            }
        } while (!parsed);
        var isDone = false;
        do
        {
            Console.Clear();
            Console.WriteLine("1.Edit question content\n" +
                          "2.Edit answers\n" +
                          "3.Edit right answer\n" +
                          "4.Delete answer\n" +
                          "5.Add new answer\n" +
                          "Esc.Back");
            var choiceQuestionEdit = Console.ReadKey(intercept: true);

            switch (choiceQuestionEdit.Key)
            {
                case ConsoleKey.D1:
                    Console.Write("Enter new contents:");
                    Questions[questionNumberEdit - 1].Contents = Console.ReadLine();
                    break;
                case ConsoleKey.D2:
                    Console.WriteLine($"Question:{Questions[questionNumberEdit - 1].Contents}");
                    for (var i = 0; i < Questions[questionNumberEdit - 1].Answers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Questions[questionNumberEdit - 1].Answers[i].Content}");
                    }
                    Console.Write("\nEnter answer number you want to edit:");
                    var answerNumber = int.Parse(Console.ReadLine());
                    Console.Write("Enter new contents:");
                    Questions[questionNumberEdit - 1].Answers[answerNumber - 1].Content = Console.ReadLine();
                    break;
                case ConsoleKey.D3:
                    Console.WriteLine($"Question:{Questions[questionNumberEdit - 1].Contents}");
                    for (var i = 0; i < Questions[questionNumberEdit - 1].Answers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Questions[questionNumberEdit - 1].Answers[i].Content}");
                        Questions[questionNumberEdit - 1].Answers[i].IsTrue = false;
                    }
                    Console.Write("\nEnter new right answer number:");
                    var newRightAnswer = int.Parse(Console.ReadLine());
                    Questions[questionNumberEdit - 1].Answers[newRightAnswer - 1].IsTrue = true;
                    break;
                case ConsoleKey.D4:
                    if (Questions.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no questions yet");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"Question:{Questions[questionNumberEdit - 1].Contents}");
                    var rightAnswer = 0;
                    for (var i = 0; i < Questions[questionNumberEdit - 1].Answers.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Questions[questionNumberEdit - 1].Answers[i].Content}");
                        if (Questions[questionNumberEdit - 1].Answers[i].IsTrue)
                        {
                            rightAnswer = i;
                        }
                    }
                    Console.Write("Enter answer number you want to delete:");
                    var answerToDelete = int.Parse(Console.ReadLine());
                    Answer.Delete(Questions[questionNumberEdit - 1], answerToDelete - 1);

                    if (answerToDelete - 1 == rightAnswer)
                    {
                        Console.Clear();
                        Console.WriteLine($"Question:{Questions[questionNumberEdit - 1].Contents}");
                        for (var i = 0; i < Questions[questionNumberEdit - 1].Answers.Count; i++)
                        {
                            Console.WriteLine($"{i + 1}.{Questions[questionNumberEdit - 1].Answers[i].Content}");
                        }
                        Console.Write("Enter new right answer number:");
                        var newRightAnswerDel = int.Parse(Console.ReadLine());
                        Questions[questionNumberEdit - 1].Answers[newRightAnswerDel - 1].IsTrue = true;
                    }
                    break;
                case ConsoleKey.D5:
                    Console.Clear();
                    Console.Write("Enter answer contents:");
                    Questions[questionNumberEdit - 1].Answers.Add(new Answer(Console.ReadLine()));
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    isDone = true;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isDone);
    }
    
    public void QuestionsMenu()
    {
        var isEndQuestion = false;
        do
        {
            for (var i = 0; i < Questions.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Questions[i].Contents}");
            }
            Console.WriteLine("\n1.Show question answers\n" +
                              "2.Create question\n" +
                              "3.Edit question\n" +
                              "4.Delete question\n" +
                              "Esc.Back");
            var choiceQuestionMenu = Console.ReadKey(intercept: true);
            switch (choiceQuestionMenu.Key)
            {
                case ConsoleKey.D1:
                    if (Questions.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no questions yet");
                        break;
                    }
                    Console.Write("Enter question number:");
                    var questionNumberAnswers = int.Parse(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"Question:{Questions[questionNumberAnswers - 1].Contents}");
                    for (var i = 0; i < Questions[questionNumberAnswers - 1].Answers.Count; i++)
                    {
                        if (Questions[questionNumberAnswers - 1].Answers[i].IsTrue)
                        {
                            Console.WriteLine($"{i + 1}.{Questions[questionNumberAnswers - 1].Answers[i].Content} +");
                        }
                        else
                        {
                            Console.WriteLine($"{i + 1}.{Questions[questionNumberAnswers - 1].Answers[i].Content}");
                        }
                    }
                    Console.WriteLine("When done press any key");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    CreateQuestion();
                    break;
                case ConsoleKey.D3:
                    if (Questions.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no questions yet");
                        break;
                    }
                    EditQuestion();
                    break;
                case ConsoleKey.D4:
                    if (Questions.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no questions yet");
                        break;
                    }
                    Console.Write("Enter question number:");
                    if (!int.TryParse(Console.ReadLine(), out var questionNumberDelete))
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }
                    Question.Delete(Questions[questionNumberDelete - 1], this);
                    Console.Clear();
                    break;
                case ConsoleKey.Escape:
                    Console.Clear();
                    isEndQuestion = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isEndQuestion);
    }

    public void TestsMenu()
    {
        var isEndTests = false;

        do
        {
            for (var i = 0; i < Tests.Count; i++)
            {
                Console.WriteLine($"{i + 1}.{Tests[i].Name}");
            }
            Console.WriteLine("\n1.Show test questions and answers\n" +
                              "2.Edit test\n" +
                              "3.Create test\n" +
                              "4.Delete test\n" +
                              "Esc.Back");
            var choiceTestMenu = Console.ReadKey(intercept: true);

            switch (choiceTestMenu.Key)
            {
                case ConsoleKey.D1:
                    if (Tests.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no tests yet");
                        break;
                    }
                    Console.Write("Enter test number:");
                    if (!int.TryParse(Console.ReadLine(), out var testNum))
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($"Test:{Tests[testNum - 1].Name}");
                    for (var i = 0; i < Tests[testNum - 1].Questions.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}.{Tests[testNum - 1].Questions[i].Contents}");

                        for (var j = 0; j < Tests[testNum - 1].Questions[i].Answers.Count; j++)
                        {
                            Console.WriteLine($"  {j + 1}.{Tests[testNum - 1].Questions[i].Answers[j].Content}");
                        }
                    }
                    Console.Write("When done press any key");
                    Console.ReadKey(intercept: true);
                    Console.Clear();
                    break;
                case ConsoleKey.D2:
                    if (Tests.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no tests yet");
                        break;
                    }
                    EditTest();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    CreateTest();
                    break;
                case ConsoleKey.D4:
                    if (Tests.Count == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There are no tests yet");
                        break;
                    }
                    Console.Write("Enter test number:");
                    if (!int.TryParse(Console.ReadLine(), out var testDelete))
                    {
                        Console.WriteLine("Invalid Input");
                        break;
                    }
                    Tests.RemoveAt(testDelete - 1);
                    Console.Clear();
                    break;
                case ConsoleKey.Escape:
                    isEndTests = true;
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isEndTests);
    }
}