namespace Upland.ThirdParty.Api.Types
{
    public class EscrowContainer
    {
        public int Id { get; set; }
        public int AppId { get; set; }
        public string Status { get; set; }
        public DateTime ExpirationDate { get; set; }
        public double UPX { get; set; }
        public double Spark { get; set; }
        public List<EscrowAsset> Assets { get; set; }
    }
}
