using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.DTO
{
    public class TestResultDTO : IEntity
    {
        public TestResultDTO()
        {
            Tests = new List<TestDTO>();
        }
        public int Id { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public int? UserId { get; set; }
        public UserDTO User { get; set; }

        public ICollection<TestDTO> Tests { get; set; }
    }
}
