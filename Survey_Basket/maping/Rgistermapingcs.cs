using Survey_Basket.Dto.EntityRegester;

namespace Survey_Basket.model
{
    public class Rgistermapingcs : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RequsteRegister, ApplicationUser>().Map(
                dest => dest.UserName, src => string.IsNullOrEmpty(src.username) ? src.Email.Split("@")[0] : src.username);
        }
    }
}
