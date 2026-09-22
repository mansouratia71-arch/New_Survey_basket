namespace Survey_Basket.Dto.EntityRegester
{
    public class RegisterViladation : AbstractValidator<RequsteRegister>
    {
        public RegisterViladation()
        {
            
                RuleFor(x => x.Firstname)
                    .NotEmpty().WithMessage("First name is required.")
                    .MaximumLength(100);

                RuleFor(x => x.Lastname)
                    .NotEmpty().WithMessage("Last name is required.")
                    .MaximumLength(100);
                RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requrd").EmailAddress();
                RuleFor(x => x.Password)
        .NotEmpty().WithMessage("Password is required.")
        .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
        .Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
        .Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
        .Matches("[0-9]").WithMessage("Password must contain at least one digit.")
        .Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
            }
        }
    }

