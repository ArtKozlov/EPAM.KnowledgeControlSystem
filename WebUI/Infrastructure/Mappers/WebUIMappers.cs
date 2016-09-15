using System.Collections.Generic;
using System.Linq;
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
        public static TestDTO ToBllTest(this CreateTestViewModel createTestViewModel)
        {
            return new TestDTO()
            {
                Name = createTestViewModel.Name,
               // Discription = createTestViewModel.Discription,
                Time = createTestViewModel.Time,
                Creator = createTestViewModel.Creator,
                Questions = createTestViewModel.Questions.ToQuestionDtoCollection().ToList(),
                Answers = createTestViewModel.Answers.ToAnswerDtoCollection().ToList()
            };
        }
        public static Statistics ToMvcStatistics(this TestDTO testModel)
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
        public static PassingViewModel ToMvcPassing(this TestDTO testModel)
        {
            return new PassingViewModel()
            {
                Id = testModel.Id,
                Name = testModel.Name,
                Time = testModel.Time,
                Questions = testModel.Questions.ToQuestionCollection().ToList(),
                Answers = testModel.Answers.ToAnswerCollection().ToList()
            };
        }
        public static TestDTO ToBllTestFromPassingModel(this PassingViewModel passingModel)
        {
            return new TestDTO()
            {
                Id = passingModel.Id,
                Name = passingModel.Name,
                Time = passingModel.Time,
                Answers = passingModel.Answers.ToAnswerDtoCollection().ToList()
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
        private static IEnumerable<QuestionDTO> ToQuestionDtoCollection(this ICollection<string> collectionQuestions)
        {
            foreach (var question in collectionQuestions)
            {
                yield return new QuestionDTO
                {
                    Value = question
                };
            }
        }
        private static IEnumerable<AnswerDTO> ToAnswerDtoCollection(this ICollection<string> collectionAnswers)
        {
            foreach (var answer in collectionAnswers)
            {
                yield return new AnswerDTO
                {
                    Value = answer
                };
            }
        }
        private static IEnumerable<string> ToQuestionCollection(this ICollection<QuestionDTO> collectionQuestionsDto)
        {
            foreach (var question in collectionQuestionsDto)
            {
                yield return question.Value;
            }
        }
        private static IEnumerable<string> ToAnswerCollection(this ICollection<AnswerDTO> collectionAnswersDto)
        {
            foreach (var answer in collectionAnswersDto)
            {
                yield return answer.Value;
            }
        }
    }
}