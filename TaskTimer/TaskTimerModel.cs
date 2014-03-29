using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TaskTimer.Annotations;
using TaskTimer.Properties;

namespace TaskTimer
{
    public class TaskTimerModel : ITaskTimerModel, IDisposable, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public TaskTimerModel([NotNull] ITaskLogger taskLogger)
        {
            _taskLogger = taskLogger;
            _taskItems = _taskLogger.LoadTaskList();

            InitializeNewTrayIcon();



            //##########  Testin area
            const string TestName = "task1";
            AddNewTask(TestName);
        }

        public IList<TaskItem> TaskItems
        {
            get { return _taskItems; }
        }

        public void AddNewTask(string taskName)
        {
            var testMenuItem = new MenuItem(taskName, TaskClicked);
            _taskList.MenuItems.Add(testMenuItem);

            var testTaskItem = new TaskItem(testMenuItem);
            _taskItems.Add(testTaskItem);
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

        protected virtual void OnPropertyChanged([CanBeNull] string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        [CanBeNull]
        private TaskItem GetActiveTask()
        {
            return _taskItems.FirstOrDefault(x => x.Active);
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

        [CanBeNull]
        private TaskItem LookupTask([NotNull] object sender)
        {
            var menuItem = sender as MenuItem;
            return menuItem == null ? null : _taskItems.FirstOrDefault(x => x.TaskName == menuItem.Text);
        }

        private void TaskClicked([NotNull] Object sender, [CanBeNull] EventArgs e)
        {
            var now = DateTime.Now;

            var newActiveTask = LookupTask(sender);
            if (newActiveTask == null)
            {
                return;
            }

            var activeTask = GetActiveTask();
            if (activeTask != null)
            {
                activeTask.StopTiming(now);
            }

            if (newActiveTask != activeTask)
            {
                newActiveTask.StartTiming(now);
            }

            _taskLogger.SaveChanges(_taskItems);
            OnPropertyChanged("TaskItems");
        }

        private IList<TaskItem> _taskItems;
        private readonly ITaskLogger _taskLogger;
        private bool _isDisposed;
        private MenuItem _taskList;
        private NotifyIcon _trayIcon;
    }
}