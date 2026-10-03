namespace Survey_Basket.Entities
{
    public class Question:Aditble
    {
        public int Id { get; set; }
        public string content { get; set; }=string.Empty;

        public int pollId { get; set; }

        public Poll Poll { get; set; } = default!;

        public bool IsActive { get; set; } = true;

        public ICollection<Answer> answer { get; set; } = [];
    }
}
