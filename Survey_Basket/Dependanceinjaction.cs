
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

using Survey_Basket.Exceptionhandel;
using Survey_Basket.Services.AthountcationServisece;
using Survey_Basket.Services.jwtServices;
using Survey_Basket.Services.pollserveices;
using Survey_Basket.Services.QuestionServece;
using Survey_Basket.Services.ResultVote;
using Survey_Basket.Services.ResulVotet;
using System.Text;

namespace Survey_Basket
{
    public static class Dependanceinjaction
    {
        public static IServiceCollection addservises(this IServiceCollection dep, IConfiguration con)
        {
            return dep
               .addinterface()
               .addpcontext(con)
               .addidentity()
               .addvalidation()
               .addmapper()
              .AddJwt(con);
        }

        public static IServiceCollection addpcontext(this IServiceCollection dep, IConfiguration conf)
        {
            var con = conf.GetConnectionString("DefaultConnection");
            dep.AddDbContext<ApplictionDbcontextcs>(option =>
                option.UseSqlServer(con));

            return dep; 
        }

        public static IServiceCollection addinterface(this IServiceCollection dep)
        {
            dep.AddScoped<IservecePoll, Servicepoll>();
            dep.AddScoped<IAuthservices,Authoservices>();
            dep.AddScoped<IQuestionservesce, Questionservces>();
            dep.AddScoped<IVotes, Votes>();
            dep.AddScoped<IResultvote,ResultVote>();
            dep.AddProblemDetails();
            dep.AddExceptionHandler<GlobalException>();
            return dep;
        }

        public static IServiceCollection addidentity(this IServiceCollection dep)
        {
            dep.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplictionDbcontextcs>();

            return dep;
        }

        public static IServiceCollection addmapper(this IServiceCollection dep)
        {
            var conf = TypeAdapterConfig.GlobalSettings;
            conf.Scan(Assembly.GetExecutingAssembly());
            dep.AddSingleton<Mapper>(new Mapper(conf));

            return dep;
        }

        public static IServiceCollection addvalidation(this IServiceCollection dep)
        {
            dep.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            dep.AddFluentValidationAutoValidation();

            return dep;
        }


        public static IServiceCollection AddJwt(this IServiceCollection dep,IConfiguration con)
        {
            dep.Configure<SettingJwt>(con.GetSection(SettingJwt.getSection));
            var jwtSettings = con.GetSection(SettingJwt.getSection).Get<SettingJwt>();

            dep.AddSingleton<IJwtServices, JwtServices>();
            dep.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(o =>
            {
                o.MapInboundClaims = false;
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {

                    ValidateAudience = true,
                    ValidateIssuer = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,


                    ValidAudience = jwtSettings.Audience,
                    ValidIssuer = jwtSettings.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });

            return dep;


        }
    }
}