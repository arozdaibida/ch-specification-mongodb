namespace ch_specification_demo_api.Features.Beers.Models
{
    public class GetBeersRequest
    {
        public string SearchFilter { get; set; }

        public int Page { get; set; }

        public int PageSize { get; set; }

        public string OrderType { get; set; }

        public string OrderBy { get; set; }

        public bool IsPagingEnable { get; set; }
    }
}
