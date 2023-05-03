namespace Upland.ThirdParty.Api.Types
{
    public class Property
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public City City { get; set; }
        public Neighborhood Neighborhood { get; set; }
        public string Status { get; set; }
    }
}
