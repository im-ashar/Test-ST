using Microsoft.EntityFrameworkCore;
using Test_ST.Data;
using Test_ST.Models;
using Test_ST.ViewModels;

namespace Test_ST.Services
{
    public interface IQuestionService
    {
        Task<List<Question>> CreateQuestionAsync(List<QuestionRequest> question);
    }

    public class QuestionService : IQuestionService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public QuestionService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<List<Question>> CreateQuestionAsync(List<QuestionRequest> questionsList)
        {
            var listOfQuestions = new List<Question>();
            using var context = _contextFactory.CreateDbContext();
            foreach (var question in questionsList)
            {
                var newQuestion = new Question
                {
                    FormId = question.FormId,
                    Text = question.Text,
                    Answer = question.Answer,
                    QuestionType = question.QuestionType,
                    Options = question.Options
                };
                await context.Questions.AddAsync(newQuestion);
                listOfQuestions.Add(newQuestion);
            }
            await context.SaveChangesAsync();
            return listOfQuestions;
        }
    }
}
