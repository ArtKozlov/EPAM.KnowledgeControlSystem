
using System.Collections.Generic;

namespace WebUI.ViewModels
{
    public class TestEditorViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}