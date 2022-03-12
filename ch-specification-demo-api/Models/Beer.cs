namespace ch_specification_demo_api.Models
{
    public class Beer : BaseModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }
    }
}
