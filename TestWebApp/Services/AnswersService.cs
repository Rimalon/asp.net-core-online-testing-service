using System.Collections.Generic;
using System.Linq;
using TestWebApp.Contracts;
using TestWebApp.Models;

namespace TestWebApp.Services
{
    public class AnswersService : IAnswersContract
    {
        private readonly WebAppContext _context;

        public AnswersService(WebAppContext context)
        {
            _context = context;
        }


        public void AddAnswer(int questionId, string response)
        {
            var question = _context.Questions.First(q => q.Id == questionId);
            _context.Answers.Add(new Entities.Answer(questionId, response, question.CorrectResponse == response));
        }

        public List<Answer> GetAnswers(int testId) => (
            from q in _context.Questions
            join a in _context.Answers on q.Id equals a.QuestionId
            where q.TestId == testId
            select new Answer(q.Title, a.Response, a.IsCorrect)
        ).ToList();
    }
}