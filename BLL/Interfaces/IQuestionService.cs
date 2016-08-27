
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IQuestionService
    {
        QuestionDTO GetQuestion(int id);
        IEnumerable<QuestionDTO> GetAllQuestions();
        void CreateQuestion(QuestionDTO question);
        void DeleteQuestion(QuestionDTO question);
        void DeleteQuestion(int id);
    }
}
