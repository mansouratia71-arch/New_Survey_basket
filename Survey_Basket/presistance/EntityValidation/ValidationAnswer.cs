using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_Basket.Entities;

namespace Survey_Basket.presistance.EntityValidation
{
    public class ValidationAnswer : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {

            builder.HasKey(x => x.Id);
            builder.Property(x => x.content).IsRequired();
            builder.HasIndex(x => new
            {
                x.content,
                x.questionId
            }).IsUnique();

         


        }
    }
}
