namespace Survey_Basket.ErorrHandel.Error
{
    public class PollError
    {
        public static readonly Erorr Notfound = new Erorr("not found", "not found the poll");

        public static readonly Erorr dublicatePoll= new Erorr("dublicated poll", "the title of poll is dublicted");
    }
}
