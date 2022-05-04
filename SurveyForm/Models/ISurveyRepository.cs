using System;
using System.Threading.Tasks;

namespace SurveyForm.Models
{
    public interface ISurveyRepository
    {
        Task<Survey> GetSurvey(Guid userId);

        Task<Survey> CreateSurvey(Guid userId);

        Task SaveSurvey(Survey survey);

        Task SaveAnswer(Answer answer);
    }
}