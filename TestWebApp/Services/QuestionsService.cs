using System;
using System.Collections.Generic;
using System.Linq;
using TestWebApp.Contracts;
using TestWebApp.Enums;
using TestWebApp.Models;

namespace TestWebApp.Services
{
    public class QuestionsService : IQuestionsContract
    {
        private readonly WebAppContext _context;
        private readonly Random _rnd = new Random();

        public QuestionsService(WebAppContext context)
        {
            _context = context;
        }

        public List<Question> GetTest(int testId) => _context.Questions.Where(q => q.TestId == testId).Select(q => ToQuestionModel(q)).ToList();

        private Question ToQuestionModel(Entities.Question q) => q.Type switch
        {
            QuestionType.ChoiceOfAnswer => new ChoiceOfAnswerQuestion(q.Title,
                new List<string> {q.CorrectResponse, q.SecondOption, q.ThirdOption, q.FourthOption}
                    .OrderBy(item => _rnd.Next())
                    .ToList()),
            QuestionType.FreeEntry => new Question(q.Title),
            _ => null
        };

        public void AddQuestion(int testId, string title, string correctResponse)
        {
            _context.Questions.Add(new Entities.Question(testId, QuestionType.FreeEntry, title, correctResponse));
        }

        public void AddQuestion(int testId, string title, string correctResponse, string secondOption, string thirdOption, string fourthOption)
        {
            _context.Questions.Add(new Entities.Question(testId, QuestionType.ChoiceOfAnswer, title, correctResponse, secondOption, thirdOption, fourthOption));
        }
    }
}