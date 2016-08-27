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
                IsModerator = userEntity.IsModerator,
                Password = userEntity.Password

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
                IsModerator = userViewModel.IsModerator,
                Password = userViewModel.Password
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
                Questions = testEntity.Questions,
                Answers = testEntity.Answers

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
                Questions = testViewModel.Questions,
                Answers = testViewModel.Answers
            };
        }
        #endregion
        #region answer mapping
        public static AnswerViewModel ToMvcAnswer(this AnswerDTO answerEntity)
        {
            return new AnswerViewModel()
            {
                Id = answerEntity.Id,
                Value = answerEntity.Value

            };
        }

        public static AnswerDTO ToBllAnswer(this AnswerViewModel answerViewModel)
        {
            return new AnswerDTO()
            {
                Id = answerViewModel.Id,
                Value = answerViewModel.Value
            };
        }
        #endregion
        #region question mapping
        public static QuestionViewModel ToMvcQuestion(this QuestionDTO questionEntity)
        {
            return new QuestionViewModel()
            {
                Id = questionEntity.Id,
                Value = questionEntity.Value

            };
        }

        public static QuestionDTO ToBllQuestion(this QuestionViewModel questionViewModel)
        {
            return new QuestionDTO()
            {
                Id = questionViewModel.Id,
                Value = questionViewModel.Value
            };
        }
        #endregion
    }
}