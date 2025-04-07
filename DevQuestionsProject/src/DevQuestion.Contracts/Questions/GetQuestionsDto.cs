namespace DevQuestion.Contracts.Questions
{
    public record GetQuestionsDto(string Search, Guid[] TagsIds, int page_size , int limit);
    

}