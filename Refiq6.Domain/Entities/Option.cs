using Refiq6.Domain.Common;

namespace Refiq6.Domain.Entities;

public class Option : BaseEntity
{
    public string Title { get; set; } = default!;
    public string ImageUrl { get; set; } = default!;
    public bool IsCorrect { get; set; }
    public int Order { get; set; }
    public long QuestionId { get; set; }
    public virtual Question Question { get; set; } = default!;
}
