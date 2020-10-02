using System.ComponentModel.DataAnnotations;

namespace TestWebApp.Entities
{
    public class Answer
    {
        public Answer()
        {
        }

        public Answer(int questionId, string response, bool isCorrect)
        {
            QuestionId = questionId;
            Response = response;
            IsCorrect = isCorrect;
        }

        [Key] public int Id { get; set; }
        public int QuestionId { get; }
        public string Response { get; }
        public bool IsCorrect { get; }
    }
}