using MongoDB.Driver;
using SensorApiMDB.Models;
using System.Collections.Generic;
using System.Linq;

namespace SensorApiMDB.Service
{
    public class SensorService
    {
        private readonly IMongoCollection<Sensor> _sensors;

        public SensorService(ISensorDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _sensors = database.GetCollection<Sensor>(settings.SensorsCollectionName);
        }

        public List<Sensor> Get() =>
            _sensors.Find(sensor => true).ToList();

        public Sensor Get(string id) =>
            _sensors.Find<Sensor>(sensor => sensor.Id == id).FirstOrDefault();

        public Sensor Create(Sensor sensor)
        {
            _sensors.InsertOne(sensor);
            return sensor;
        }

        public void Update(string id, Sensor sensorIn) =>
            _sensors.ReplaceOne(sensor => sensor.Id == id, sensorIn);

        public void Remove(Sensor sensorIn) =>
            _sensors.DeleteOne(sensor => sensor.Id == sensorIn.Id);

        public void Remove(string id) =>
            _sensors.DeleteOne(sensor => sensor.Id == id);
    }
}
