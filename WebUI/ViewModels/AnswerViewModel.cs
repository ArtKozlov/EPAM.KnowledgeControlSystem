using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.DTO;

namespace WebUI.ViewModels
{
    public class AnswerViewModel
    {
        public int Id { get; set; }
        public string Value { get; set; }

        public int? TestId { get; set; }
        public TestDTO Test { get; set; }
    }
}