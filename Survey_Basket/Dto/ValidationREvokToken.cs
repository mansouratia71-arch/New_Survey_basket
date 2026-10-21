namespace Survey_Basket.Dto
{
    public class ValidationREvokToken:AbstractValidator<RequestRevokRefreshToken>
    {
        public ValidationREvokToken()
        {
            RuleFor(a => a.RefeshtoheRevok).NotEmpty();
            
        }
    }
}
