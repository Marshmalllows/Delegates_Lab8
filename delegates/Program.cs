using delegates;

public static class Program
{
    public static void Main()
    {
        var isEnd = false;

        do
        {
            Console.WriteLine("1.Enter system as a teacher\n" +
                              "2.Enter system as a student\n" +
                              "3.Add a teacher\n" +
                              "4.Add a student\n" +
                              "Esc: exit");
            var mainChoice = Console.ReadKey(intercept: true);

            switch (mainChoice.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    SysAsTeacher();
                    break;
                case ConsoleKey.D2:
                    Console.Clear();
                    SysAsStudent();
                    break;
                case ConsoleKey.D3:
                    Console.Clear();
                    AddTeacher();
                    break;
                case ConsoleKey.D4:
                    Console.Clear();
                    AddStudent();
                    break;
                case ConsoleKey.Escape:
                    isEnd = true;
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isEnd);
    }

    private static void SysAsTeacher()
    {
        if (DataBase.Teachers.Count == 0)
        {
            Console.WriteLine("There are no teachers yet. Press any button");
            Console.ReadKey(intercept: true);
            Console.Clear();
            return;
        }
        
        for (var i = 0; i < DataBase.Teachers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Name: {DataBase.Teachers[i].FirstName} {DataBase.Teachers[i].LastName}\n" +
                              $"Lesson: {DataBase.Teachers[i].Lesson}\n");
        }
        Console.Write("\nSelect a teacher:");
        
        if (!int.TryParse(Console.ReadLine(), out var teacherChosen) || teacherChosen > DataBase.Teachers.Count || teacherChosen <= 0)
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            return;
        }
        
        TeacherMenu(DataBase.Teachers[teacherChosen - 1]);
        Console.Clear();
    }

    private static void SysAsStudent()
    {
        if (DataBase.Students.Count == 0)
        {
            Console.WriteLine("There are no students yet. Press any button");
            Console.ReadKey(intercept: true);
            Console.Clear();
            return;
        }
        
        for (var i = 0; i < DataBase.Students.Count; i++)
        {
            Console.WriteLine($"{i + 1}. Name: {DataBase.Students[i].FirstName} {DataBase.Students[i].LastName}\n" +
                              $"Learning year: {DataBase.Students[i].LearningYear}\n");
        }
        Console.Write("\nSelect a student:");
        
        if (!int.TryParse(Console.ReadLine(), out var studentChosen) || studentChosen > DataBase.Students.Count || studentChosen <= 0)
        {
            Console.Clear();
            Console.WriteLine("Invalid input");
            return;
        }
        
        StudentMenu(DataBase.Students[studentChosen - 1]);
        Console.Clear();
    }

    private static void StudentMenu(Student student)
    {
        var isStudentDone = false;
        Console.Clear();
        do
        {
            Console.WriteLine("1.Search test to do\n" +
                              "Esc.Exit");
            var studentMenuChoice = Console.ReadKey(intercept: true);

            switch (studentMenuChoice.Key)
            {
                case ConsoleKey.D1:
                    Console.Clear();
                    var testsExist = false;
                    for (var i = 0; i < DataBase.Teachers.Count; i++)
                    {
                        if (DataBase.Teachers[i].Tests.Count != 0)
                        {
                            testsExist = true;
                        }
                    }

                    if (!testsExist)
                    {
                        Console.WriteLine("There are no tests yet");
                        break;
                    }
                    
                    student.TestSearch();
                    break;
                case ConsoleKey.Escape:
                    isStudentDone = true;
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        } while (!isStudentDone);
    }

    private static void AddTeacher()
    {
        DataBase.Teachers.Add(new Teacher());
        Console.Clear();
    }

    private static void AddStudent()
    {
        DataBase.Students.Add(new Student());
        Console.Clear();
    }

    private static void TeacherMenu(Teacher teacher)
    {
        var isTeacherDone = false;
        Console.Clear();
        do
        {
            Console.WriteLine("1.My tests\n" +
                              "2.Questions\n" +
                              "3.Show my test statistics\n" +
                              "Esc: exit");
            var teachersChoice = Console.ReadKey(intercept: true);

            Console.Clear();
            switch (teachersChoice.Key)
            {
                case ConsoleKey.D1:
                    teacher.TestsMenu();
                    break;
                case ConsoleKey.D2:
                    teacher.QuestionsMenu();
                    break;
                case ConsoleKey.D3:
                    teacher.ShowStatistics();
                    break;
                case ConsoleKey.Escape:
                    isTeacherDone = true;
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
            Console.Clear();
        } while (!isTeacherDone);
    }
}