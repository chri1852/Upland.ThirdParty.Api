using Optimizer.Packages.Apis.UplandThirdParty.Types;

namespace Optimizer.Packages.Apis.UplandThirdParty.Messages
{
    public class PostEscrowResolveRequest
    {
        public List<EscrowAction> actions { get; set; }
    }
}
