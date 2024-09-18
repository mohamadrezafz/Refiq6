using Refiq6.Domain.Common;

namespace Refiq6.Domain.Entities;

public class Question : BaseEntity
{
    public string Title { get; set; } = default!;
    public int Order { get; set; }
    public long QuizId { get; set; }
    public virtual Quiz Quiz { get; set; } = default!;
    public IReadOnlyCollection<Option> Options { get; set; } = default!;

}
