using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Survey_Basket.Entities;

namespace Survey_Basket.presistance.EntityValidation
{
    public class ValidationVoteAnswer : IEntityTypeConfiguration<VoteAnswer>
    {
        public void Configure(EntityTypeBuilder<VoteAnswer> builder)
        {
            builder.HasIndex(x=>new {x.voteId,x.QuestionId}).IsUnique();   
        }
    }
}
