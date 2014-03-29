using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TaskTimer.Properties;

namespace TaskTimer
{
    public class TaskTimerModel : ITaskTimerModel, IDisposable
    {
        public TaskTimerModel()
        {
            _taskItems = new Dictionary<string, TaskItem>();

            InitializeNewTrayIcon();

            //##########  Testin area
            const string TestName = "task1";

            var testMenuItem = new MenuItem(TestName, TaskClicked);
            _taskList.MenuItems.Add(testMenuItem);

            var testTaskItem = new TaskItem(testMenuItem);
            _taskItems[TestName] = testTaskItem;
        }

        public IList<TaskItem> TaskItems
        {
            get { return _taskItems.Select(task => task.Value).ToList(); }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing)
            {
                if (_trayIcon != null)
                {
                    _trayIcon.Dispose();
                }
            }

            _isDisposed = true;
        }

        private void InitializeNewTrayIcon()
        {
            _taskList = new MenuItem("Tasks");

            _trayIcon = new NotifyIcon
                            {
                                Icon = Resources.TasksIcon,
                                ContextMenu = new ContextMenu(new[]
                                                                  {
                                                                      _taskList,
                                                                      new MenuItem("-"),
                                                                      new MenuItem("Manage Tasks", (s, e) => new TaskTimerForm(this).Show()),
                                                                      new MenuItem("Exit", (s, e) => Application.Exit())
                                                                  }),
                                Visible = true
                            };
        }

        private void TaskClicked(Object sender, EventArgs e)
        {
            var menuItem = sender as MenuItem;
            if (menuItem == null)
            {
                return;
            }

            var taskItem = _taskItems[menuItem.Text];
            if (taskItem == null)
            {
                return;
            }

            menuItem.Checked = !menuItem.Checked;
            taskItem.Active = menuItem.Checked;
        }

        private readonly Dictionary<string, TaskItem> _taskItems;
        private bool _isDisposed;
        private MenuItem _taskList;
        private NotifyIcon _trayIcon;
    }
}