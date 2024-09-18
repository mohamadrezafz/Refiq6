namespace Refiq6.Application.Models.Response;

public class OptionResponse
{
    public string Title { get; set; } = default!;
    public bool IsCorrect { get; set; }
    public int Order { get; set; }
}
