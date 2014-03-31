using System;
using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer
{
    internal static class TaskTimerMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var taskLogger = new XmlTaskLogger();
            using(var taskManager = new MenuManager())
            {
                var t = new TaskTimerModel(taskLogger, taskManager);
                Application.Run();
            }
        }
    }
}