namespace Upland.ThirdParty.Api.Types
{
    public class Racetrack
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public string Thumbnail { get; set; }
        public double Distance { get; set; }
        public string Surface { get; set; }
        public string Weather { get; set; }
        public int Laps { get; set; }
        public string AllowedVehicleClasses { get; set; }

        public List<List<decimal>> Path { get; set; }
        public List<List<List<decimal>>> Boundaries { get; set; }
        public List<decimal> Center { get; set; }
    }
}
