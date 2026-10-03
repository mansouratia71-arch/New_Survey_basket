using Survey_Basket.Dto.Answer;


namespace Survey_Basket.Dto.EnttyQuestion
{
    public record QuestionResponse
    (
        int id,
        string content,
        IEnumerable<AnswerResponce> answers


    );
}
