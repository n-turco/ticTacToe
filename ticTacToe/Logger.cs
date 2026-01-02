using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ticTacToe
{
    class Logger
    {
        //save log file where ever the .exe is placed
        readonly static string path = AppDomain.CurrentDomain.BaseDirectory;
        readonly static string logPath = Path.Combine(path, "Logfile.log");
        private static readonly object FileLock = new();

        
        public enum LogType
        {
            NORMAL,
            WARNING,
            ERROR
        }
        public static void Log(string message, LogType type)
        {
            try
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string line = $"{timestamp} [{type}] {message}";

                lock (FileLock)
                {
                    File.AppendAllText(logPath, line + Environment.NewLine);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Failed to write to log file.\n\n{ex.Message}",
                    "Logger Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                );
            }
        }
    }
}
