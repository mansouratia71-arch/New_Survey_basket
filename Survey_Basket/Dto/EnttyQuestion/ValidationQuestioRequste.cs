namespace Survey_Basket.Dto.EnttyQuestion
{
    public class ValidationQuestioRequste:AbstractValidator<QuestionRequste>
    {
        public ValidationQuestioRequste()
        {
            RuleFor(x => x.content).NotEmpty();

            RuleFor(x => x.AnswerRequst).NotEmpty(); 

            RuleFor(x=>x.AnswerRequst).Must(x=>x.Distinct().Count()==x.Count())
                .WithMessage("the answer must be distinct elment")
                .When(x=>x != null);

     RuleFor(x => x.AnswerRequst).Must(x => x.Count() > 1)
    .WithMessage("the answer must be gretar than or equle 2 element")
    .When(x => x != null);
        }
    }
}
