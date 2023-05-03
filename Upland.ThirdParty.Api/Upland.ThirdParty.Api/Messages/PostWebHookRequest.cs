using Optimizer.Packages.Apis.UplandThirdParty.Types;

namespace Optimizer.Packages.Apis.UplandThirdParty.Messages
{
    public class PostWebHookRequest
    {
        public string Type { get; set; }
        public WebHookData Data { get; set; }
    }
}
