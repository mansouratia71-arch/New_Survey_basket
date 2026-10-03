using Survey_Basket.Dto.EntityAutho;
using Survey_Basket.Dto.EntityRegester;
using Survey_Basket.Services.jwtServices;
using System.Security.Cryptography;

namespace Survey_Basket.Services.AthountcationServisece
{
    public class Authoservices(UserManager<ApplicationUser> usermanger,IJwtServices jwtServices,ApplictionDbcontextcs context) : IAuthservices
    {
        private readonly UserManager<ApplicationUser> _usermanger=usermanger;

        private readonly ApplictionDbcontextcs _context=context;

        private readonly IJwtServices _jwtServices = jwtServices;

        private readonly int RefreshTohenDyes = 14;
        public async Task<AuthResponse?> login(Login login,CancellationToken cancellation)
        {
            var model = await _usermanger.FindByEmailAsync(login.Email);
            if (model is null)
                return null;

            var isValid = await _usermanger.CheckPasswordAsync(model, login.Password);
            if (!isValid)
                return null;

             var(token, expiresIn) = await _jwtServices.GenerateTokenAsync(model,cancellation);


            var refreshtoken = CreateRefreshToken();

            DateTime expriesRefreshToken = DateTime.UtcNow.AddDays(RefreshTohenDyes);

            model.RefreshTokens.Add(new RefreshToken { Expireson = expriesRefreshToken, Token = refreshtoken ,Createdon=DateTime.UtcNow});
            
            await _usermanger.UpdateAsync(model);
           
         





            return new AuthResponse(model.Id, model.Email!, model.UserName!, token, expiresIn, refreshtoken, expriesRefreshToken);
           
        }

        public async Task<RegesterResponse?> RegisterAsync(RequsteRegister request, CancellationToken cancellation)
        {
            var EmailisExist = await _usermanger.FindByEmailAsync(request.Email);
            if (EmailisExist is not null)
                return null;
            var model = request.Adapt<ApplicationUser>();
            var result = await _usermanger.CreateAsync(model, request.Password);
            if (!result.Succeeded)
                return null;

            var (token, expiresIn) = await _jwtServices.GenerateTokenAsync(model, cancellation);



            return new RegesterResponse(model.Id, model.Email!, model.UserName!, token, expiresIn);

        }

        private static string CreateRefreshToken()
        {
            var randomBytes = RandomNumberGenerator.GetBytes(64);

            var refreshToken = Convert.ToBase64String(randomBytes);

            return refreshToken;
        }

        public async Task<AuthResponse?> GetRefreshToken(RequstRfreshTokencs requst, CancellationToken cancellation)
        {
           var userId = await  _jwtServices.Validation(requst.token);
            if (userId is null)
                return null;
            var user = await _context.Users
      .Include(x => x.RefreshTokens)
      .SingleOrDefaultAsync(x => x.Id == userId);

            if (user is null)
                return null;
            var refreshtoken = user.RefreshTokens.SingleOrDefault(x => x.Token== requst.RefreshToken && x.isActive);
            if(refreshtoken is null)
                return null;
            refreshtoken.RevokedOn = DateTime.UtcNow;


            var (newtoken, newexpiresIn) = await _jwtServices.GenerateTokenAsync(user, cancellation);

            var newrefreshtoken = CreateRefreshToken();

            DateTime expriesRefreshToken = DateTime.UtcNow.AddDays(RefreshTohenDyes);

            user.RefreshTokens.Add(new RefreshToken { Expireson = expriesRefreshToken, Token = newrefreshtoken, Createdon = DateTime.UtcNow });

            await _usermanger.UpdateAsync(user);

            return new AuthResponse(user.Id, user.Email!, user.UserName!, newtoken, newexpiresIn, newrefreshtoken, expriesRefreshToken);

        }
    }
    }

