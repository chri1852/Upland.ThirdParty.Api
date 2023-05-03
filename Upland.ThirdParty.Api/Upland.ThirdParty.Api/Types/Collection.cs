namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class Collection
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int RarityLevel { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public double YieldBoost { get; set; }
        public int OneTimeReward { get; set; }
        public string Image { get; set; }
        public string ImageThumbnail { get; set; }
        public int CityId { get; set; }
    }
}
