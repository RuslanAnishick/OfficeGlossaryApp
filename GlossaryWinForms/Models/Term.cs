namespace GlossaryWinForms.Models
{
    public class Term
    {
        public int Id { get; set; }

        public string Title { get; set; } = "";

        public string Category { get; set; } = "";

        public string Description { get; set; } = "";

        public string Example { get; set; } = "";
    }
}