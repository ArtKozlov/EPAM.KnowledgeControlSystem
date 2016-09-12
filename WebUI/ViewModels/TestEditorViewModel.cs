
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebUI.ViewModels
{
    public class TestEditorViewModel
    {
        public IEnumerable<TestViewModel> Tests { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
        [Display(Name = "Show valid tests:")]
        public bool ShowValid { get; set; }
    }
}