using System;
using System.Collections.Generic;
using BLL.Interfaces;

namespace BLL.DTO
{
    public class TestResultDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GoodAnswers { get; set; }
        public int BadAnswers { get; set; }
        public UserDTO User { get; set; }
        public DateTime DateCompleted { get; set; }
    }
}
