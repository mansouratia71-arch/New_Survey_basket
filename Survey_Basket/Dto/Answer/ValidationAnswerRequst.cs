namespace Survey_Basket.Dto.Answer
{
    public class ValidationAnswerRequst:AbstractValidator<AnswerRequst>
    {
        public ValidationAnswerRequst()
        {
            RuleFor(x => x.content).NotEmpty();
        }
    }
}
