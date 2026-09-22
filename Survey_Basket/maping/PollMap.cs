using Mapster;
using Survey_Basket.Dto.Entitypoll;

namespace Survey_Basket.model
{
    public class PollMap : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<Poll, ResponsePoll>()
            .Map(dst => dst.days, src => (src.enddate.DayNumber - src.startdate.DayNumber));
        }
    }
}
