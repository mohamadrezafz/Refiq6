using Refiq6.Domain.Common;
namespace Refiq6.Domain.Entities;

public class Quiz : BaseEntity
{
    public string Name { get; set; } = default!;
    public string AuthorName { get; set; } = default!;
    public int QuestionCount { get; set; }
    public int OptionCount { get; set; }
    public string Avatar { get; set; } = default!;
    public string Code { get; set; } = default!;
    public IReadOnlyCollection<Question> Questions { get; set; } = default!;

}
