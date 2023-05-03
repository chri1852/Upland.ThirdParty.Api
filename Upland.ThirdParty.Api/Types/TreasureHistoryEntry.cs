namespace Upland.ThirdParty.Api.Types
{
    public class TreasureHistoryEntry
    {
        public string Username { get; set; }
        public int Reward { get; set; }
        public DateTime LockedAt { get; set; }
        public string SpawnAt { get; set; }
        public string FullAddress { get; set; }
        public string TreasureType { get; set; }
    }
}
