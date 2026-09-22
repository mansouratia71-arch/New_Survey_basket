namespace Survey_Basket.ErorrHandel
{
    public record Erorr(string code ,string Discraption)
    {
        public static readonly Erorr None=new Erorr(String.Empty,string.Empty);
    }
}
