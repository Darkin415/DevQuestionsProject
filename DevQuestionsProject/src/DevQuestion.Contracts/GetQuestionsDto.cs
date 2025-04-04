namespace DevQuestion.Contracts
{
    public record GetQuestionsDto(string Search, Guid[] TagsIds, int page_size , int limit);
    

}