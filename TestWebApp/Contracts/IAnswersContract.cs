using System.Collections.Generic;
using TestWebApp.Models;

namespace TestWebApp.Contracts
{
    public interface IAnswersContract
    {
        void AddAnswer(int questionId, string response);
        List<Answer> GetAnswers(int testId);
    }
}