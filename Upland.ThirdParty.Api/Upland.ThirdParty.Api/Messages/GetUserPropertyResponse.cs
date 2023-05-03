using Optimizer.Packages.Apis.UplandThirdParty.Types;

namespace Optimizer.Packages.Apis.UplandThirdParty.Messages
{
    public class GetUserPropertyResponse
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public List<Property> Results { get; set; }
    }
}
