namespace delegates;

public class Answer
{
    public string Content { get; set; }
    
    public bool IsTrue { get; set; }

    public Answer(string content)
    {
        Content = content;
        IsTrue = false;
    }

    public static void Delete(Question question, int index)
    {
        question.Answers.RemoveAt(index);
    }
}