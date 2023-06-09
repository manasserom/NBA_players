namespace backend.Models
{
    public class MetadataDTO
    {
        public int total_pages { get; set; }
        public int current_page { get; set; }
        public int? next_page { get; set; }
        public int per_page { get; set; }
        public int total_count { get; set; }

    }
}
