using DevQuestions.Domain.Questions;

namespace DevQuestions.Application.Questions
{
    public interface IQuestionRepository
    {
        Task<Guid> AddAsync(Question question, CancellationToken cancellation);
        Task<Guid> SaveAsync(Question question, CancellationToken cancellation);
        Task<Guid> DeletedAsync(Guid questionId, CancellationToken cancellation);
        Task<Question> GetByIdAsync(Guid questionId, CancellationToken cancellation);
        
    }
}
