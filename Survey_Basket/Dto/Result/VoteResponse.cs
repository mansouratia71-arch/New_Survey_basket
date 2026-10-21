namespace Survey_Basket.Dto.Result
{
    public record VoteResponse
    (
        string userId,

        DateTime subtion,

        IEnumerable<QuestionAnserREsponse> selectQuestion


    );
}
