using FluentValidation;

namespace Survey_Basket.Dto.Entitypoll
{
    public class RequstPollvalidation:AbstractValidator<RequstPoll>
    {

        public RequstPollvalidation()
        {
            RuleFor(X => X.title).NotEmpty().WithMessage(" title is reqiurd").MaximumLength(50);

            RuleFor(x => x.startdate).NotEmpty().WithMessage(" startdate is reqiurd").GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today)).WithMessage("the date muste be grater than date of today");

            RuleFor(x => x.enddate).NotEmpty().WithMessage("enddate is reqiurd").GreaterThan(x => x.startdate).WithMessage("the datestrat must be less than of date end");


        }

    }
}
