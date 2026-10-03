using Survey_Basket.Dto.EnttyQuestion;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.Services.QuestionServece
{
    public interface IQuestionservesce
    {
        Task<Result<QuestionResponse>> Addasync(int pollId,CancellationToken cancellationToken,QuestionRequste requste);

        Task<Result<List<QuestionResponse>>> GetAllasync( CancellationToken cancellationToken);

       
        Task<Result<List<QuestionResponse>>> GetByIdasync(int pollId,CancellationToken cancellationToken);

        Task<Result> Toggle(int pollId,int id, CancellationToken cancellationToken);

        Task<Result> updateasync(int pollId,int id, QuestionRequste requste, CancellationToken cancellationToken);
    }
}
