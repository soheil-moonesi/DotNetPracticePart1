namespace HeartTalk.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        
        public int NoteId { get; set; }

        public Note Note { get; set; }

        public int CommentSympathy { get; set; }

    }
}
