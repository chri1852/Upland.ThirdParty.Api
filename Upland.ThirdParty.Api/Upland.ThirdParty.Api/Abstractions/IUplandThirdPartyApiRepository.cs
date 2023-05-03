namespace Upland.ThirdParty.Api.Abstractions
{
    public interface IUplandThirdPartyApiRepository
    {
        string GetLinkedEOS();

        // Authentication Flow
        Task<PostUserAppAuthResponse> PostOTP();

        // Upland User Information
        Task<GetUserProfileResponse> GetUserProfile(string authToken);
        Task<GetUserNFTsResponse> GetUserNFTAssets(string authToken, int page, int pageSize, List<string> categories);
        Task<GetUserBalancesResponse> GetUserBalances(string authToken);
        Task<GetUserPropertyResponse> GetUserProperties(string authToken, int page, int pageSize);
        Task<PostUserJoinEscrowResponse> PostJoinEscrow(string authToken, PostUserJoinEscrow request);
        Task<GetUserTravelsResponse> GetUserTravels(string authToken, int page, int pageSize);

        // Escrow Container Management
        Task LockContainer(int containerId);
        Task<EscrowContainer> PostNewEscrowContainer();
        Task<EscrowContainer> PostRefreshEscrowContainer(int containerId);
        Task<EscrowContainer> GetEscrowContainerById(int containerId);
        Task<PostEscrowResolveResponse> PostResolveEscrowContainer(int containerId, List<EscrowAction> escrowActions);
        Task<PostEscrowResolveResponse> PostRefundEscrowContainer(int containerId);
        Task DeleteEscrowTransaction(int containerId, string transactionId);

        // Generic Endpoints
        Task<List<Racetrack>> GetRacetracksByCityName(string cityName);
        Task<Racetrack> GetRacetrackById(int racetrackId);
        Task<List<Building>> GetBuildingsByRaceTrackId(int racetrackId);
        Task<List<Building>> GetBuildingsByBoundaries(List<List<List<decimal>>> boundaries);
        Task<List<City>> GetCities();
        Task<GetPropertiesResponse> GetProperties(int page, int pageSize, int cityId, string textSearch);
        Task<Property> GetPropertyById(long propertyId);
        Task<List<Neighborhood>> GetNeighborhoods(int cityId, string textSearch);
        Task<List<Collection>> GetCollections();
        Task<List<TreasureHistoryEntry>> GetTreasureHistory(int page, int pageSize, int cityId);

        // Dev Shops
        Task<List<DevShop>> GetDevShops();
        Task<bool> GetIsInRange(Guid devShopId, Guid userId);
    }
}
