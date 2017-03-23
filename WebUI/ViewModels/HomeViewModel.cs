using System.Collections.Generic;

namespace WebUI.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}