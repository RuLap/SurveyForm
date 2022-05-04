using Microsoft.AspNetCore.Mvc;
using SurveyForm.Models;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace SurveyForm.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;

        private readonly IMemoryCache _cache;

        public HomeController(
            ISurveyRepository surveyRepository,
            IMemoryCache cache)
        {
            _surveyRepository = surveyRepository;
            _cache = cache;
        }

        [HttpGet]
        public async Task<IActionResult> SurveyForm()
        {
            if (!_cache.TryGetValue("id", out Guid userId))
            {
                userId = Guid.NewGuid();
                _cache.Set("id", userId);
                var survey = await _surveyRepository.CreateSurvey(userId);
            
                return View(survey);
            }

            return View("Error", new ErrorViewModel { Message = "Вы уже проходили данный опрос!"});
        }

        [HttpPost]
        public async Task<IActionResult> SubmitSurvey()
        {
            _cache.TryGetValue("id", out Guid userId);

            var survey = await _surveyRepository.GetSurvey(userId);
            foreach (var field in Request.Form)
            {
                var questionValues = field.Value.ToArray();

                var answer = new Answer
                {
                    QuestionId = int.Parse(questionValues[0]),
                    Text = questionValues[1],
                    SurveyId = survey.Id
                };

                await _surveyRepository.SaveAnswer(answer);
            }
            
            await _surveyRepository.SaveSurvey(survey);

            return View("SurveySubmitted");
        }
    }
}
