using Survey_Basket.Dto.EnttyQuestion;

namespace Survey_Basket.maping
{
    public class Questionmapingcs : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Question, QuestionResponse>().Map(
                dest=>dest.answers,sur=>sur.answer
                );
        }
    }
}
