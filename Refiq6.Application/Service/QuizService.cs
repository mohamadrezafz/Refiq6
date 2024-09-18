using Microsoft.EntityFrameworkCore;
using Refiq6.Application.Constants;
using Refiq6.Application.Exceptions;
using Refiq6.Application.Interfaces;
using Refiq6.Application.Interfaces.Service;
using Refiq6.Application.Models.Request;
using Refiq6.Application.Models.Response;
using Refiq6.Domain.Entities;

namespace Refiq6.Application.Service;

public class QuizService: IQuizService
{
    private readonly IApplicationDatabaseContext _context;
    public QuizService(IApplicationDatabaseContext context) => _context = context;
    public async Task<string> Create(QuizCreate createQuiz)
    {
        var quizCode = Guid.NewGuid().ToString();
        var quiz = new Quiz()
        {
            AuthorName = createQuiz.AuthorName,
            Avatar = createQuiz.Avatar,
            CreateDate = DateTime.Now,
            Name = createQuiz.Name,
            OptionCount = createQuiz.OptionCount,
            QuestionCount = createQuiz.QuestionCount,
            Code = quizCode
        };
        await _context.Quizes.AddAsync(quiz);
        await _context.SaveChangesAsync();

        foreach (var item in createQuiz.Questions)
        {
            var question = new Question()
            {
                CreateDate = DateTime.Now,
                Order = item.Order,
                QuizId = quiz.Id,
                Title = item.Title
            };
            await _context.Questions.AddAsync(question);
            await _context.SaveChangesAsync();
            foreach (var item2 in item.Options)
            {
                var option = new Option()
                {
                    CreateDate = DateTime.Now,
                    Order = item2.Order,
                    Title = item2.Title,
                    ImageUrl = "",
                    IsCorrect = item2.IsCorrect,
                    QuestionId = question.Id
                };
                await _context.Options.AddAsync(option);
              
            }
         
        }
        await _context.SaveChangesAsync();
        return quizCode;
    }

    public async Task<QuizResponse> Get(string quizCode)
    {
        var quiz = await _context.Quizes.Include(x => x.Questions).ThenInclude(x => x.Options).Where(x => x.Code == quizCode).FirstOrDefaultAsync();
        if (quiz == null)
            throw new NotFoundException(ExceptionMessages.QuizNotFound);
        return new QuizResponse()
        {
            AuthorName = quiz.AuthorName ,
            Avatar = quiz.Avatar ,
            Name = quiz.Name ,
            OptionCount = quiz.OptionCount ,
            QuestionCount = quiz.QuestionCount ,
            Questions = quiz.Questions.Select(x => new QuestionResponse()
            {
                Order = x.Order,
                Title=x.Title,
                Options = x.Options.Select(y => new OptionResponse()
                {
                    Title = y.Title,
                    Order = y.Order,
                    IsCorrect = y.IsCorrect,
                }).ToList()
            }).ToList()

        };
    }
}
