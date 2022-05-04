using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SurveyForm.Models
{
    public class SurveyRepository : ISurveyRepository
    {
        private readonly SurveyContext _context;

        public SurveyRepository(SurveyContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Question>> GetQuestions()
        {
            return await _context.Questions.ToListAsync();
        }

        public async Task<Question> GetQuestion(int id)
        {
            return await _context.Questions.FindAsync(id);
        }

        public async Task<Survey> GetSurvey(Guid userId)
        {
            return await _context.Surveys.SingleAsync(s => s.UserId == userId);
        }

        public async Task<Survey> CreateSurvey(Guid userId)
        {
            var questions = await _context.Questions.ToListAsync();
            
            var survey = new Survey
            {
                Questions = questions,
                UserId = userId
            };

            _context.Surveys.Add(survey);
            await _context.SaveChangesAsync();

            return survey;
        }

        public async Task SaveSurvey(Survey survey)
        {
            var surveyToSubmit = await _context.Surveys.FindAsync(survey.Id);
            surveyToSubmit.SubmitTime = DateTime.Now;

            await _context.SaveChangesAsync();
        }

        public async Task SaveAnswer(Answer answer)
        {
            _context.Answers.Add(answer);
            
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Survey>> GetSurveys()
        {
            return await _context.Surveys.ToListAsync();
        }
    }
}