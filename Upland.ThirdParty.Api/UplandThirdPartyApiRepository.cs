using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using Upland.ThirdParty.Api.Abstractions;
using Upland.ThirdParty.Api.Messages;
using Upland.ThirdParty.Api.Types;

namespace Upland.ThirdParty.Api
{
    public class UplandThirdPartyApiRepository : IUplandThirdPartyApiRepository
    {
        private HttpClient httpClient;
        private readonly IConfiguration _configuration;
        private readonly string baseUrl;
        private string basicAuthToken;
        private readonly string linkedEOS;

        public UplandThirdPartyApiRepository(int appId, string securityKey)
        {
            this.basicAuthToken = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(appId + ":" + securityKey));
            this.baseUrl = _configuration["UplandThirdPartyApi:Url"];
            this.linkedEOS = _configuration["UplandThirdPartyApi:LinkedEOS"];
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        }

        public UplandThirdPartyApiRepository(int appId, string securityKey, string url)
        {
            this.basicAuthToken = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(appId + ":" + securityKey));
            this.baseUrl = url;
            this.linkedEOS = _configuration["UplandThirdPartyApi:LinkedEOS"];
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        }

        public UplandThirdPartyApiRepository(IConfiguration configuration)
        {
            _configuration = configuration;

            this.basicAuthToken = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1")
                .GetBytes(_configuration["UplandThirdPartyApi:ApplicationId"] + ":" + _configuration["UplandThirdPartyApi:SecurityKey"]));
            this.baseUrl = _configuration["UplandThirdPartyApi:Url"];
            this.linkedEOS = _configuration["UplandThirdPartyApi:LinkedEOS"];
            this.httpClient = new HttpClient();
            this.httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            this.httpClient.DefaultRequestHeaders.Add("Accept-Language", "en-US,en;q=0.9");
        }

        public string GetLinkedEOS()
        {
            return this.linkedEOS;
        }

        #region /* Authentication Flow */

        public async Task<PostUserAppAuthResponse> PostOTP()
        {
            PostUserAppAuthResponse response;
            string requestUri = string.Format("{0}auth/otp/init", baseUrl);

            response = await PostApi<PostUserAppAuthResponse>(requestUri, null);

            return response;
        }

        #endregion /* Authentication Flow */

        #region /* Upland User Information */

        public async Task<GetUserProfileResponse> GetUserProfile(string authToken)
        {
            GetUserProfileResponse response = new GetUserProfileResponse();

            string requestUri = string.Format("{0}user/profile", baseUrl);

            response = await GetApi<GetUserProfileResponse>(requestUri, authToken);

            return response;
        }

        public async Task<GetUserNFTsResponse> GetUserNFTAssets(string authToken, int page, int pageSize, List<string> categories)
        {
            GetUserNFTsResponse response = new GetUserNFTsResponse();

            string requestUri = string.Format("{0}user/assets/nfts?currentPage={1}&pageSize={2}", baseUrl, page, pageSize);

            foreach (string entry in categories)
            {
                requestUri += "&categories[]=" + entry;
            }

            response = await GetApi<GetUserNFTsResponse>(requestUri, authToken);

            return response;
        }

        public async Task<GetUserBalancesResponse> GetUserBalances(string authToken)
        {
            GetUserBalancesResponse response = new GetUserBalancesResponse();

            string requestUri = string.Format("{0}user/balances", baseUrl);

            response = await GetApi<GetUserBalancesResponse>(requestUri, authToken);

            return response;
        }

        public async Task<GetUserPropertyResponse> GetUserProperties(string authToken, int page, int pageSize)
        {
            GetUserPropertyResponse response = new GetUserPropertyResponse();

            string requestUri = string.Format("{0}user/assets/properties?currentPage={1}&pageSize={2}", baseUrl, page, pageSize);

            response = await GetApi<GetUserPropertyResponse>(requestUri, authToken);

            return response;
        }

        public async Task<PostUserJoinEscrowResponse> PostJoinEscrow(string authToken, PostUserJoinEscrow request)
        {
            PostUserJoinEscrowResponse response = new PostUserJoinEscrowResponse();

            string requestUri = string.Format("{0}user/join", baseUrl);

            response = await PostApi<PostUserJoinEscrowResponse>(requestUri, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"), authToken);

            return response;
        }

        public async Task<GetUserTravelsResponse> GetUserTravels(string authToken, int page, int pageSize)
        {
            GetUserTravelsResponse response = new GetUserTravelsResponse();

            string requestUri = string.Format("{0}user/travels?currentPage={1}&pageSize={2}", baseUrl, page, pageSize);

            response = await GetApi<GetUserTravelsResponse>(requestUri, authToken);

            return response;
        }

        #endregion /* Upland User Information */

        #region /* Escrow Container Management */

        public async Task LockContainer(int containerId)
        {
            string requestUri = string.Format("{0}containers/{1}/lock", baseUrl, containerId);

            await PostApi<Task>(requestUri, null);
        }

        public async Task<EscrowContainer> PostNewEscrowContainer()
        {
            EscrowContainer escrow;
            string requestUri = string.Format("{0}containers", baseUrl);

            escrow = await PostApi<EscrowContainer>(requestUri, new StringContent("", Encoding.UTF8, "application/json"));

            return escrow;
        }

        public async Task<EscrowContainer> PostRefreshEscrowContainer(int containerId)
        {
            EscrowContainer escrow;

            string requestUri = string.Format("{0}containers/{1}/refresh-expiration-time", baseUrl, containerId);

            escrow = await PostApi<EscrowContainer>(requestUri, null);

            return escrow;
        }

        public async Task<EscrowContainer> GetEscrowContainerById(int containerId)
        {
            EscrowContainer escrow;
            string requestUri = string.Format("{0}containers/{1}", baseUrl, containerId);

            escrow = await GetApi<EscrowContainer>(requestUri);

            return escrow;
        }

        public async Task<PostEscrowResolveResponse> PostResolveEscrowContainer(int containerId, List<EscrowAction> escrowActions)
        {
            PostEscrowResolveRequest request = new PostEscrowResolveRequest();
            PostEscrowResolveResponse response;
            request.actions = escrowActions;

            string requestUri = string.Format("{0}containers/{1}/resolve", baseUrl, containerId);

            response = await PostApi<PostEscrowResolveResponse>(requestUri, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            return response;
        }

        public async Task<PostEscrowResolveResponse> PostRefundEscrowContainer(int containerId)
        {
            PostEscrowResolveResponse response;
            string requestUri = string.Format("{0}containers/{1}/refund", baseUrl, containerId);

            response = await PostApi<PostEscrowResolveResponse>(requestUri, null);

            return response;
        }

        public async Task DeleteEscrowTransaction(int containerId, string transactionId)
        {
            string requestUri = string.Format("{0}containers/{1}/transactions/{2}", baseUrl, containerId, transactionId);

            await DeleteApi(requestUri, null);
        }

        #endregion /* Escrow Container Management */

        #region /* Generic Endpoints */

        public async Task<List<Racetrack>> GetRacetracksByCityName(string cityName)
        {
            GetTracksResponse response;

            string requestUri = string.Format("{0}tracks?cityName={1}", baseUrl, cityName);

            response = await GetApi<GetTracksResponse>(requestUri, null);

            return response.Tracks;
        }

        public async Task<Racetrack> GetRacetrackById(int racetrackId)
        {
            Racetrack response;

            string requestUri = string.Format("{0}tracks/{1}", baseUrl, racetrackId);

            response = await GetApi<Racetrack>(requestUri, null);

            return response;
        }

        public async Task<List<Building>> GetBuildingsByRaceTrackId(int racetrackId)
        {
            GetBuildingsResponse response;

            string requestUri = string.Format("{0}tracks/{1}/buildings", baseUrl, racetrackId);

            response = await GetApi<GetBuildingsResponse>(requestUri, null);

            return response.Buildings;
        }

        public async Task<List<Building>> GetBuildingsByBoundaries(List<List<List<decimal>>> boundaries)
        {
            GetBuildingsRequest request = new GetBuildingsRequest();
            GetBuildingsResponse response;
            request.boundaries = boundaries;

            string requestUri = string.Format("{0}buildings", baseUrl);

            response = await PostApi<GetBuildingsResponse>(requestUri, new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));

            return response.Buildings;
        }

        public async Task<List<City>> GetCities()
        {
            GetCitiesResponse response = new GetCitiesResponse();

            string requestUri = string.Format("{0}cities", baseUrl);

            response = await GetApi<GetCitiesResponse>(requestUri, null);

            return response.Cities;
        }

        public async Task<GetPropertiesResponse> GetProperties(int page, int pageSize, int cityId, string textSearch)
        {
            GetPropertiesResponse response;

            string requestUri = string.Format("{0}properties?currentPage={1}&pageSize={2}&cityId={3}&testSearch={4}", baseUrl, page, pageSize, cityId, textSearch);

            response = await GetApi<GetPropertiesResponse>(requestUri, null);

            return response;
        }

        public async Task<Property> GetPropertyById(long propertyId)
        {
            Property response;

            string requestUri = string.Format("{0}properties/{1}", baseUrl, propertyId);

            response = await GetApi<Property>(requestUri, null);

            return response;
        }

        public async Task<List<Neighborhood>> GetNeighborhoods(int cityId, string textSearch)
        {
            GetNeighborhoodsResponse response = new GetNeighborhoodsResponse();

            string requestUri = string.Format("{0}neighborhoods?cityId={1}&textSearch={2}", baseUrl, cityId, textSearch);

            response = await GetApi<GetNeighborhoodsResponse>(requestUri, null);

            return response.Results;
        }

        public async Task<List<Collection>> GetCollections()
        {
            GetCollectionsResponse response = new GetCollectionsResponse();

            string requestUri = string.Format("{0}collections", baseUrl);

            response = await GetApi<GetCollectionsResponse>(requestUri, null);

            return response.Results;
        }

        public async Task<List<TreasureHistoryEntry>> GetTreasureHistory(int page, int pageSize, int cityId)
        {
            GetTreasureHistoryResponse response = new GetTreasureHistoryResponse();

            string requestUri = string.Format("{0}treasures-history?currentPage={1}&pageSize={2}&cityId={3}" + baseUrl, page, pageSize, cityId);

            response = await GetApi<GetTreasureHistoryResponse>(requestUri, null);

            return response.Results;
        }

        #endregion /* Generic Endpoints */

        #region /* Dev Shops */

        public async Task<List<DevShop>> GetDevShops()
        {
            GetDevShopsResponse response;

            string requestUri = string.Format("{0}devshops", this.baseUrl);

            response = await GetApi<GetDevShopsResponse>(requestUri, null);

            return response.Results;
        }

        public async Task<bool> GetIsInRange(Guid devShopId, Guid userId)
        {
            GetInRangeResponse response;

            string requestUri = string.Format("{0}devshops/{1}/check-user-intersection/{2}", this.baseUrl, devShopId.ToString(), userId.ToString());

            response = await GetApi<GetInRangeResponse>(requestUri, null);

            return response.IsInRange;
        }

        #endregion /* Dev Shops */

        #region /* API Functions */

        private async Task<T> GetApi<T>(string requestUri, string authToken = null)
        {
            HttpResponseMessage httpResponse;
            string responseJson;

            if (authToken == null)
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.basicAuthToken);
            }
            else
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            httpResponse = await this.httpClient.GetAsync(requestUri);

            if (httpResponse.IsSuccessStatusCode)
            {
                responseJson = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                throw new Exception(httpResponse.StatusCode.ToString());
            }
        }

        private async Task<T> PostApi<T>(string requestUri, HttpContent content, string authToken = null)
        {
            HttpResponseMessage httpResponse;
            string responseJson;

            if (authToken == null)
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.basicAuthToken);
            }
            else
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            httpResponse = await this.httpClient.PostAsync(requestUri, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                responseJson = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                throw new Exception(httpResponse.StatusCode.ToString());
            }
        }

        private async Task<T> PutApi<T>(string requestUri, HttpContent content, string authToken = null)
        {
            HttpResponseMessage httpResponse;
            string responseJson;

            if (authToken == null)
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.basicAuthToken);
            }
            else
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            httpResponse = await this.httpClient.PutAsync(requestUri, content);

            if (httpResponse.IsSuccessStatusCode)
            {
                responseJson = await httpResponse.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(responseJson);
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return (T)Activator.CreateInstance(typeof(T));
            }
            else
            {
                throw new Exception(httpResponse.StatusCode.ToString());
            }
        }

        private async Task DeleteApi(string requestUri, string authToken = null)
        {
            HttpResponseMessage httpResponse;
            string responseJson;

            if (authToken == null)
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", this.basicAuthToken);
            }
            else
            {
                this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authToken);
            }

            httpResponse = await this.httpClient.DeleteAsync(requestUri);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }
            else if (httpResponse.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return;
            }
            else
            {
                throw new Exception(httpResponse.StatusCode.ToString());
            }
        }

        #endregion /* API Functions */
    }
}