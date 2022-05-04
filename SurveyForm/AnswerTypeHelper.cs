using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using SurveyForm.Models;

namespace SurveyForm
{
    public static class AnswerTypeHelper
    {
        public static HtmlString CreateAnswerForm(this IHtmlHelper<Survey> html, Question question)
        {
            var writer = new StringWriter();
            
            var input = new TagBuilder("input");
            input.MergeAttribute("name", $"{question.Text}");
                
            switch (question.AnswerType)
            {
                case AnswerType.TextBox:
                {
                    input.MergeAttribute("type", "text");
                    input.WriteTo(writer, HtmlEncoder.Default);
                } break;

                case AnswerType.RadioButton:
                {
                    var answers = AnswerData.Answers[question.Text];

                    input.MergeAttribute("id", "1");
                    input.MergeAttribute("type", "radio");
                    input.MergeAttribute("value", $"{answers[0]}");
                    input.InnerHtml.Append(answers[0]);
                    input.WriteTo(writer, HtmlEncoder.Default);
                        
                    for (int i = 1; i < answers.Length; i++)
                    {
                        var newInput = new TagBuilder("input");
                        newInput.MergeAttribute("id", $"{i + 1}");
                        newInput.MergeAttribute("type", "radio");
                        newInput.MergeAttribute("name", $"{question.Text}");
                        newInput.MergeAttribute("value", $"{answers[i]}");
                        newInput.InnerHtml.Append(answers[i]);
                        newInput.WriteTo(writer, HtmlEncoder.Default);
                    }
                } break;

                case AnswerType.Numeric:
                {
                    input.MergeAttribute("type", "number");
                    input.WriteTo(writer, HtmlEncoder.Default);
                } break;
            }

                return new HtmlString(writer.ToString());
        }
    }
}