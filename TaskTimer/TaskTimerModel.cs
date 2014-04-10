using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using TaskTimer.Persistent;
using TaskTimer.POCOs;
using TaskTimer.Properties;

namespace TaskTimer
{
    public class TaskTimerModel : ITaskTimerModel, INotifyPropertyChanged
    {
        private const int InvalidDay = -1;
        public event PropertyChangedEventHandler PropertyChanged;

        public TaskTimerModel([NotNull] ITaskLogger taskLogger, [NotNull] MenuManager menuManager)
        {
            _taskLogger = taskLogger;
            _menuManager = menuManager;

            _menuManager.InitializeNewTrayIcon(this);
            _menuManager.PropertyChanged += MenuManagerOnPropertyChanged;

            _taskItems = _taskLogger.LoadTaskList();
            _menuManager.AddMenuItems(_taskItems);

            Application.ApplicationExit += ApplicationOnApplicationExit;
        }

        public bool IsNewDay
        {
            get
            {
                int currentDay = DateTime.Now.Day;

                if (_savedDay == InvalidDay || _savedDay == currentDay)
                {
                    return false;
                }
                _savedDay = currentDay;
                return true;
            }
        }

        public IList<TaskItem> TaskItems
        {
            get { return _taskItems; }
        }

        public void AddNewTask(string taskName)
        {
            if (_taskItems.Any(x => x.TaskName == taskName))
            {
                return;
            }

            _menuManager.AddMenuItem(taskName);
            _taskItems.Add(new TaskItem
                               {
                                   TaskName = taskName,
                               });
            _taskLogger.SaveChanges(_taskItems);
        }

        protected virtual void OnPropertyChanged([CanBeNull] string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ActivateTask([NotNull] TaskItem task, DateTime now)
        {
            if (IsNewDay)
            {
                ResetAllActiveSeconds();
            }

            _startTime = now;
            task.Active = true;
            task.ActivatedCount += 1;
        }

        private void DeactivateTask([NotNull] TaskItem task, DateTime now)
        {
            var totalSeconds = (int)(now - _startTime).TotalSeconds;
            if (totalSeconds >= 0)
            {
                task.ActiveSeconds += totalSeconds;
            }
            task.Active = false;
        }

        [CanBeNull]
        private TaskItem GetActiveTask()
        {
            return _taskItems.FirstOrDefault(x => x.Active);
        }


        [CanBeNull]
        private TaskItem LookupTask([NotNull] string taskName)
        {
            return _taskItems.FirstOrDefault(x => x.TaskName == taskName);
        }

        private void ResetAllActiveSeconds()
        {
            foreach (TaskItem task in TaskItems)
            {
                task.ActiveSeconds = 0;
            }
        }

        private void ApplicationOnApplicationExit(object sender, EventArgs eventArgs)
        {
            TaskItem activeTask = GetActiveTask();
            if (activeTask != null)
            {
                DeactivateTask(activeTask, DateTime.Now);
                _taskLogger.SaveChanges(_taskItems);
            }
        }

        private void MenuManagerOnPropertyChanged([CanBeNull] object sender, [NotNull] PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "MenuItemClicked":
                    DateTime now = DateTime.Now;

                    TaskItem activeTask = GetActiveTask();
                    if (activeTask != null)
                    {
                        DeactivateTask(activeTask, now);
                    }

                    TaskItem newActiveTask = LookupTask(_menuManager.ClickedMenuItemName);
                    if (newActiveTask != null && newActiveTask != activeTask)
                    {
                        ActivateTask(newActiveTask, now);
                    }

                    _taskLogger.SaveChanges(_taskItems);
                    OnPropertyChanged("MenuItemClicked");
                    break;
            }
        }

        private readonly MenuManager _menuManager;
        private readonly IList<TaskItem> _taskItems;
        private readonly ITaskLogger _taskLogger;
        private int _savedDay = InvalidDay;
        private DateTime _startTime;
    }
}