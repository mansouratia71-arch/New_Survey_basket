namespace Survey_Basket.Dto.Vote
{
    public class VoteAnswerValidation : AbstractValidator<VoteAnserRequste>
    {
        public VoteAnswerValidation()
        {
            RuleFor(x=>x.answerId).GreaterThan(0);
            RuleFor(x=>x.questionId).GreaterThan(0);
        }
    }
}
