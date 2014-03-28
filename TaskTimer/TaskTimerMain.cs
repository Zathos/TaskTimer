using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer
{
    static class TaskTimerMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var trayIcon = new NotifyIcon())
            {
                var taskList = new MenuItem("Tasks");
                var taskTimer = new TaskTimerModel(taskList);

                trayIcon.Icon = Resources.TasksIcon;
                trayIcon.ContextMenu = new ContextMenu(new MenuItem[] {
                            taskList,
                            new MenuItem("-"),
                            new MenuItem("Manage Tasks", (s, e) => {new TaskTimerForm(taskTimer).Show();}),
                            new MenuItem("Exit", (s, e) => Application.Exit())
                            });
                
                trayIcon.Visible = true;

                Application.Run();
            }
        }
    }
}
