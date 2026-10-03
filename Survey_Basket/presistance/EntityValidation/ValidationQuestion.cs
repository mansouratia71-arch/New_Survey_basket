using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_Basket.Entities;

namespace Survey_Basket.presistance.EntityValidation
{
    public class ValidationQuestion : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x=>x.content).IsRequired();
            builder.HasIndex(x => new
            {
                x.content,
                x.pollId
            }).IsUnique();

                
        }
    }
}
