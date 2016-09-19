//Select Assemblies - > Extensions -> System.Web.Helpers

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Security;
using BLL.DTO;
using BLL.Interfaces;
using Microsoft.Ajax.Utilities;
using WebUI.Infrastructure;
using Ninject;

namespace WebUI.Providers
{
    public class CustomMembershipProvider : MembershipProvider
    {
        private NinjectDependencyResolver dependencyResolver = new NinjectDependencyResolver(new StandardKernel());
        private IUserService userService
            => (IUserService) dependencyResolver.GetService(typeof (IUserService));
        private IRoleService roleService
            => (IRoleService) dependencyResolver.GetService(typeof(IRoleService));

        public bool CreateUser(string name, string email, string password, int age)
        {
            
            var userDTO = new UserDTO
            {
                Name = name,
                Email = email,
                Password = Crypto.HashPassword(password),
                Age = age,
                TestResults = new List<TestResultDTO>()
            };

          // var adminRole = roleService.GetRole(1);
          //  var moderatorRole = roleService.GetRole(2);
            var userRole = roleService.GetRole(3);
            if (userRole != null)
            {
              //  userDTO.Roles.Add(adminRole);
               // userDTO.Roles.Add(moderatorRole);
                userDTO.Roles.Add(userRole);
            }

            userService.CreateUser(userDTO);
            return true;
        }

        public override bool ValidateUser(string email, string password)
        {
            var user = userService.GetUserByEmail(email);

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
            {
                return true;
            }
            return false;
        }

    #region not implemented
        public override MembershipUser GetUser(string email, bool userIsOnline)
        {
            throw new NotImplementedException();
        }
        
        public override MembershipUser CreateUser(string username, string password, string email,
            string passwordQuestion,
            string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion,
            string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override string ApplicationName { get; set; }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }
#endregion  
    }
}