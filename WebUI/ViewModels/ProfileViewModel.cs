using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel(IEnumerable<TestResultViewModel> testResult, UserViewModel user)
        {
            TestResults = testResult;
            User = user;
        }
        public IEnumerable<TestResultViewModel> TestResults { get; set; }
        public UserViewModel User { get; set; }
    }
}