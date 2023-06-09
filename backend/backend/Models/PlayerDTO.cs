namespace backend.Models
{
    public class PlayerDTO
    {
        public long id { get; set; }
        public string first_name { get; set; }
        public long? height_feet { get; set; }
        public long? height_inches { get; set; }
        public string last_name { get; set; }
        public string position { get; set; }
        //public Team team { get; set; }
        public long? weight_pounds { get; set; }

    }
}
