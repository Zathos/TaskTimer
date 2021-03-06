﻿using System;
using System.Windows.Forms;
using TaskTimer.Persistent;

namespace TaskTimer
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            var taskLogger = new XmlTaskLogger();
            using (var taskManager = new MenuManager())
            {
                var t = new TaskTimer(taskLogger, taskManager);
                Application.Run();
            }
        }
    }
}