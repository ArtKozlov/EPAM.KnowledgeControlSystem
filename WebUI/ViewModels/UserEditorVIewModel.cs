
using System.Collections.Generic;

namespace WebUI.ViewModels
{
    public class UserEditorVIewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}