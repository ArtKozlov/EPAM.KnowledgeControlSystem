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
                TestResults = userEntity.TestResults,
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
                TestResults = userViewModel.TestResults,
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
        public static Statistics ToMVCStatistics(this TestDTO testModel)
        {
            return new Statistics()
            {
                Name = testModel.Name,
                BadAnswers = testModel.BadAnswers,
                GoodAnswers = testModel.GoodAnswers,
                Creator = testModel.Creator,
                Answers = testModel.BadAnswers + testModel.GoodAnswers,
                Percentage = ((double)testModel.GoodAnswers/((double)testModel.GoodAnswers + (double)testModel.BadAnswers)*100).ToString("##.###")
            };
        }
        #endregion
        #region testResult mapping
        public static TestResultViewModel ToMvcTestResult(this TestResultDTO testResultEntity)
        {
            return new TestResultViewModel()
            {
                Id = testResultEntity.Id,
                Name = testResultEntity.Name,
                GoodAnswers = testResultEntity.GoodAnswers,
                BadAnswers = testResultEntity.BadAnswers,
                DateComleted = testResultEntity.DateCompleted,
                UserId = testResultEntity.UserId

            };
        }

        public static TestResultDTO ToBllTestResult(this TestResultViewModel testResultViewModel)
        {
            return new TestResultDTO()
            {
                Id = testResultViewModel.Id,
                Name = testResultViewModel.Name,
                GoodAnswers = testResultViewModel.GoodAnswers,
                BadAnswers = testResultViewModel.BadAnswers,
                DateCompleted = testResultViewModel.DateComleted,
                UserId = testResultViewModel.UserId
            };
        }
        #endregion
    }
}