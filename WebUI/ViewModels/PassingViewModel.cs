using System;
using System.Collections.Generic;

namespace WebUI.ViewModels
{
    public class PassingViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public List<string> Answers { get; set; }
        public List<string> Questions { get; set; }
        public DateTime StartPassingTest { get; set; }

        public DateTime CompletedPassingTest { get; set; }
    }
}