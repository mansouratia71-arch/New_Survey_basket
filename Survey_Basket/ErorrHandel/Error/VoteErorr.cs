namespace Survey_Basket.ErorrHandel.Error
{
    public class VoteErorr
    {
      public static readonly Erorr dublicted = new Erorr("error dublicted", " the user is voted befor this ", StatusCodes.Status409Conflict);

       public static  readonly Erorr notfound = new Erorr(" not found ", "the poll not found ",StatusCodes.Status404NotFound);
 
    }
}
