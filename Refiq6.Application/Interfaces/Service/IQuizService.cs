using Refiq6.Application.Models.Request;
using Refiq6.Application.Models.Response;

namespace Refiq6.Application.Interfaces.Service;

public interface IQuizService
{
   Task<string> Create(QuizCreate createQuiz);
   Task<QuizResponse> Get(string quizCode);

}
