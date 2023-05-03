namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class WebHookData
    {
        public string Code { get; set; }
        public string UserId { get; set; }
        public string AccessToken { get; set; }
        public long ContainerId { get; set; }
        public string OwnerEOSId { get; set; }
        public string TransactionId { get; set; }
        public string Message { get; set; }
    }
}
