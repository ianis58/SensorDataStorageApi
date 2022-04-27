namespace SensorDataStorageApi.Models
{
    public class Dht22DatabaseSettings : IDht22DatabaseSettings
    {
        public string MomentsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDht22DatabaseSettings
    {
        string MomentsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
