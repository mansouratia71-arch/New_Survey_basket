namespace Survey_Basket.ErorrHandel.Error
{
    public class PollError
    {
        public static readonly Erorr Notfound = new Erorr("not found", "not found the poll",StatusCodes.Status404NotFound);

        public static readonly Erorr dublicateDPoll= new Erorr("dublicated poll", "the title of poll is dublicted",StatusCodes.Status409Conflict);
    }
}
