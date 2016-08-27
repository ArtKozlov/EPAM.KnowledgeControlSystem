
using System.Collections.Generic;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IAnswerService
    {
        AnswerDTO GetAnswer(int id);
        IEnumerable<AnswerDTO> GetAllAnswers();
        void CreateAnswer(AnswerDTO answer);
        void DeleteAnswer(AnswerDTO answer);
        void DeleteAnswer(int key);
    }
}
