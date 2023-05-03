using Optimizer.Packages.Apis.UplandThirdParty.Types;

namespace Optimizer.Packages.Apis.UplandThirdParty.Messages
{
    public class PostUserJoinEscrow
    {
        public int containerId { get; set; }
        public double upxAmount { get; set; }
        public double sparkAmount { get; set; }
        public List<NFTAsset> assets { get; set; }
    }
}
