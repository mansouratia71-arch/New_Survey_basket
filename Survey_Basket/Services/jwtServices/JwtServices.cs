using Azure.Core;
using Microsoft.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens.Experimental;
using Survey_Basket.Dto.EntityAutho;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;

namespace Survey_Basket.Services.jwtServices
{
    public class JwtServices(IOptions<SettingJwt> op) : IJwtServices
    {
        private readonly SettingJwt _option=op.Value;
        public async Task<(string Token, int ExpiresIn)> GenerateTokenAsync(ApplicationUser user,CancellationToken cancellation)
        {
            Claim[] clims =[

                new(JwtRegisteredClaimNames.Sub,user.Id),
                new(JwtRegisteredClaimNames.Email,user.Email!),
                new(JwtRegisteredClaimNames.FamilyName,user.Lastname),
                new(JwtRegisteredClaimNames.GivenName,user.Firstname),
                new(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            ];

            var SymetricScurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Key));
            var SigningCredentials =new SigningCredentials(SymetricScurityKey , SecurityAlgorithms.HmacSha256);

            int Expresin = 10;
            var token = new JwtSecurityToken(

     issuer: _option.Issuer,
    audience: _option.Audience,
    claims: clims, 
    expires: DateTime.UtcNow.AddMinutes(_option.DurationInMinutes), 
    signingCredentials: SigningCredentials

                );

            return (new JwtSecurityTokenHandler().WriteToken(token),Expresin);

        }

        public async Task<string?> Validation(string Token)
        {
            var SymetricScurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_option.Key));
            JwtSecurityTokenHandler Handler =new JwtSecurityTokenHandler();

            try
            {
                var scurtyToken = Handler.ValidateToken(Token,new TokenValidationParameters {
        IssuerSigningKey = SymetricScurityKey,
        ValidateIssuerSigningKey = true,
        ValidateAudience = false,
        ValidateIssuer = false,
        ClockSkew=TimeSpan.Zero
            },
        out SecurityToken securityToken
        );

                var jwt = (JwtSecurityToken)securityToken;

                return jwt.Claims.FirstOrDefault(X => X.Type == JwtRegisteredClaimNames.Sub)?.Value;


            }
            catch
            {
                return null;
            }



        }
    }
}