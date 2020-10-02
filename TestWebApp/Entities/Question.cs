using System.ComponentModel.DataAnnotations;
using TestWebApp.Enums;

namespace TestWebApp.Entities
{
    public class Question
    {
        public Question()
        {
        }

        public Question(int testId, QuestionType type, string title, string correctResponse, string secondOption, string thirdOption, string fourthOption)
        {
            TestId = testId;
            Type = type;
            Title = title;
            CorrectResponse = correctResponse;
            SecondOption = secondOption;
            ThirdOption = thirdOption;
            FourthOption = fourthOption;
        }

        public Question(int testId, QuestionType type, string title, string response) :
            this(testId, type, title, response, null, null, null)
        {
        }

        [Key] public int Id { get; set; }
        public int TestId { get; }
        public QuestionType Type { get; }
        public string Title { get; }
        public string CorrectResponse { get; }
        public string SecondOption { get; }
        public string ThirdOption { get; }
        public string FourthOption { get; }
    }
}