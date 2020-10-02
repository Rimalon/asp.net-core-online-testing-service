using System.Collections.Generic;

namespace TestWebApp.Models
{
    public class ChoiceOfAnswerQuestion : Question
    {
        public ChoiceOfAnswerQuestion(string title, List<string> options) : base(title)
        {
            Options = options;
        }

        public List<string> Options { get; set; }
    }
}