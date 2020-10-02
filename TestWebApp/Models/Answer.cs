namespace TestWebApp.Models
{
    public class Answer
    {
        public Answer(string title, string response, bool isCorrect)
        {
            Title = title;
            Response = response;
            IsCorrect = isCorrect;
        }

        public string Title { get; set; }
        public string Response { get; set; }
        public bool IsCorrect { get; set; }
    }
}