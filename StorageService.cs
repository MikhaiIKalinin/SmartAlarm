using System.Collections.Generic;
using System.IO;
using System.Text.Json; 

namespace SmartAlarm
{
    public class StorageService
    {
        private readonly string filePath = "alarms.json";

        public void SaveData(List<Alarm> alarms)
        {
            string jsonString = JsonSerializer.Serialize(alarms, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }

        public List<Alarm> LoadData()
        {
            if (!File.Exists(filePath))
            {
                return new List<Alarm>();
            }

            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Alarm>>(jsonString) ?? new List<Alarm>();
        }
    }
}