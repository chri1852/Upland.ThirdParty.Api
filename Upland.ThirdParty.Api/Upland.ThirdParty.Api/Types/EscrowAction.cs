namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class EscrowAction
    {
        public int? assetId { get; set; }
        public double? amount { get; set; }
        public string category { get; set; }
        public string targetEosId { get; set; }
        public bool isRefund { get; set; }
    }
}
