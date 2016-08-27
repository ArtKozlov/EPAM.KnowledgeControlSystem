using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class CreateTestViewModel
    {
        public string[] Answers { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string[] Questions { get; set; }
    }
}