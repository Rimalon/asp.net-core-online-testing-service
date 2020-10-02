using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TestWebApp.Contracts;
using TestWebApp.Models;
using TestWebApp.PostParams;

namespace TestWebApp.Controllers
{
    [ApiController]
    [Route("/api/answers")]
    public class AnswersController : ControllerBase
    {
        private readonly IAnswersContract _answersService;

        public AnswersController(IAnswersContract answersService)
        {
            _answersService = answersService;
        }

        [HttpPost]
        [Route("/{testId:int}/GetAnswers")]
        public List<Answer> GetAnswers([FromQuery] int testId) => _answersService.GetAnswers(testId);

        [HttpPost]
        [Route("/AddAnswer")]
        public void AddAnswer([FromBody] AddAnswerParam param) => _answersService.AddAnswer(param.QuestionId, param.Response);
    }
}