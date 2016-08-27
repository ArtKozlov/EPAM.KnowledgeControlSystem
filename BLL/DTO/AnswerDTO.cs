
using BLL.Interfaces;

namespace BLL.DTO
{
    public class AnswerDTO : IEntity
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int? TestId { get; set; }
        public TestDTO Test { get; set; }
    }
}
