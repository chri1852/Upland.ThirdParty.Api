namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class Neighborhood
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public double Area { get; set; }
        public List<List<List<decimal>>> Boundaries { get; set; }
        public List<decimal> Center { get; set; }
    }
}
