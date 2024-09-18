
namespace Refiq6.Application.Models.Response;

public class QuestionResponse
{
    public string Title { get; set; } = default!;
    public int Order { get; set; }
    public List<OptionResponse> Options { get; set; } = default!;


}
