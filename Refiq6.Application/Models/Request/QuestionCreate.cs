
namespace Refiq6.Application.Models.Request;

public class QuestionCreate
{
    public string Title { get; set; } = default!;
    public int Order { get; set; }
    public List<OptionCreate> Options { get; set; } = default!;


}
