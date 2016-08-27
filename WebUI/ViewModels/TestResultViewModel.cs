using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;

namespace WebUI.ViewModels
{
    public class TestResultViewModel
    {
        public TestResultViewModel()
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