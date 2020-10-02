namespace TestWebApp.Models
{
    public class Question
    {
        public Question(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}