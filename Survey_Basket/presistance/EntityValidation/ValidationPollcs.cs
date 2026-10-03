using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_Basket.Entities;

namespace Survey_Basket.presistance.EntityValidation
{
    public class ValidationPollcs : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.HasIndex(x=>x.title).IsUnique();
            builder.Property(x => x.title).HasMaxLength(50);
            builder.Property(x => x.sumary).HasMaxLength(150);
                
        }
    }
}
