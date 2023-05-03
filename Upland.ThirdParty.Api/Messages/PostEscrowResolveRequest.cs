using Upland.ThirdParty.Api.Types;

namespace Upland.ThirdParty.Api.Messages
{
    public class PostEscrowResolveRequest
    {
        public List<EscrowAction> actions { get; set; }
    }
}
