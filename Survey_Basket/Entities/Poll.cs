namespace Survey_Basket.Entities
{
    public class Poll : Aditble
    {
        public int Id { get; set; }

        public String title { get; set; } = String.Empty;

        public string sumary { get; set; } = String.Empty;

        public DateOnly enddate { get; set; }

        public DateOnly startdate { get; set; }


        public bool isPublished { get; set; }


        public ICollection<Question> questions { get; set; } = [];



    }
}
