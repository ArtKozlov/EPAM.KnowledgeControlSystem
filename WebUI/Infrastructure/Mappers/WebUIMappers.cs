using System.Collections.Generic;
using BLL.DTO;
using WebUI.ViewModels;

namespace WebUI.Infrastructure.Mappers
{
    public static class MvcMappers
    {
        #region user mapping
        public static UserViewModel ToMvcUser(this UserDTO userEntity)
        {
            return new UserViewModel()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Age = userEntity.Age,
                Roles = userEntity.Roles,
                Password = userEntity.Password,
                OldPassword = userEntity.OldPassword,
                NewPassword = userEntity.NewPassword,
                ConfirmPassword = userEntity.ConfirmPassword

            };
        }

        public static UserDTO ToBllUser(this UserViewModel userViewModel)
        {
            return new UserDTO()
            {
                Id = userViewModel.Id,
                Name = userViewModel.Name,
                Email = userViewModel.Email,
                Age = userViewModel.Age,
                Roles = userViewModel.Roles,
                Password = userViewModel.Password,
                OldPassword = userViewModel.OldPassword,
                NewPassword = userViewModel.NewPassword,
                ConfirmPassword = userViewModel.ConfirmPassword
            };
        }
        #endregion
        #region test mapping
        public static TestViewModel ToMvcTest(this TestDTO testEntity)
        {
            return new TestViewModel()
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                BadAnswers = testEntity.BadAnswers,
                GoodAnswers = testEntity.GoodAnswers,
                Time = testEntity.Time,
                IsValid = testEntity.IsValid,
                Creator = testEntity.Creator,
                Questions = (List<QuestionDTO>)testEntity.Questions,
                Answers = (List<AnswerDTO>)testEntity.Answers

            };
        }

        public static TestDTO ToBllTest(this TestViewModel testViewModel)
        {
            return new TestDTO()
            {
                Id = testViewModel.Id,
                Name = testViewModel.Name,
                BadAnswers = testViewModel.BadAnswers,
                GoodAnswers = testViewModel.GoodAnswers,
                Time = testViewModel.Time,
                IsValid = testViewModel.IsValid,
                Creator = testViewModel.Creator,
                Questions = testViewModel.Questions,
                Answers = testViewModel.Answers
            };
        }
        #endregion
    }
}