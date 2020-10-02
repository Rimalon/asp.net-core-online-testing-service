using System.Collections.Generic;
using TestWebApp.Models;

namespace TestWebApp.Contracts
{
    public interface IQuestionsContract
    {
        List<Question> GetTest(int testId);

        void AddQuestion(int testId, string title, string correctResponse);

        void AddQuestion(int testId, string title, string correctResponse, string secondOption, string thirdOption, string fourthOption);
    }
}