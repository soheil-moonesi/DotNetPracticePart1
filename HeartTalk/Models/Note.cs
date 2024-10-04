namespace HeartTalk.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
        public int SympathyCount { get; set; } = 0;
    }
}


