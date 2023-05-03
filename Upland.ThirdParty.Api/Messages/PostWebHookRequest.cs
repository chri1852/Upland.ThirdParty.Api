using Upland.ThirdParty.Api.Types;

namespace Upland.ThirdParty.Api.Messages
{
    public class PostWebHookRequest
    {
        public string Type { get; set; }
        public WebHookData Data { get; set; }
    }
}
