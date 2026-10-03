namespace Survey_Basket.Entities
{
    public sealed class Vote
    {
        public int id {  get; set; }

        public int pollid {  get; set; }

        public Poll poll { get; set; } = default!;

        public string userId {  get; set; }=string.Empty;

        public ApplicationUser user { get; set; } = default!;

        public DateTime submititon { get; set; }

        public ICollection<VoteAnswer> voteAnswer { get; set; } = [];


    }
}
