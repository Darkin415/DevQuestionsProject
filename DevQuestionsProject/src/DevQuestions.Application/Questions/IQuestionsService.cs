using DevQuestion.Contracts.Questions;

namespace DevQuestions.Application.Questions
{
    public interface IQuestionsService
    {
        Task Create(CreateQuestionDto questionDto, CancellationToken cancellationToken);
    }
}