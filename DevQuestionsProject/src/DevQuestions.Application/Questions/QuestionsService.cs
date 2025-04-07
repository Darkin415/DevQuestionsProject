using DevQuestion.Contracts.Questions;
using DevQuestions.Domain.Questions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace DevQuestions.Application.Questions
{
    public class QuestionsService : IQuestionsService
    {
        private readonly IQuestionRepository _questionsRepository;
        private readonly ILogger<QuestionsService> _logger;
        private readonly IValidator<CreateQuestionDto> _validator;
        public QuestionsService(IQuestionRepository questionRepository, ILogger<QuestionsService> logger, IValidator<CreateQuestionDto> validator)
        {
            // валидация входных данных 
            _questionsRepository = questionRepository;
            _logger = logger;
            _validator = validator;
        }

        // валидация бизнес логики 

        public async Task Create(CreateQuestionDto questionDto, CancellationToken cancellationToken)
        {

            var validationResult = await _validator.ValidateAsync(questionDto, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ValidationException(validationResult.Errors);
            }

            int openUserQuestionsCount = await _questionsRepository
             .GetOpenUserQuestionsAsync(questionDto.UserId, cancellationToken);

            if (openUserQuestionsCount > 3)
            {
                throw new Exception("Пользователь не может открыть больше трех вопросов.");
            }


            var questionId = Guid.NewGuid();

            var question = new Question(
                questionId,
                questionDto.Title,
                questionDto.Text,
                questionDto.UserId,
                null,
                questionDto.TagIds);

            await _questionsRepository.AddAsync(question, cancellationToken);

            _logger.LogInformation("Question created with id {questionId}", questionId);

        }

        //public async Task<IActionResult> Update(Guid questionId, [FromBody] UpdateQuestionDto request, CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> Delete(Guid questionId, CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> SelectSolution(Guid questionId, [FromQuery] Guid answerIdm, CancellationToken cancellationToken)
        //{

        //}

        //public async Task<IActionResult> AddAnswer(Guid questionId, AddAnswerDto request, CancellationToken cancellationToken)
        //{
        //    ;
        //}
    }
}
