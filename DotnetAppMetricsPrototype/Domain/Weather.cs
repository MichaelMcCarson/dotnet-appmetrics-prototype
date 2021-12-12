namespace DotnetAppMetricsPrototype.Domain
{
    public class Weather
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Weather(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
