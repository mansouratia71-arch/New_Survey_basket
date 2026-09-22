using System.Data.SqlTypes;
using System.Diagnostics.Tracing;

namespace Survey_Basket.ErorrHandel
{
    public class Result
    {
        public bool IsSuccess {  get;}

        public bool IsFailure => !IsSuccess;

        public Erorr erorr { get; }

        public Result(bool message, Erorr erorr)
        {
            this.erorr = erorr;
            IsSuccess = message;
        }

        public static Result Success()=> new Result(true, Erorr.None);

        public static Result Failure(Erorr erorr) => new Result(false, erorr);

        public static Result<T> Success<T>(T value) => new Result<T>(value,true, Erorr.None);

        public static Result<T> Failure<T>(Erorr erorr) => new Result<T>(default,false, erorr);


    }

    public class Result<T> : Result
    {
        T _Value;

        public T Value => IsSuccess
            ? _Value
            : throw new InvalidOperationException("لا يمكن قراءة القيمة من نتيجة فاشلة.");

        public Result(T value,bool IsSuccess,Erorr erorr) : base(IsSuccess, erorr)
        {
            _Value = value;
           
        }

    }
}
