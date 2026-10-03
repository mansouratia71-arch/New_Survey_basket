namespace Survey_Basket.Dto.Vote
{
    public class VoteValidation: AbstractValidator<VoteRequst>
    {
        public VoteValidation()
        {  
            RuleFor(X => X.answer).NotEmpty();

            RuleForEach(x => x.answer).SetInheritanceValidator(v => v.Add(new VoteAnswerValidation()));
       
        }
    }
}
