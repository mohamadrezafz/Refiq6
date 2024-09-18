
using Refiq6.Application.Models.Request;

namespace Refiq6.Application.Models.Response;

public class QuizResponse 
{
    public string Name { get; set; } = default!;
    public string AuthorName { get; set; } = default!;
    public int QuestionCount { get; set; }
    public int OptionCount { get; set; }
    public string Avatar { get; set; } = default!;
    public List<QuestionResponse> Questions { get; set; } = default!;
}
