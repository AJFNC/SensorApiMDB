namespace SensorApiMDB.Models
{
    public class SensorDatabaseSettings : ISensorDatabaseSettings
    {
        public string SensorsCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
    public interface ISensorDatabaseSettings
    {
        string SensorsCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
