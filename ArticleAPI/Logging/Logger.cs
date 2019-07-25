using System;
using System.IO;

namespace ArticleAPI.Logging
{
    public class Logger
    {
        public string LogFilePath { get; set; }
        public int Level { get; set; }

        public Logger(string logFilePath, int level)
        {
            LogFilePath = logFilePath;
            Level = level;
        }
        private static readonly object LockObject = new object();

        public void Log(string txt, LogType logType)
        {
            lock (LockObject)
            {
                if ((int)logType <= this.Level)
                {
                    var text = "-- Baslangic " + System.DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + 
                               " --" + Environment.NewLine + logType +": "+ txt + Environment.NewLine + 
                               "-- Son --" + Environment.NewLine;

                    File.AppendAllText(LogFilePath, text);
                }
            }
        }
    }
}
