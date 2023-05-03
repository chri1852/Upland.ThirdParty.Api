namespace Upland.ThirdParty.Api.Messages
{
    public class GetUserProfileResponse
    {
        public Guid Id { get; set; }
        public string EOSId { get; set; }
        public string Username { get; set; }
        public double Networth { get; set; }
        public string Level { get; set; }
        public string AvatarUrl { get; set; }
        public string InitialCity { get; set; }
        public string CurrentCity { get; set; }
        public bool IsInJail { get; set; }
    }
}
