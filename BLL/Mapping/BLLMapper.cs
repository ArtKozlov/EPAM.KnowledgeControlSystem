using System.Collections.Generic;
using System.Linq;
using BLL.DTO;
using ORM.Entities;

namespace BLL.Mapping
{
    public static class BLLMapper
    {
        #region user mapping
        /// <summary>
        /// The method converts an object of type User to an object of type UserDTO.
        /// </summary>
        /// <param name="userEntity">An object of type User.</param>
        /// <returns>An object of type UserDTO.</returns>
        public static UserDTO ToUserDto(this User userEntity)
        {
            if (ReferenceEquals(userEntity, null))
                return null;
            return new UserDTO()
            {
                Id = userEntity.Id,
                Name = userEntity.Name,
                Email = userEntity.Email,
                Password = userEntity.Password,
                Age = userEntity.Age,
                Roles = userEntity.Roles.ToRoleDTOCollection().ToList(),
                TestResults = userEntity.TestResults.ToTestResultDTOCollection().ToList()
            };
        }

        /// <summary>
        /// The method converts an object of type UserDTO to an object of type User.
        /// </summary>
        /// <param name="userDto">An object of type UserDTO.</param>
        /// <returns>An object of type User.</returns>
        public static User ToUserEntity(this UserDTO userDto)
        {
            return new User()
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                Age = userDto.Age,
                Roles = userDto.Roles.ToRoleCollection().ToList(),
                TestResults = userDto.TestResults.ToTestResultCollection().ToList()

            };
        }
        #endregion
        #region role mapping
        /// <summary>
        /// The method converts an object of type Role to an object of type RoleDTO.
        /// </summary>
        /// <param name="roleEntity">An object of type Role.</param>
        /// <returns>An object of type RoleDTO.</returns>
        public static RoleDTO ToRoleDto(this Role roleEntity)
        {
            return new RoleDTO()
            {
                Id = roleEntity.Id,
                Name = roleEntity.Name,
                Description = roleEntity.Description
            };
        }

        /// <summary>
        /// The method converts an object of type RoleDTO to an object of type Role.
        /// </summary>
        /// <param name="roleDto">An object of type RoleDTO.</param>
        /// <returns>An object of type Role.</returns>
        public static Role ToRoleEntity(this RoleDTO roleDto)
        {
            return new Role()
            {
                Id = roleDto.Id,
                Name = roleDto.Name,
                Description = roleDto.Description
            };
        }


        #endregion
        #region test mapping
        /// <summary>
        /// The method converts an object of type Test to an object of type TestDTO.
        /// </summary>
        /// <param name="testEntity">An object of type Test.</param>
        /// <returns>An object of type TestDTO.</returns>
        public static TestDTO ToTestDto(this Test testEntity)
        {
            if (ReferenceEquals(testEntity, null))
                return null;
            return new TestDTO()
            {
                Id = testEntity.Id,
                Name = testEntity.Name,
                GoodAnswers = testEntity.GoodAnswers,
                BadAnswers = testEntity.BadAnswers,
                Time = testEntity.Time,
                IsValid = testEntity.IsValid,
                Creator = testEntity.Creator,
                Answers = testEntity.Answers.ToAnswerDtoCollection().ToList(),
                Questions = testEntity.Questions.ToQuestionDtoCollection().ToList()
            };
        }

        /// <summary>
        /// The method converts an object of type TestDTO to an object of type Test.
        /// </summary>
        /// <param name="testDto">An object of type TestDTO.</param>
        /// <returns>An object of type Test.</returns>
        public static Test ToTestEntity(this TestDTO testDto)
        {
            return new Test()
            {
                Id = testDto.Id,
                Name = testDto.Name,
                GoodAnswers = testDto.GoodAnswers,
                BadAnswers = testDto.BadAnswers,
                Time = testDto.Time,
                IsValid = testDto.IsValid,
                Creator = testDto.Creator,
                Answers = testDto.Answers.ToAnswerCollection().ToList(),
                Questions = testDto.Questions.ToQuestionCollection().ToList()

            };
        }

        #endregion
        #region answer mapping
        /// <summary>
        /// The method converts an object of type Answer to an object of type AnswerDTO.
        /// </summary>
        /// <param name="answerEntity">An object of type Answer.</param>
        /// <returns>An object of type AnswerDTO.</returns>
        public static AnswerDTO ToAnswerDto(this Answer answerEntity)
        {
            if (ReferenceEquals(answerEntity, null))
                return null;
            return new AnswerDTO()
            {
                Id = answerEntity.Id,
                Value = answerEntity.Value,
                TestId = answerEntity.TestId
            };
        }

        /// <summary>
        /// The method converts an object of type AnswerDTO to an object of type Answer.
        /// </summary>
        /// <param name="answerDto">An object of type AnswerDTO.</param>
        /// <returns>An object of type Answer.</returns>
        public static Answer ToAnswerEntity(this AnswerDTO answerDto)
        {
            return new Answer()
            {
                Id = answerDto.Id,
                Value = answerDto.Value,
                TestId = answerDto.TestId

            };
        }

        #endregion
        #region question mapping
        /// <summary>
        /// The method converts an object of type Question to an object of type QuestionDTO.
        /// </summary>
        /// <param name="questionEntity">An object of type Question.</param>
        /// <returns>An object of type QuestionDTO.</returns>
        public static QuestionDTO ToQuestionDto(this Question questionEntity)
        {
            if (ReferenceEquals(questionEntity, null))
                return null;
            return new QuestionDTO()
            {
                Id = questionEntity.Id,
                Value = questionEntity.Value,
                TestId = questionEntity.TestId

            };
        }

        /// <summary>
        /// The method converts an object of type QuestionDTO to an object of type Question.
        /// </summary>
        /// <param name="questionDto">An object of type QuestionDTO.</param>
        /// <returns>An object of type Question.</returns>
        public static Question ToQuestionEntity(this QuestionDTO questionDto)
        {
            return new Question()
            {
                Id = questionDto.Id,
                Value = questionDto.Value,
                TestId = questionDto.TestId

            };
        }

        #endregion
        #region testResult mapping
        /// <summary>
        /// The method converts an object of type TestResult to an object of type TestResultDTO.
        /// </summary>
        /// <param name="testResultEntity">An object of type TestResult.</param>
        /// <returns>An object of type TestResultDTO.</returns>
        public static TestResultDTO ToTestResultDto(this TestResult testResultEntity)
        {
            if (ReferenceEquals(testResultEntity, null))
                return null;
            return new TestResultDTO()
            {
                Id = testResultEntity.Id,
                Name = testResultEntity.Name,
                GoodAnswers = testResultEntity.GoodAnswers,
                BadAnswers = testResultEntity.BadAnswers,
                UserId = testResultEntity.UserId,
                DateCompleted = testResultEntity.DateComplete
            };
        }

        /// <summary>
        /// The method converts an object of type TestResultDTO to an object of type TestResult.
        /// </summary>
        /// <param name="testResultDto">An object of type TestResultDTO.</param>
        /// <returns>An object of type TestResult.</returns>
        public static TestResult ToTestResultEntity(this TestResultDTO testResultDto)
        {
            return new TestResult()
            {
                Id = testResultDto.Id,
                Name = testResultDto.Name,
                GoodAnswers = testResultDto.GoodAnswers,
                BadAnswers = testResultDto.BadAnswers,
                UserId = testResultDto.UserId,
                DateComplete = testResultDto.DateCompleted

            };
        }
        #endregion
        #region private methods
        private static IEnumerable<Role> ToRoleCollection(this ICollection<RoleDTO> collectionRoleDto)
        {
            foreach (var roleDTO in collectionRoleDto)
            {
                yield return roleDTO.ToRoleEntity();
            }
        }

        private static IEnumerable<RoleDTO> ToRoleDTOCollection(this ICollection<Role> collectionRole)
        {
            foreach (var role in collectionRole)
            {
                yield return role.ToRoleDto();
            }
        }
        private static IEnumerable<Answer> ToAnswerCollection(this ICollection<AnswerDTO> collectionAnswerDto)
        {
            foreach (var AnswerDTO in collectionAnswerDto)
            {
                yield return AnswerDTO.ToAnswerEntity();
            }
        }

        private static IEnumerable<AnswerDTO> ToAnswerDtoCollection(this ICollection<Answer> collectionAnswer)
        {
            foreach (var answer in collectionAnswer)
            {
                yield return answer.ToAnswerDto();
            }
        }
        private static IEnumerable<Question> ToQuestionCollection(this ICollection<QuestionDTO> collectionQuestionDto)
        {
            foreach (var questionDTO in collectionQuestionDto)
            {
                yield return questionDTO.ToQuestionEntity();
            }
        }

        private static IEnumerable<QuestionDTO> ToQuestionDtoCollection(this ICollection<Question> collectionQuestion)
        {
            foreach (var question in collectionQuestion)
            {
                yield return question.ToQuestionDto();
            }
        }
        private static IEnumerable<TestResult> ToTestResultCollection(this ICollection<TestResultDTO> collectionTestResultDto)
        {
            foreach (var testResultDTO in collectionTestResultDto)
            {
                yield return testResultDTO.ToTestResultEntity();
            }
        }

        private static IEnumerable<TestResultDTO> ToTestResultDTOCollection(this ICollection<TestResult> collectionTestResult)
        {
            foreach (var testResult in collectionTestResult)
            {
                yield return testResult.ToTestResultDto();
            }
        }
        #endregion
    }
}
