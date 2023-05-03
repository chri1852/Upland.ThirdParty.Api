namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class DevShop
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppUrl { get; set; }
        public string Description { get; set; }
        public DevShopLocation Location { get; set; }
    }

    public class DevShopLocation
    {
        public long Id { get; set; }
        public string Address { get; set; }
        public DevShopIdName City { get; set; }
        public DevShopCoordinates Coordinates { get; set; }
        public DevShopIdName Neighborhood { get; set; }
    }

    public class DevShopIdName
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class DevShopCoordinates
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}
