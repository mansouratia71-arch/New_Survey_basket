using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_Basket.Entities;

namespace Survey_Basket.presistance.EntityValidation
{
    public class ValidationVote : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.HasIndex(x=>new { x.pollid , x.userId }).IsUnique();
          
        }
    }
}
