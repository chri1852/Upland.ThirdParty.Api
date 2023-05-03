using Upland.ThirdParty.Api.Types;

namespace Upland.ThirdParty.Api.Messages
{
    public class PostUserJoinEscrow
    {
        public int containerId { get; set; }
        public double upxAmount { get; set; }
        public double sparkAmount { get; set; }
        public List<NFTAsset> assets { get; set; }
    }
}
