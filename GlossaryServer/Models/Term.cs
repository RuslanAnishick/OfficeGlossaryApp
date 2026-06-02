namespace GlossaryServer.Models
{
    public class Term
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Example { get; set; } = string.Empty;
    }
}