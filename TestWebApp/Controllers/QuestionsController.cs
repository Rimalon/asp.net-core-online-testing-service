using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Contracts;
using TestWebApp.Models;
using TestWebApp.PostParams;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("/api/questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionsContract _questionsService;

        public QuestionsController(IQuestionsContract questionsService)
        {
            _questionsService = questionsService;
        }


        [HttpPost]
        [Route("/{testId:int}/GetTest")]
        public List<Question> GetTest(int testId) => _questionsService.GetTest(testId);

        [HttpPost]
        [Route("/{testId:int}/AddFreeEntryQuestion")]
        public void AddFreeEntryQuestion(int testId, [FromBody] AddFreeEntryQuestionParam param) =>
            _questionsService.AddQuestion(testId, param.Title, param.CorrectResponse);

        [HttpPost]
        [Route("/{testId:int}/AddChoiceOfAnswerQuestion")]
        public void AddChoiceOfAnswerQuestion(int testId, [FromBody] AddChoiceOfAnswerQuestionParam param) =>
            _questionsService.AddQuestion(testId, param.Title, param.CorrectResponse, param.SecondOption, param.ThirdOption, param.FourthOption);
    }
}