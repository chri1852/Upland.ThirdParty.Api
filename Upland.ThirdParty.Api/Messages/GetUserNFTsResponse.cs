using Upland.ThirdParty.Api.Types;

namespace Upland.ThirdParty.Api.Messages
{
    public class GetUserNFTsResponse
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalResults { get; set; }
        public List<NFTAsset> Results { get; set; }
    }
}
