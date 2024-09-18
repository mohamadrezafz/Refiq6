namespace Refiq6.Application.Models.Request;

public class OptionCreate
{
    public string Title { get; set; } = default!;
    public bool IsCorrect { get; set; }
    public int Order { get; set; }
}
