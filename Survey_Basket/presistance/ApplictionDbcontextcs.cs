using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Survey_Basket.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;

namespace Survey_Basket.presistance
{
    public class ApplictionDbcontextcs(DbContextOptions<ApplictionDbcontextcs> option,IHttpContextAccessor httpContextAccessor) :IdentityDbContext<ApplicationUser>(option)
    {
        private readonly IHttpContextAccessor _httpContextAccessor= httpContextAccessor ?? new HttpContextAccessor();
        public DbSet<Poll> Polls { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RefreshToken>().ToTable("RefreshTokens");
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellation)
        {
            var userId = _httpContextAccessor.HttpContext?
                .User
                .FindFirst(JwtRegisteredClaimNames.Sub)?
                .Value;

            foreach (var entity in ChangeTracker.Entries())
            {
                if(entity.Entity is not Aditble aditble)
                    continue;
                if(entity.State == EntityState.Added)
                {
                    aditble.addUserId = userId??"not user";
                    aditble.Addon = DateTime.UtcNow;
                }
                if (entity.State == EntityState.Modified)
                {
                    aditble.UpdateUserId= userId??string.Empty;
                    aditble.Updaton = DateTime.UtcNow;
                }

            }

            return await base.SaveChangesAsync(cancellation);
        }
    }
}
