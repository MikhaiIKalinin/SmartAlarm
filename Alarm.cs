using System;

namespace SmartAlarm
{
    public class Alarm
    {
        public DateTime AlarmTime { get; set; }        
        public string MelodyPath { get; set; }         
        public bool IsSmartAwakening { get; set; }     

        public Alarm(DateTime time, string melody, bool isSmart)
        {
            AlarmTime = time;
            MelodyPath = melody;
            IsSmartAwakening = isSmart;
        }

        public Alarm() { }

        public void PlaySignal()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[СИГНАЛ] ♫ Грає: {MelodyPath} | Час: {AlarmTime:HH:mm}");
            Console.ResetColor();
        }
    }
}