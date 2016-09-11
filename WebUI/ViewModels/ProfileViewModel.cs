using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ProfileViewModel
    {
        public UserViewModel User { get; set; }
        public PageInfoViewModel PageInfo { get; set; }
    }
}