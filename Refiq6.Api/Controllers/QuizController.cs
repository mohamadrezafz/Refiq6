using Microsoft.AspNetCore.Mvc;
using Refiq6.Api.Controllers.Base;
using Refiq6.Application.Interfaces.Service;
using Refiq6.Application.Models.Request;
namespace Refiq6.Api.Controllers;
public class QuizController : ApiControllerBase
{
    private readonly IQuizService _quizService;
    public QuizController(IQuizService quizService)
    {
        _quizService = quizService;
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] QuizCreate request)
    {
        await _quizService.Create(request);
        return Created();
    }
    [HttpGet("{code}")]
    public async Task<IActionResult> GetById(string code)
    {
        var response = await _quizService.Get(code);
        return Ok(response);
    }
}
