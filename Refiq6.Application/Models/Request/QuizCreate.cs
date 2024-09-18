namespace Refiq6.Application.Models.Request;

public class QuizCreate
{
    public string Name { get; set; } = default!;
    public string AuthorName { get; set; } = default!;
    public int QuestionCount { get; set; }
    public int OptionCount { get; set; }
    public string Avatar { get; set; } = default!;
    public List<QuestionCreate> Questions { get; set; } = new List<QuestionCreate>();
}
