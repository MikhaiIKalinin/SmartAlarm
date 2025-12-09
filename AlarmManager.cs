using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartAlarm
{
    public class AlarmManager
    {
        public List<Alarm> AlarmsList { get; private set; }
        private StorageService _storage;

        public AlarmManager()
        {
            _storage = new StorageService();
            AlarmsList = _storage.LoadData();
        }

        public void CreateAlarm(DateTime time, string melody, bool isSmart)
        {
            var newAlarm = new Alarm(time, melody, isSmart);
            AlarmsList.Add(newAlarm);

            AlarmsList = AlarmsList.OrderBy(a => a.AlarmTime).ToList();

            _storage.SaveData(AlarmsList); 
        }

        public void DeleteAlarm(int index)
        {
            if (index >= 0 && index < AlarmsList.Count)
            {
                AlarmsList.RemoveAt(index);
                _storage.SaveData(AlarmsList); 
            }
        }
    }
}