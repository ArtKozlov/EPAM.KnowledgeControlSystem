using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TestViewModel> TestsViewModel { get; set; }
        public PageInfoViewModel PageInfoViewModel { get; set; }
    }
}