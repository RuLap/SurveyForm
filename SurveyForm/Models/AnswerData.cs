using System.Collections.Generic;

namespace SurveyForm.Models
{
    public static class AnswerData
    {
        public static Dictionary<string, string[]> Answers;

        static AnswerData()
        {
            Answers = new Dictionary<string, string[]>();
            Answers.Add("Пол", new [] { "Мужской", "Женский" });
            Answers.Add("Удовлетворенность обучением", new []{ "1", "2", "3", "4", "5" });
        }
    }
}