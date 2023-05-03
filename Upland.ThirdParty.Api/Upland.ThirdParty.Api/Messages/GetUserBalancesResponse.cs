namespace Optimizer.Packages.Apis.UplandThirdParty.Messages
{
    public class GetUserBalancesResponse
    {
        public double AvailableUpx { get; set; }
        public double AvailableSpark { get; set; }
        public double StakedSpark { get; set; }
        public int AvailableSends { get; set; }
    }
}
