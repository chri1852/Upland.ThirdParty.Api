namespace Optimizer.Packages.Apis.UplandThirdParty.Types
{
    public class Building
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public string Model { get; set; }
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public List<decimal> Coordinates { get; set; }
        public List<decimal> Rotate { get; set; }
        public decimal Scale { get; set; }
        public decimal Altitude { get; set; }
        public string Meshes { get; set; }
    }
}
