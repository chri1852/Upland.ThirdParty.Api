namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class TravelEntry
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<decimal> From { get; set; }
        public List<decimal> To { get; set; }
        public string Type { get; set; }
    }
}
