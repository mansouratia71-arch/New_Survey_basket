namespace Survey_Basket.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public string content { get; set; } = string.Empty;

        public int questionId { get; set; }

        public Question question { get; set; } = default!;
        public bool IsActive { get; set; } = true;
    }
}
